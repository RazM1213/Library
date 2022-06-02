using System;
using System.Linq;

namespace BLL
{
    public static class Validator // Split to a few classes - each tests one condition. Create validator interface
    {
        public static bool IsBookIdValid(string bookId)
        {
            if (!char.IsLetter(bookId[0]) || !char.IsLetter(bookId[1]) || bookId.Length != 6)
            {
                return false;
            }

            return true;
        }

        public static bool IsFamilyNameValid(string familyName)
        {
            if (!char.IsUpper(familyName[0]) || !familyName.All(char.IsLetter))
            {
                return false;
            }

            return true;
        }

        public static bool IsMemberIdValid(string id)
        {
            if (id.Length != 9 || !id.All(char.IsDigit))
            {
                return false;
            }

            return true;
        }

        public static bool ValidateQuery(string[] commandParams)
        {
            if (commandParams[1] != "!" && !IsMemberIdValid(commandParams[1]) && !IsBookIdValid(commandParams[1]))
            {
                throw new Exception("Invalid query !");
            }

            return true;
        }

        public static bool ValidateCommand(string[] commandParams) // Arrange method to finally return true, and to return false when validation fails, with indicative message for user 
        {
            if (commandParams.Length > 4)
            {
                throw new Exception("Command too long");
            }

            if (!IsFamilyNameValid(commandParams[1]))
            {
                throw new Exception("Invalid family name !");
            }

            if (!IsMemberIdValid(commandParams[2]))
            {
                throw new Exception("Invalid member id !");
            }

            if (commandParams.Length == 4)
            {
                if (!IsBookIdValid(commandParams[3]))
                {
                    throw new Exception("Invalid book id !");
                }
            }

            return true;
        }
    }
}
