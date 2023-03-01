using System.Text.RegularExpressions;

namespace KeyVault.Tools;

public class Validator
{
    public bool ValidateEmail(string email)
    {
        string pattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
        return Regex.Match(email, pattern).Success;
    }
}