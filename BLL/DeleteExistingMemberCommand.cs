using System;
using Common;
using DAL;

namespace BLL
{
    public class DeleteExistingMemberCommand : ICommand
    {
        public string FamilyName { get; set; }
        public string Id { get; set; }

        public DeleteExistingMemberCommand(string familyName, string memberId)
        {
            this.FamilyName = familyName;
            this.Id = memberId;
        }

        public void RunCommand()
        {
            SqlServerManager sqlServerManager =
                new SqlServerManager(
                    @"data source=LAPTOP-EHGIB3LB\SQLEXPRESS;initial catalog=Northwind;trusted_connection=true");

            sqlServerManager.Transact(String.Format("DELETE FROM Members WHERE MemberID={0}", this.Id));
        }
    }
}
