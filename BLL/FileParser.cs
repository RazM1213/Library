using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using DAL;

namespace BLL
{
    public class FileParser
    {
        private readonly IReader _fileReader;
        public List<ICommand> Commands { get; }
        public List<IQuery> Queries { get; }

        public FileParser(string path)
        {
            this._fileReader = new FileReader(path);
            this.Commands = new List<ICommand>();
            this.Queries = new List<IQuery>();
        }

        public void PlusIdentifier(string[] parameters)
        {
            if (parameters.Length == 4)
            {
                this.Commands.Add(new LendBookCommand(parameters[1], parameters[2], parameters[3]));
            }
            else
                this.Commands.Add(new CreateNewMemberCommand(parameters[1], parameters[2]));
        }

        public void MinusIdentifier(string[] parameters)
        {

            if (parameters.Length == 4)
            {
                this.Commands.Add(new ReturnBookCommand(parameters[1], parameters[2], parameters[3]));
            }
            else
            {
                this.Commands.Add(new DeleteExistingMemberCommand(parameters[1], parameters[2]));
            }
        }

        public void QuestionIdentifier(string[] parameters)
        {
            if (parameters[1] == "!")
            {
                this.Queries.Add(new GetTopMembersQuery(parameters[1]));
            }
            else if (!parameters[1].All(char.IsNumber))
            {
                this.Queries.Add(new GetMemberByBookQuery(parameters[1]));
            }
            else
            {
                this.Queries.Add(new GetBooksByMemberQuery(parameters[1]));
            }
        }

        public void Parse()
        {
            foreach (string line in this._fileReader.GetLines())
            {
                string[] commandParams = line.Trim().Split(" ");

                bool validateResult = false;

                try
                {
                    if (commandParams.Length == 2)
                    {
                        validateResult = Validator.ValidateQuery(commandParams);
                    }
                    else
                    {
                        validateResult = Validator.ValidateCommand(commandParams);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                if (validateResult)
                {
                    switch (commandParams[0])
                    {
                        case "+":
                            this.PlusIdentifier(commandParams);
                            break;

                        case "-":
                            this.MinusIdentifier(commandParams);
                            break;

                        case "?":
                            this.QuestionIdentifier(commandParams);
                            break;

                        default:
                            Console.WriteLine("Invalid Command");
                            break;
                    }
                }
            }
        }
    }
}