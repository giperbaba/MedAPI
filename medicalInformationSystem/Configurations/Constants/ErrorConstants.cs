namespace medicalInformationSystem.Configurations.Constants;

public static class ErrorConstants
{
    public const string DiagnosisCodeLengthError = "Minimum length diagnosis code is 1";
    public const string  DiagnosisNameLengthError = "Minimum length diagnosis name is 1";
    public const string  DiagnosisDescriptionLengthError = "Maximum length diagnosis description is 5000 characters.";
    
    public const string  SpecialityNameLengthError = "Minimum length name of diagnosis is 1";
    
    public const string  CommentLengthError = "Comment length must be between 1 and 1000 characters";
    
    public const string DoctorNameLengthError = "Doctor Name must be between 1 and 1000 characters";
    public const string DoctorEmailLengthError = "Minimum length of doctor's email is 1";
    public const string DoctorPasswordLengthError = "Doctor Password must be minimum 6 characters";
    
    public const string DoctorEmailValidError = "Invalid email format";
    public const string DoctorPasswordValidError = "Invalid password format";
    public const string DoctorPhoneNumberValidError = "Invalid phone number format";
    
    public const string RequiredFieldError = "Field is required";
}