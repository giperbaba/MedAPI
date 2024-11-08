using medicalInformationSystem.Api.Models.Api;
using medicalInformationSystem.Api.Models.Request;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Core.Mappers;
using medicalInformationSystem.Core.Repositories.Interfaces;
using medicalInformationSystem.Core.Services.Interfaces;
using medicalInformationSystem.Data.Entities;
using medicalInformationSystem.Data.Enum;
using medicalInformationSystem.Enum;
using medicalInformationSystem.Exceptions;

namespace medicalInformationSystem.Core.Services.Impls;

public class PatientService(
    IPatientRepository patientRepository,
    IIcd10Repository icd10Repository,
    IInspectionRepository inspectionRepository,
    IDiagnosisRepository diagnosisRepository,
    IConsultationRepository consultationRepository) : IPatientService
{
    public async Task<Guid> Register(PatientRegisterModel patientRegister, Guid doctorIdWhoRegistered)
    {
        Patient patient = PatientMapper.MapRegisterModelToEntity(patientRegister, doctorIdWhoRegistered);
        await patientRepository.Add(patient);
        return patient.Id;
    }

    public async Task<PatientModel> GetPatientById(Guid patientId)
    {
        Patient patient = await patientRepository.GetPatientById(patientId);

        if (patient is null)
        {
            throw new ProfileNotFoundException(ErrorConstants.ProfileNotFoundError);
        }

        return PatientMapper.MapEntityToModel(patient);
    }

    public async Task<Guid> CreateInspection(InspectionCreateModel inspection, Guid doctorIdWhoRegistered,
        Guid patientId)
    {
        if (await patientRepository.GetPatientById(patientId) is null)
            throw new ProfileNotFoundException(ErrorConstants.ProfileNotFoundError);
        
        ValidateInspectionNextVisitDate(inspection);
        await ValidatePreviousInspection(inspection, patientId);
        
        Inspection inspectionEntity = InspectionMapper.MapCreateModelToEntity(inspection);
        inspectionEntity.DoctorId = doctorIdWhoRegistered;
        inspectionEntity.PatientId = patientId;
        
        CheckConclusionValidity(inspectionEntity, patientId);
        
        if (await patientRepository.IsPatientDead(patientId)) 
            throw new PatientIsAlreadyDeadException(ErrorConstants.PatientIsAlreadyDeadError);
        
        var diagnoses = await PrepareDiagnoses(inspection);
        var consultations = PrepareConsultations(inspection);
        
        inspectionEntity.BasePreviousInspectionId =
            await inspectionRepository.GetLastGeneralInspectionForPatient(patientId);
        
        await AddAllToDatabase(inspectionEntity, consultations, diagnoses);

        return inspectionEntity.Id;
    }
    
    private void ValidateInspectionNextVisitDate(InspectionCreateModel inspection)
    {
        if (inspection.NextVisitDate.HasValue && inspection.NextVisitDate.Value < DateTime.Now)
            throw new InvalidDatetimeException(ErrorConstants.IncorrectDateError);
    }
    
    private async Task ValidatePreviousInspection(InspectionCreateModel inspection, Guid patientId)
    {
        if (inspection.PreviousInspectionId is not null)
        {
            Guid? previousInspectionId =
                await patientRepository.CheckPreviouslyInspection(patientId, inspection.PreviousInspectionId,
                    inspection.Date);
            if (previousInspectionId is null)
                throw new InvalidDatetimeException(ErrorConstants.InvalidPreviouslyInspectionError);
        }
    }
    
    private async Task<ICollection<Diagnosis>> PrepareDiagnoses(InspectionCreateModel inspection)
    {
        int mainDiagnosesCount = 0;
        var diagnoses = new List<Diagnosis>();

        foreach (var diagnosis in inspection.Diagnoses)
        {
            if (diagnosis.Type == DiagnosisType.Main) mainDiagnosesCount++;
            if (mainDiagnosesCount > 1)
                throw new InvalidCountMainDiagnosesException(ErrorConstants.DiagnosesInvalidCountMainError);

            var icdDiagnosis = await icd10Repository.GetByIdGuidAsync(diagnosis.IcdDiagnosisId);
            if (icdDiagnosis is null)
                throw new DiagnosisNotFoundException(ErrorConstants.DiagnosisNotFoundError);

            var diagnosisEntity =
                DiagnosesMapper.MapCreateModelToEntity(diagnosis, icdDiagnosis.McbCode, icdDiagnosis.McbName);
            diagnoses.Add(diagnosisEntity);
        }

        return diagnoses;
    }
    
    private ICollection<Consultation> PrepareConsultations(InspectionCreateModel inspection)
    {
        var consultations = new List<Consultation>();
        
        var specialityIds = new HashSet<Guid>();

        foreach (var consult in inspection.Consultations)
        {
            if (!specialityIds.Add(consult.SpecialityId))
                throw new DuplicateSpecialityException(ErrorConstants.SpecialityDuplicateError);

            var consultationEntity = ConsultationMapper.MapCreateModelToEntity(consult);
            consultations.Add(consultationEntity);
        }

        return consultations;
    }
    
    private async void CheckConclusionValidity(Inspection inspection, Guid patientId)
    {
        switch (inspection.Conclusion)
        {
            case Conclusion.Disease:
                if (inspection.NextVisitDate is null || inspection.DeathDate is not null)
                    throw new InvalidDatetimeException(ErrorConstants.PatientConditionDatetimeOfDiseaseError);
                break;

            case Conclusion.Recovery:
                if (inspection.NextVisitDate is not null || inspection.DeathDate is not null)
                    throw new InvalidDatetimeException(ErrorConstants.PatientConditionDatetimeOfRecoverError);
                break;

            case Conclusion.Death:
                if (inspection.NextVisitDate is not null || inspection.DeathDate is null)
                    throw new InvalidDatetimeException(ErrorConstants.PatientConditionDatetimeOfDeathError);
                break;
        }
    }
    
    private async Task AddAllToDatabase(Inspection inspectionEntity, ICollection<Consultation> consultations,
        ICollection<Diagnosis> diagnoses)
    {
        await inspectionRepository.Add(inspectionEntity);
        
        foreach (var diagnosis in diagnoses)
        {
            diagnosis.InspectionId = inspectionEntity.Id;
            await diagnosisRepository.Add(diagnosis);
        }

        foreach (var consultation in consultations)
        {
            consultation.InspectionId = inspectionEntity.Id;
            await consultationRepository.Add(consultation);
        }
    }
}