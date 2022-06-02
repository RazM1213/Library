using System;
using Common;
using DAL;

namespace BLL
{
    public class GetBooksByMemberQuery : IQuery
    {
        public string Act { get; set; }

        public GetBooksByMemberQuery(string act)
        {
            this.Act = act;
        }

        public void RunQuery()
        {
            SqlServerManager sqlServerManager =
                new SqlServerManager(
                    @"data source=LAPTOP-EHGIB3LB\SQLEXPRESS;initial catalog=Northwind;trusted_connection=true");
            sqlServerManager.Read(String.Format("SELECT * FROM Books WHERE MemberID='{0}'", this.Act));

        }
    }
}
