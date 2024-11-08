using medicalInformationSystem.Api.Models.Api;
using medicalInformationSystem.Api.Models.Request;
using medicalInformationSystem.Data.Entities;

namespace medicalInformationSystem.Core.Mappers;

public static class InspectionMapper
{
    public static Inspection MapCreateModelToEntity(InspectionCreateModel inspectionCreateModel)
    {
        return new Inspection
        {
            Id = Guid.NewGuid(),
            CreateTime = DateTime.Now.ToUniversalTime(),

            Date = inspectionCreateModel.Date,
            Anamnesis = inspectionCreateModel.Anamnesis,
            Complaints = inspectionCreateModel.Complaints,
            Treatment = inspectionCreateModel.Treatment,
            Conclusion = inspectionCreateModel.Conclusion,
            NextVisitDate = inspectionCreateModel.NextVisitDate,

            DeathDate = inspectionCreateModel.DeathDate,
            PreviousInspectionId = inspectionCreateModel.PreviousInspectionId,
        };
    }

    public static InspectionShortModel MapEntityToShortModel(Inspection inspection, DiagnosisModel mainDiagnosis)
    {
        return new InspectionShortModel
        {
            Id = inspection.Id,
            CreateTime = inspection.CreateTime,
            Date = inspection.Date,
            Diagnosis = mainDiagnosis
        };
    }
}