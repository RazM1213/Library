using System.Linq;

namespace Common
{
    public class Command
    {
        private string _familyName;
        private string _id;
        private string _bookId;

        public Command(string familyName, string id, string bookId = null)
        {
            this._familyName = familyName;
            this._id = id;
            this._bookId = bookId;
        }

        public string FamilyName
        {
            get => this._familyName;
            set
            {
                if (!char.IsUpper(this._familyName[0]) || !this._familyName.All(char.IsLetter))
                {
                    this._familyName = value;
                }
            }
        }

        public string Id
        {
            get => this._id;
            set
            {
                if (this._id.Length != 9 || !this._id.All(char.IsDigit))
                {
                    this._id = value;
                }
            }
        }

        public string BookId
        {
            get => this._bookId;
            set
            {
                if (!char.IsLetter(this._bookId[0]) || !char.IsLetter(this._bookId[1]) || this._bookId.Length != 6)
                {
                    this._bookId = value;
                }
            }
        }
    }
}
