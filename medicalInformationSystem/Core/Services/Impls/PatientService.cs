using medicalInformationSystem.Api.Models.Api;
using medicalInformationSystem.Api.Models.Request;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Core.Mappers;
using medicalInformationSystem.Core.Repositories.Interfaces;
using medicalInformationSystem.Core.Services.Interfaces;
using medicalInformationSystem.Data.Entities;
using medicalInformationSystem.Data.Enum;
using medicalInformationSystem.Data.Validator;
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
        ICollection<Consultation> consultations = new List<Consultation>();
        ICollection<Diagnosis> diagnoses = new List<Diagnosis>();
        
        Inspection inspectionEntity = InspectionMapper.MapCreateModelToEntity(inspection);

        if (inspection.NextVisitDate.HasValue && inspection.NextVisitDate.Value < DateTime.Now) //следующий визит в прошедшем времени
            throw new InvalidDatetimeException(ErrorConstants.IncorrectDateError);

        if (inspection.PreviousInspectionId != null)
        {
            if (!await patientRepository.ExistsPreviousInspection(patientId, inspection.PreviousInspectionId,
                    inspection.Date))
            {
                throw new InvalidDatetimeException(ErrorConstants.InvalidPreviouslyInspectionError);
            }
        }

        inspectionEntity.DoctorId = doctorIdWhoRegistered;
        inspectionEntity.PatientId = patientId;
        await inspectionRepository.Add(inspectionEntity);
        
        int mainDiagnosesCount = 0;
        foreach (DiagnosisCreateModel diagnosis in inspection.Diagnoses)
        {
            if (diagnosis.Type == DiagnosisType.Main) mainDiagnosesCount++;

            if (await icd10Repository.GetByIdGuidAsync(diagnosis.IcdDiagnosisId) is null)
                throw new DiagnosisNotFoundException(ErrorConstants.DiagnosesNotFoundError);

            Diagnosis diagnosisEntity = DiagnosesMapper.MapCreateModelToEntity(diagnosis,
               icd10Repository.GetByIdGuidAsync(diagnosis.IcdDiagnosisId).Result.McbCode,
               icd10Repository.GetByIdGuidAsync(diagnosis.IcdDiagnosisId).Result.McbName);
            diagnosisEntity.InspectionId = inspectionEntity.Id;
            diagnoses.Add(diagnosisEntity);
            await diagnosisRepository.Add(diagnosisEntity);
        }

        if (mainDiagnosesCount != 1)
            throw new InvalidCountMainDiagnosesException(ErrorConstants.InvalidCountMainDiagnosesError);


        var specialityIds = new HashSet<Guid>();
        foreach (ConsultationCreateModel consult in inspection.Consultations)
        {
            if (!specialityIds.Add(consult.SpecialityId))
            {
                throw new DuplicateSpecialityException(ErrorConstants.DuplicateSpecialityError);
            }

            Consultation consultationEntity = ConsultationMapper.MapCreateModelToEntity(consult);
            consultationEntity.InspectionId = inspectionEntity.Id;
            consultations.Add(consultationEntity);
            await consultationRepository.Add(consultationEntity);
        }
        
        switch (inspection.Conclusion)
        {
            case Conclusion.Disease:
                if (inspection.NextVisitDate is null)
                    throw new InvalidDatetimeException(ErrorConstants.ConditionDatetimeOfDiseaseError);
                break;

            case Conclusion.Recovery:
                if (inspection.NextVisitDate is not null && inspection.DeathDate is not null)
                    throw new InvalidDatetimeException(ErrorConstants.ConditionDatetimeOfRecoverError);
                break;

            case Conclusion.Death:
                if (inspection.NextVisitDate is not null || inspection.DeathDate is not null)
                    throw new InvalidDatetimeException(ErrorConstants.ConditionDatetimeOfDeathError);
                break;
        }
        
        inspectionEntity.Consultations = consultations;
        inspectionEntity.Diagnoses = diagnoses;
        
        return inspectionEntity.Id;
    }
}