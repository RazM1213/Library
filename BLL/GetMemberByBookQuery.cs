using System;
using Common;
using DAL;

namespace BLL
{
    public class GetMemberByBookQuery : IQuery
    {
        public string Act { get; set; }

        public GetMemberByBookQuery(string act)
        {
            this.Act = act;
        }

        public void RunQuery()
        {
            SqlServerManager sqlServerManager =
                new SqlServerManager(
                    @"data source=LAPTOP-EHGIB3LB\SQLEXPRESS;initial catalog=Northwind;trusted_connection=true");
            sqlServerManager.Read(String.Format("SELECT MemberID FROM Books WHERE BookID='{0}'", this.Act));
        }
    }
}
