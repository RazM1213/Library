using System;
using Common;
using DAL;

namespace BLL
{
    public class LendBookCommand : ICommand
    {
        public string FamilyName { get; set; }
        public string Id { get; set; }
        public string BookId { get; set; }

        public LendBookCommand(string familyName, string memberId, string bookId)
        {
            this.FamilyName = familyName;
            this.Id = memberId;
            this.BookId = bookId;
        }

        public void RunCommand()
        {
            SqlServerManager sqlServerManager =
                new SqlServerManager(
                    @"data source=LAPTOP-EHGIB3LB\SQLEXPRESS;initial catalog=Northwind;trusted_connection=true");

            sqlServerManager.Transact(String.Format("UPDATE Books SET MemberID={0} WHERE BookID='{1}'", this.Id, this.BookId));
        }
    }
}
