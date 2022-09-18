using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace SQLEConnectUnitTests.Mockups
{
    public class MockDbCommand : DbCommand
    {
        private List<List<Dictionary<string, object>>> _results;
        private MockDbParameterCollection _dbParameterCollection = new MockDbParameterCollection();

        public MockDbCommand(List<List<Dictionary<string, object>>> results)
        {
            _results = results ?? new List<List<Dictionary<string, object>>>();
        }

        public override string CommandText { get; set; }
        
        public override int CommandTimeout { get; set; }
        
        public override CommandType CommandType { get; set; }
        
        public override bool DesignTimeVisible { get; set; }
        
        public override UpdateRowSource UpdatedRowSource { get; set; }
        
        protected override DbConnection DbConnection { get; set; }

        protected override DbParameterCollection DbParameterCollection => _dbParameterCollection;

        protected override DbTransaction DbTransaction { get; set; }

        public override void Cancel()
        {
            
        }

        public override int ExecuteNonQuery() => 1;

        public override object ExecuteScalar() => null;

        public override void Prepare()
        {
           
        }

        protected override DbParameter CreateDbParameter() => null;

        protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior)
        {
            return new MockDbDataReader(this._results);
        }
    }
}
