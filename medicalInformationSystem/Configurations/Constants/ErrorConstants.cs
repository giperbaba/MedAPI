namespace medicalInformationSystem.Configurations.Constants;

public static class ErrorConstants
{
    //general
    public const string RequiredFieldError = "Field is required";
    public const string IncorrectDateError = "Date is invalid";
    public const string InvalidValuePageError = "Invalid value for attribute page";
    
    //diagnosis
    public const string DiagnosisCodeLengthError = "Minimum length diagnosis code is 1";
    public const string DiagnosisNameLengthError = "Minimum length diagnosis name is 1";
    public const string DiagnosisDescriptionLengthError = "Maximum length diagnosis description is 5000 characters.";
    public const string DiagnosisNotFoundError = "Diagnosis not found";
    public const string DiagnosesInvalidCountMainError = "Number of main diagnoses must be 1";

    //speciality
    public const string SpecialityNameLengthError = "Minimum length name of diagnosis is 1";
    public const string SpecialityNotFoundError = "Speciality not found";
    public const string SpecialityDuplicateError = "Mustn't be several consultations with the same specialty doctor";
    
    //profile
    public const string ProfileAlreadyExistsError = "A user with this email already exists";
    public const string ProfileNotFoundError = "User not found";
    public const string PasswordFalseError = "Invalid password";
    public const string PasswordValidError = "Invalid password format";
    public const string PasswordLengthError = "Password must be minimum 6 characters";
    public const string EmailValidError = "Invalid email format";
    public const string PhoneNumberValidError = "Invalid phone number format";
    
    //length
    public const string NameLengthError = "Name must be between 1 and 1000 characters";
    public const string EmailLengthError = "Minimum length of doctor's email is 1";
    public const string CommentLengthError = "Comment length must be between 1 and 1000 characters";
    public const string AuthorNameLengthError = "Minimum length author's name is 1";
    
    //inspection
    public const string InspectionAnamnesisLengthError = "Anamnesis length must be between 1 and 5000 characters";
    public const string InspectionComplaintsLengthError = "Complaints length must be between 1 and 5000 characters";
    public const string InspectionTreatmentLengthError = "Treatment length must be between 1 and 5000 characters";
    public const string InspectionListDiagnosesLengthError = "At least one diagnosis is required.";
    public const string InvalidPreviouslyInspectionError = "Previously inspection datetime must be early than current";
    public const string InspectionNotFoundError = "Previously inspection not found";
    
    //patient condition
    public const string PatientIsAlreadyDeadError = "Patient has already dead";
    public const string PatientConditionDatetimeOfDiseaseError = "If conclusion is disease, must be next visit datetime and mustn't be death datetime";
    public const string PatientConditionDatetimeOfDeathError = "If conclusion is death, must be datetime of death and mustn't be next visit datetime";
    public const string PatientConditionDatetimeOfRecoverError = "If conclusion is recovery, mustn't be next visit and death datetime";
}