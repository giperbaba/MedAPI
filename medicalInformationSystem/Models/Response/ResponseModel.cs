using System.Net;

namespace medicalInformationSystem.Models.Response;

public class ResponseModel
{
    public ResponseModel(string statusCode, string statusDescription)
    {
        Status = statusCode;
        Message = statusDescription;
    }
        
    public string? Status { get; set; }
    
    public string? Message { get; set; }
}