using System;
using System.Data.SqlClient;

namespace DAL
{
    public class SqlServerManager
    {
        public string QueryString { get; set; }
        public SqlCommand SqlCommand { get; set; }
        private string _connectionString;
        private SqlConnection _sqlConnection;
        private SqlDataReader _reader;

        public SqlServerManager(string connectionString)
        {
            this._connectionString = connectionString;
            this._sqlConnection = new SqlConnection(this._connectionString);
        }

        public void Read(string queryString)
        {

            this.QueryString = queryString;

            using (this._sqlConnection)
            {
                this.SqlCommand = new SqlCommand(this.QueryString, this._sqlConnection);
                this._sqlConnection.Open();
                this._reader = this.SqlCommand.ExecuteReader();
                try
                {
                    while (this._reader.Read())
                    {
                        Console.WriteLine(this._reader.GetValue(0));
                    }
                }
                finally
                {
                    this._reader.Close();
                }
            }
        }

        public void Transact(string commandString)
        {
            this.QueryString = commandString;

            using (this._sqlConnection)
            {
                this.SqlCommand = new SqlCommand(this.QueryString, this._sqlConnection);
                this._sqlConnection.Open();
                try
                {
                    this.SqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
