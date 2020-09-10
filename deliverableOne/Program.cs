using System;
using System.Text.RegularExpressions;

namespace deliverableOne
{
    class Program
    {
        static void Main(string[] args)
        {
            int minLength = 7;
            int maxLength = 12;

            Console.WriteLine($"Passwords must be {minLength}-{maxLength} characters and include 1 uppercase letter, one lowercase letter, and an exclamation point (!).");
            Console.Write("Please enter a password: ");
            string userPassword = Console.ReadLine();

            if (isValidPassword(userPassword))
            {
                Console.Write("Password valid and accepted");
            }
            else {
                Console.Write("Error");
            }

            bool isValidPassword(string password)
            {
                if (!isMinLength(password, minLength))
                {
                    return false;
                }
                else if (!isMaxLength(password, maxLength))
                {
                    return false;
                }
                else if (!hasLowercaseChar(password))
                {
                    return false;
                }
                else if (!hasUppercaseChar(password))
                {
                    return false;
                }
                else if (!containsExclamation(password))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            
            string removeSpecialCharacters(string input) {
                return Regex.Replace(input, @"[^0-9a-zA-Z]+", "");
            }

            bool hasUppercaseChar(string password)
            {
                string cleanPassword = removeSpecialCharacters(password);
                foreach (char character in cleanPassword)
                {
                    if (character == char.ToUpper(character))
                    {
                        return true;
                    }
                }
                return false;
            }

            bool hasLowercaseChar(string password)
            {
                string cleanPassword = removeSpecialCharacters(password);
                foreach (char character in cleanPassword)
                {
                    if (character == char.ToLower(character))
                    {
                        return true;
                    }
                }
                return false;
            }

            bool isMinLength(string password, int targetLength)
            {
                return password.Length >= targetLength;
            }

            bool isMaxLength(string password, int targetLength)
            {
                return password.Length <= targetLength;
            }

            bool containsExclamation(string password)
            {
                int location = password.IndexOf("!");

                if (location >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
