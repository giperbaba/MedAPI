namespace medicalInformationSystem.Configurations.Constants;

public static class RegexConstants
{
    public const string PhoneNumberRegex = @"^((\+7)|8)[0-9]{10}$";

    public const string PasswordRegex = @"^(?=.*[A-Za-z])(?=.*\d).{4,}$";
}