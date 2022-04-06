using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharp_API_Interaction
{
    public class Validator
    {
        internal static bool IsTextValid(string stringInput)
        {
            if (String.IsNullOrEmpty(stringInput)) return false;

            foreach (char c in stringInput)
            {
                if(!Char.IsLetter(c) && c != ' ' && c != '/') return false;
            }

            return true;
        }

        internal static bool IsIdValid(string stringInput)
        {
            if (String.IsNullOrEmpty(stringInput)) return false;

            foreach(char c in stringInput)
            {
                if(!Char.IsDigit(c)) return false;
            }

            return true;
        }
    }
}
