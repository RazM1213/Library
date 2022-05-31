using DAL;
using Common;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class LibraryManager
    {
        private FileParser _fileParser;

        public LibraryManager()
        {
            this._fileParser = new FileParser(@"C:\Users\razm1\source\repos\Library\DAL\Utils\Commands.txt");
            this._fileParser.Parse();
        }

        public List<ICommand> GetCommands()
        {
            return this._fileParser.Commands;
        }

        public List<IQuery> GetQueries()
        {
            return this._fileParser.Queries;
        }

        public void RunCommands()
        {
            foreach (ICommand command in this.GetCommands())
            {
                command.RunCommand();
            }
        }

        public void RunQueries()
        {
            foreach (IQuery query in this.GetQueries())
            {
                query.RunQuery();
            }
        }
    }
}
