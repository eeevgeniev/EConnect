using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace SQLEConnectUnitTests.Mockups
{
    public class MockDbConnection : DbConnection
    {
        private static List<List<Dictionary<string, object>>> results = new List<List<Dictionary<string, object>>>();

        public static void ClearResults()
        {
            results = new List<List<Dictionary<string, object>>>();
        }

        public static void AddResults(List<List<Dictionary<string, object>>> values)
        {
            results = values ?? new List<List<Dictionary<string, object>>>();
        }

        public override string ConnectionString { get; set; }

        public override string Database { get; }

        public override string DataSource { get; }

        public override string ServerVersion { get; }

        public override ConnectionState State { get; }

        public override void ChangeDatabase(string databaseName)
        {
            
        }

        public override void Close()
        {

        }

        public override void Open()
        {

        }

        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            return new MockDbTransaction();
        }

        protected override DbCommand CreateDbCommand()
        {
            return new MockDbCommand(results);
        }
    }
}
