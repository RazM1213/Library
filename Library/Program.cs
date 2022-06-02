using BLL;
using Common;
using System;
using System.IO;

namespace UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            LibraryManager manager = new LibraryManager();

            foreach (ICommand command in manager.GetCommands())
            {
                command.RunCommand();
            }

            Console.WriteLine("=====================================");

            foreach (IQuery query in manager.GetQueries())
            {
                query.RunQuery();
            }
        }
    }
}
