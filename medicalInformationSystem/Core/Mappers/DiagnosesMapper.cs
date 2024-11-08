using medicalInformationSystem.Api.Models.Request;
using medicalInformationSystem.Data.Entities;

namespace medicalInformationSystem.Core.Mappers;

public static class DiagnosesMapper
{
    public static Diagnosis MapCreateModelToEntity(DiagnosisCreateModel diagnosisCreateModel, string icd10Code, string icd10Name)
    {
        return new Diagnosis
        {
            Id = Guid.NewGuid(),
            CreateTime = DateTime.Now.ToUniversalTime(),
            Code = icd10Code,
            Name = icd10Name,
            Description = diagnosisCreateModel.Description,
            Type = diagnosisCreateModel.Type,
            DiagnosisIcd10Id = diagnosisCreateModel.IcdDiagnosisId,
        };
    }
}