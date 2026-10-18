using System.Text.RegularExpressions;

public static class StringValidationExtensions
{
    public static bool IsValidEgyptianPhone(this string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;

        return Regex.IsMatch(
            value,
            @"^(?:01[0125]\d{8}|\+201[0125]\d{8})$");
    }

    public static bool IsValidEgyptianNationalId(this string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;

        return Regex.IsMatch(value, @"^[23]\d{13}$");
    }
}