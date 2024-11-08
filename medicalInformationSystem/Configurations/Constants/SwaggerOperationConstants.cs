namespace medicalInformationSystem.Configurations.Constants;

public static class SwaggerOperationConstants
{
    //dictionary
    public const string DictionaryGetSpecialties = "Get specialties list";
    public const string DictionarySearchIcd10Diagnoses = "Search for diagnoses in ICD-10 dictionary";
    public const string DictionaryIcd10Roots = "Get root ICD-10 elements";
    
    //authentication
    public const string UserRegister = "Register new user";
    public const string UserLogin = "Login in to the system";
    public const string UserLogout = "Log out system user";
    
    //profile
    public const string UserGetProfile = "Get user profile";
    public const string UserEditProfile = "Edit user profile";
    
    //patient
    public const string PatientCreate = "Create new patient";
    public const string PatientCreateInspection = "Create inspection for specified patient";
    public const string PatientGetCard = "Get patient card";
    public const string PatientSearchInspection = "Search for patient medical inspection without child inspections";
    
    //consultation
    public const string ConsultationGet = "Get concrete consultation";
}