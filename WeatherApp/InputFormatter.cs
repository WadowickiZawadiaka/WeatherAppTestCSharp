using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class InputFormatter
    {
        internal static string CapitaliseFirstLetter(string str)
        {
            //var firstLetter = str.Substring(0, 1);
            //firstLetter = firstLetter.ToUpper();
            //var otherLetters = str.Substring(1);
            //otherLetters = otherLetters.ToLower();
            //string matchingInput = firstLetter + otherLetters;

            var matchingInput = string.Empty;
            if (!String.IsNullOrEmpty(str))
            {
                matchingInput = char.ToUpper(str.First()) + str.Substring(1).ToLower();
            }

            return matchingInput;
        }
    }
}
