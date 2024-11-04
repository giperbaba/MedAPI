using System.Text.Json.Serialization;

namespace medicalInformationSystem.Api.Models.Api;

public class Icd10Model
{
    //"ID": 3365,
    // "REC_CODE": "0702H100",
    // "MKB_CODE": "H10.0",
    // "MKB_NAME": "Слизисто-гнойный конъюнктивит",
    // "ID_PARENT": "3364",
    // "ACTUAL": 1
    
    [JsonPropertyName("ID")]
    public int idInt { get; set; }
    public Guid idGuid { get; set; }
    
    [JsonPropertyName("ID_PARENT")]
    public string? idParent { get; set; }

    public Guid? idParentGuid { get; set; } = null;
    
    [JsonPropertyName("REC_CODE")]
    public string recCode { get; set; }
    
    [JsonPropertyName("MKB_CODE")]
    public string mkbCode { get; set; }
    
    [JsonPropertyName("MKB_NAME")]
    public string mkbName { get; set; }
    
    [JsonPropertyName("ACTUAL")]
    public int actual { get; set; }
}