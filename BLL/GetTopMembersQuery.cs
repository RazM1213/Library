using System;
using Common;
using DAL;

namespace BLL
{
    public class GetTopMembersQuery : IQuery
    {
        public string Act { get; set; }

        public GetTopMembersQuery(string act)
        {
            this.Act = act;
        }

        public void RunQuery()
        {
            SqlServerManager sqlServerManager =
                new SqlServerManager(
                    @"data source=LAPTOP-EHGIB3LB\SQLEXPRESS;initial catalog=Northwind;trusted_connection=true");
            sqlServerManager.Read("SELECT MemberID, COUNT(BookID) AS 'NumberOfBooks' FROM Books WHERE MemberID IS NOT NULL GROUP BY MemberID ORDER BY MemberID");
        }
    }
}
