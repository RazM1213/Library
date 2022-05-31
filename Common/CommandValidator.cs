using System.Linq;

namespace Common
{
    public class CommandValidator
    {
        private Command _command;

        public CommandValidator(Command command)
        {
            this._command = command;
        }

        public bool IsBookIdValid(string bookId)
        {
            if (!char.IsLetter(bookId[0]) || !char.IsLetter(bookId[1]) || bookId.Length != 6)
            {
                return false;
            }

            return true;
        }

        public bool IsFamilyNameValid(string familyName)
        {
            if (!char.IsUpper(familyName[0]) || !familyName.All(char.IsLetter))
            {
                return false;
            }

            return true;
        }

        public bool IsMemberIdValid(string id)
        {
            if (id.Length != 9 || !id.All(char.IsDigit))
            {
                return false;
            }

            return true;
        }

        public bool Validate()
        {
            if (this._command.BookId != null)
            {
                if (this.IsFamilyNameValid(this._command.FamilyName) && this.IsBookIdValid(this._command.BookId) && this.IsMemberIdValid(this._command.Id))
                {
                    return true;
                }
            } else 
            {
                if (this.IsFamilyNameValid(this._command.FamilyName) && this.IsMemberIdValid(this._command.Id))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
