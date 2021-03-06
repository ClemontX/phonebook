using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;

namespace Phonebook.Source.PeopleSoft.Services
{
    public class DataService : IDataService
    {
        private readonly OracleConnection connection;

        public OracleConnection Connection => connection;

        public DataService(OracleConnectionStringBuilder builder) : this(builder.ConnectionString)
        {

        }

        public DataService(string connectionString)
        {
            connection = new OracleConnection(connectionString);
        }

        public OracleCommand CreateEmptyCommand()
        {
            return connection.CreateCommand();
        }
        public IEnumerable<IEnumerable<string>> runCommand(OracleCommand command)
        {
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var allfields = reader.VisibleFieldCount;
                var row = new List<string>();
                for (int i = 0; i < allfields; i++)
                {
                    row.Add(reader.GetString(i));
                }
                yield return row;
            }
        }

        public IEnumerable<IEnumerable<string>> runCommand(string textCommand)
        {
            var command = connection.CreateCommand();
            command.CommandText = textCommand;
            return runCommand(command);
        }

        public void Dispose()
        {
            connection.Close();
            connection.Dispose();
        }

    }
}