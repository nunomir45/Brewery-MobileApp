using System.Text.RegularExpressions;

namespace Brewery.Core.Helpers;

public static class StringHelpers
{
    public static bool IsUrl(this string input)
    {
        string pattern = @"^(http|https|ftp):\/\/[^\s/$.?#].[^\s]*$";
        Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
        return regex.IsMatch(input);
    }
}