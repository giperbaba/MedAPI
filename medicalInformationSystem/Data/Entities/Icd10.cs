using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace medicalInformationSystem.Data.Entities;

[Table("Icd10")] 
public class Icd10
{
    //"ID": 3365,
    // "REC_CODE": "0702H100",
    // "MKB_CODE": "H10.0",
    // "MKB_NAME": "Слизисто-гнойный конъюнктивит",
    // "ID_PARENT": "3364",
    // "ACTUAL": 1
    
    [Key]
    [Column("id_guid")]
    public Guid? IdGuid { get; set; }
    [Column("id_int")]
    public int IdInt { get; set; }
    
    [Column("id_parent_guid")] public Guid? IdParentGuid { get; set; }
    [Column("id_parent_int")] public string? IdParent { get; init; }
    
    [Column("REC_CODE")]
    public string RecCode { get; set; }
    
    [Column("MKB_CODE")]
    public string McbCode { get; set; }
    
    [Column("MKB_NAME")]
    public string McbName { get; set; }
    
    [Column("ACTUAL")]
    public int Actual { get; set; }
    
    [Column("create_time")]
    public DateTime CreateTime { get; init; } = DateTime.UtcNow;
}