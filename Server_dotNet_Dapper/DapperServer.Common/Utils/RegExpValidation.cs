using DapperServer.Common.Helper;
using System;
using System.Text.RegularExpressions;

namespace DapperServer.Common.Utils
{
    public class RegExpValidation
    {
        public static bool UsernameValidation(string username)
        {
            string minMaxLength = @"^.{8,30}$";

            /// Start with alphabetically character, All other characters can be alphabets, numbers or an underscore
            string startWith = @"^[A-Za-z][A-Za-z0-9_.]{7,29}$";

            if (Regex.IsMatch(username, minMaxLength) &&
                Regex.IsMatch(username, startWith))
                return true;
            else
                throw new AppException("Username validation isn't fulfilled!");

            return false;
        }

        public static bool PasswordValidation(string password)
        {
            string minMaxLength = "^.{8,32}$";
            /// One or more uppercase letters.
            string upper = "[A-Z]";
            /// One or more lowercase letters.
            string lower = "[a-z]";
            /// One or more numbers.
            string number = "[0-9]";
            /// One or more special characters (ASCII punctuation or space characters).
            string special = @"[!#$%&'()*+,\-./:;<=>?@[\\\]^_`{|}~]";

            if (Regex.IsMatch(password, minMaxLength) &&
                Regex.IsMatch(password, upper) &&
                Regex.IsMatch(password, lower) &&
                Regex.IsMatch(password, number) &&
                Regex.IsMatch(password, special)
                )
                return true;
            else
                throw new AppException("Password validation isn't fulfilled!");

            return false;
        }

        public static bool EmailValidation(string email)
        {
            string minMaxLength = "^.{8,30}$";
            string validation = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

            if (Regex.IsMatch(email, minMaxLength) &&
                Regex.IsMatch(email, validation))
                return true;
            else
                throw new AppException("Email validation isn't fulfilled!");

            return false;
        }
    }
}
