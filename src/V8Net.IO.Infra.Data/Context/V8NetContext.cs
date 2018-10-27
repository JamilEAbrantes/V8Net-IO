using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace V8Net.IO.Infra.Data.Context
{
    public class V8NetContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public V8NetContext()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            Connection = new SqlConnection(config.GetConnectionString("DefaultConnection"));
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}
