using System.Text.RegularExpressions;

namespace medicalInformationSystem.Configurations.Constants;

public static class RegexConstants
{
    public const string EmailRegex = "^[-\\w.]+@([A-z0-9][-A-z0-9]+\\.)+[A-z]{2,4}$";

    public const string PhoneNumberRegex = "^(\\+)?((\\d{2,3}) ?\\d|\\d)(([ -]?\\d)|( ?(\\d{2,3}) ?)){5,12}\\d$";

    public const string PasswordRegex = "^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\\s).*$";
}