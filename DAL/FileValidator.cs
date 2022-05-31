using System.IO;
using System.Linq;

namespace DAL
{
    public class FileValidator
    {
        private string _path;
        private int _minimumLines;
        private string[] _commandIdentifiers;

        public FileValidator(string path)
        {
            this._path = path;
            this._minimumLines = 1;
            this._commandIdentifiers = new string[3] { "-", "+", "?" };
        }

        public bool IsValid()
        {
            if (File.ReadAllLines(this._path).Length >= this._minimumLines)
            {
                if (this._commandIdentifiers.Any(File.ReadAllLines(this._path)[0].Contains))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
