//====================================================
//| Downloaded From                                  |
//| Visual C# Kicks - http://vckicks.110mb.com/      |
//| License - http://vckicks.110mb.com/license.html  |
//====================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace StringFunctions
{
    public static class ConvertArray
    {
        public static string ArrayToString(IList array)
        {
            return ArrayToString(array, Environment.NewLine);
        }

        public static string ArrayToString(IList array, string delimeter)
        {
            string outputString = "";

            foreach (object obj in array)
            {
                outputString += obj.ToString() + Environment.NewLine;
            }

            return outputString;
        }



        public static string ArrayToStringGeneric<T>(IList<T> array)
        {
            return ArrayToStringGeneric<T>(array, Environment.NewLine);
        }

        public static string ArrayToStringGeneric<T>(IList<T> array, string delimeter)
        {
            string outputString = "";

            foreach (object obj in array)
            {
                outputString += obj.ToString() + delimeter;
            }

            return outputString;
        }
    }
}
