using System.Text.Json.Serialization;

namespace medicalInformationSystem.Enum;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Conclusion
{
    Disease,
    Recovery,
    Death
}