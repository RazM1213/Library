using System;
using System.Data.SqlClient;
using Common;
using DAL;

namespace BLL
{
    public class CreateNewMemberCommand : ICommand
    {
        public string FamilyName { get; set; }
        public string Id { get; set; }

        public CreateNewMemberCommand(string familyName, string memberId)
        {
            this.FamilyName = familyName;
            this.Id = memberId;
        }

        public void RunCommand()
        {
            SqlServerManager sqlServerManager =
                new SqlServerManager(
                    @"data source=LAPTOP-EHGIB3LB\SQLEXPRESS;initial catalog=Northwind;trusted_connection=true");

            sqlServerManager.Transact(String.Format("INSERT INTO Members VALUES ({0},'{1}')", this.Id, this.FamilyName));
        }
    }
}
    