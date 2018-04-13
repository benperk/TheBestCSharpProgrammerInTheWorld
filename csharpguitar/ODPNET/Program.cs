using System;
using Oracle.DataAccess.Client;
using static System.Console;

namespace NoOraClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //You need to enter a valid Oracle connection string, below is the format
            string connectionString = "user id=USERID;password=PASSWORD;" +
                "data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=IPorSERVERNAME)" +
                "(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ValidSID)))";

            using (OracleConnection connection = new OracleConnection())
            {
                connection.ConnectionString = connectionString;

                try
                {
                    connection.Open();
                    WriteLine("Connection Successful!");
                    ReadLine();  // stops the console from closing until you hit the ENTER key
                }
                catch (OracleException ex)
                {
                    WriteLine(ex.ToString());
                    ReadLine();  // stops the console from closing until you hit the ENTER key
                }
            }            
        }
    }
}
