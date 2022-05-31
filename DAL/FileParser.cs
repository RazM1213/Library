using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace DAL
{
    public class FileParser
    {
        private IReader _fileReader;
        private CommandValidator _commandValidator;
        public List<ICommand> Commands { get; }
        public List<IQuery> Queries { get; }

        public FileParser(string path)
        {
            this._fileReader = new FileReader(path);
            this.Commands = new List<ICommand>();
            this.Queries = new List<IQuery>();
        }

        public Command BuildCommand(string line)
        {
            string[] commandStructure = line.Split(' ');

            Command command;

            if (commandStructure.Length == 4)
            {
                command = new Command(commandStructure[1], commandStructure[2], commandStructure[3]);
            } else
            {
                command = new Command(commandStructure[1], commandStructure[2]);
            }

            this._commandValidator = new CommandValidator(command);
            if (this._commandValidator.Validate())
            {
                return command;

            }

            return null;
        }

        public void PlusIdentifier(string trimmedLine)
        {
            Command command = this.BuildCommand(trimmedLine);

            if (command.BookId != null)
            {
                this.Commands.Add(new LendBookCommand(command.FamilyName, command.Id, command.BookId));
            }
            else
            {
                this.Commands.Add(new CreateNewMemberCommand(command.FamilyName, command.Id));
            }
        }

        public void MinusIdentifier(string trimmedLine)
        {
            Command command = this.BuildCommand(trimmedLine);

            if (command.BookId != null)
            {
                this.Commands.Add(new ReturnBookCommand(command.FamilyName, command.Id, command.BookId));
            }
            else
            {
                this.Commands.Add(new DeleteExistingMemberCommand(command.FamilyName, command.Id));
            }
        }

        public void QuestionIdentifier(string trimmedLine)
        {
            Query query = new Query(trimmedLine.Split(' ')[1]);
            if (query.Act == "!")
            {
                this.Queries.Add(new GetTopMembersQuery());
            }
            else if (!query.Act.All(char.IsNumber))
            {
                this.Queries.Add(new GetMemberByBookQuery());
            }
            else
            {
                this.Queries.Add(new GetBooksByMemberQuery());
            }
        }

        public void Parse()
        {
            foreach (string line in this._fileReader.GetLines())
            {
                string trimmedLine = line.Trim();

                switch (trimmedLine[0])
                {
                    case '+':
                        this.PlusIdentifier(trimmedLine);
                        break;

                    case '-':
                        this.MinusIdentifier(trimmedLine);
                        break;

                    case '?':
                        this.QuestionIdentifier(trimmedLine);
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
