using System.ComponentModel.DataAnnotations;

namespace medicalInformationSystem.Validator;

public class DatetimeValidator: ValidationAttribute
{
    public override bool IsValid(object? value)
    {

        if (DateTime.TryParse(value?.ToString(), out var parsedDateTime))
        {
            return parsedDateTime < DateTime.Now;
        }
        
        return false;
    }
}