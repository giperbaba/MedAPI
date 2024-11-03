using System.Text.Json.Serialization;

namespace medicalInformationSystem.Enum;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DiagnosisType
{
    Main,
    Concomitant,
    Complication
}