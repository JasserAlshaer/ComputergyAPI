using System.Diagnostics.Eventing.Reader;
using System.Text.RegularExpressions;

namespace ComputergyAPI.Helpers.LanguageHelper
{
    public class LanguageHelper
    {
        public static  bool IsContainsArabic(string input)
        {
            foreach (char c in input)
            {
                if (c >= 0x0600 && c <= 0x06FF)
                {
                    return true; 
                }
            }
            return false; 
        }

        public static  bool IsContaintsEnglish(string input)
        {
            foreach (char c in input)
            {
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                {
                    return true; 
                }
            }
            return false; 
        }
    }
}

