namespace medicalInformationSystem.Configurations.Constants;

public static class ErrorConstants
{
    public const string DiagnosisCodeLengthError = "Minimum length diagnosis code is 1";
    public const string  DiagnosisNameLengthError = "Minimum length diagnosis name is 1";
    public const string  DiagnosisDescriptionLengthError = "Maximum length diagnosis description is 5000 characters.";
    
    public const string  SpecialityNameLengthError = "Minimum length name of diagnosis is 1";
    
    public const string  CommentLengthError = "Comment length must be between 1 and 1000 characters";
    
    public const string  AuthorNameLengthError = "Minimum length author's name is 1";
    
    public const string NameLengthError = "Doctor Name must be between 1 and 1000 characters";
    public const string EmailLengthError = "Minimum length of doctor's email is 1";
    public const string PasswordLengthError = "Doctor Password must be minimum 6 characters";
    
    public const string EmailValidError = "Invalid email format";
    public const string PasswordValidError = "Invalid password format";
    public const string PhoneNumberValidError = "Invalid phone number format";
    
    public const string InspectionAnamnesisLengthError = "Anamnesis length must be between 1 and 5000 characters";
    public const string InspectionComplaintsLengthError = "Complaints length must be between 1 and 5000 characters";
    public const string InspectionTreatmentLengthError = "Treatment length must be between 1 and 5000 characters";
    public const string InspectionListDiagnosesLengthError = "At least one diagnosis is required.";
    
    
    public const string RequiredFieldError = "Field is required";
}