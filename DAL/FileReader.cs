using System;
using System.IO;

namespace DAL
{
    public class FileReader : IReader
    {
        public string Path { get; set; }
        private readonly FileValidator _fileValidator;

        public FileReader(string path)
        {
            this.Path = path;
            this._fileValidator = new FileValidator(this.Path);
        }

        public string[] GetLines()
        {
            if (this._fileValidator.IsValid())
            {
                return File.ReadAllLines(this.Path);
            } else
            {
                return null;
            }
        }

        public void PrintLines()
        {
            if (this._fileValidator.IsValid())
            {
                foreach (string line in this.GetLines())
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}
