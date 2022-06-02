using System;
using System.Data.SqlClient;

namespace DAL
{
    public class Program
    {
        static void Main(string[] args)
        { 
            FileReader fileReader = new FileReader(@"Utils\Commands.txt");
            fileReader.PrintLines();

            SqlServerManager sqlServerManager =
                new SqlServerManager(
                    @"data source=LAPTOP-EHGIB3LB\SQLEXPRESS;initial catalog=Northwind;trusted_connection=true");

            sqlServerManager.Read("SELECT LastName, FirstName FROM Employees");

        }
    }
}
