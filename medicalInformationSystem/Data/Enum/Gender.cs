using System.ComponentModel;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace medicalInformationSystem.Enum;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Gender
{ 
    Male,
    Female
}