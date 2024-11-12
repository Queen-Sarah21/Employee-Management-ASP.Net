using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Lab1_ASPNetConnectedMode.VALIDATION
{
    public class Validation
    {

        public static bool IsValidId(string input) // 5-digit number
        {
            return Regex.IsMatch(input, @"^\d{4}$");

        }

        public static bool IsValidId(string input, int size) // 5-digit number
        {
            //if (!Regex.IsMatch(input, @"^\d{" + size + "}$"))
            //{
            //    return false;
            //}

            //return true;
            return Regex.IsMatch(input, @"^\d{" + size + "}$");

        }

        public static bool IsValidName(string input)

        {
            //if (input.Length == 0)
            //{
            //    return false;

            //}
            //for (int i = 0; i < input.Length; i++)
            //{
            //    if ((!Char.IsLetter(input[i])) && (!Char.IsWhiteSpace(input[i])))
            //    {
            //        return false;
            //    }

            //}

            //return true;
            return !string.IsNullOrEmpty(input) && input.All(char.IsLetterOrDigit);
        }

       
    }
}