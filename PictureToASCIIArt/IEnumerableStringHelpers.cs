using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PictureToASCIIArt;

public static class IEnumerableStringHelpers
{
    public static bool Contains(this IEnumerable<string> list, string wildcard)
    {
        string pattern = wildcard;
        return list.Any(x => Regex.IsMatch(x, pattern));
    }

    public static string FirstOf(this IEnumerable<string> list, string wildcard)
    {
        string pattern = wildcard;
        string result = list.First( x => Regex.IsMatch(x,pattern));
        return result;
    }
}
