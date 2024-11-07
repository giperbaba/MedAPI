using System.Text.Json.Serialization;

namespace medicalInformationSystem.Data.Enum;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Conclusion
{
    Disease,
    Recovery,
    Death
}