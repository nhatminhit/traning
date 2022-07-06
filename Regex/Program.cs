using System;

namespace RegexValidate
{
    class Program
    {
        static void Main(string[] args)
        {
            Regexvalidation regex = new Regexvalidation();
            bool valiPhoneNumber = regex.ValidateMobile();
            Console.WriteLine("Phone Number"+ " " +valiPhoneNumber);
            bool valiEmail = regex.ValidateEmail();
            Console.WriteLine("Email" + " " + valiEmail);
            bool valiPass = regex.ValidatePass();
            Console.WriteLine("Password" + " " + valiPass);
        }
    }
}
