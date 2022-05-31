using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public interface ICommand
    {
        string FamilyName { get; set; }
        string Id { get; set; }
        string BookId { get; set; }

        void RunCommand();
    }
}
