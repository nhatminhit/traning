using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexValidate
{
    public class Regexvalidation
    {
        public static string Phone_Regex = "^\\(?([0-9]{3})\\)?[-.\\s]?([0-9]{3})[-.\\s]?([0-9]{4})$";
        //public static string Email_Regex = "^[0-9a-zA-Z]+[.+-_]{0,1}[0-9a-zA-Z]+[@][a-zA-Z]+[.][a-zA-Z]{2,3}([a-zA-Z]{2,3}){0,1}";
        public static string Email_Regex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        public static string Password_Regex = @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]+";
        public bool ValidateMobile ()
        {
            return Regex.IsMatch("(123) 456 7890", Phone_Regex);
        }
        public bool ValidateEmail ()
        {
            return Regex.IsMatch("asasasa@emailao.cyou", Email_Regex);
        }
        public bool ValidatePass()
        {
            return Regex.IsMatch("NDXngC$?7])5Wwf{A2a>G^yx}9SYV~%P!@,+pJm4T:[", Password_Regex);
        }
    }
}
