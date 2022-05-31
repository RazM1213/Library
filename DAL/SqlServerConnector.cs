using System;
using System.Data.SqlClient;

namespace DAL
{
    public class SqlServerConnector
    {
        private SqlConnection _connectionObject;
        private SqlCommand _commandObject;
        private string _connectionString;
        private string _commandString;

        public SqlServerConnector(string connectionString, string commandString)
        {
            this._connectionString = connectionString;
            this._commandString = commandString;
            this._connectionObject = new SqlConnection(this._connectionString);
            this._commandObject = new SqlCommand(this._commandString, this._connectionObject);
        }

        public void OpenConnection()
        {
            this._connectionObject.Open();
        }
    }
}
