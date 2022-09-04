using System.Data;
using System.Data.Common;

namespace EConnectUnitTests.Mockups
{
    public class MockDbTransaction : DbTransaction
    {
        public override IsolationLevel IsolationLevel { get; }

        protected override DbConnection DbConnection => null;

        public override void Commit()
        {
            
        }

        public override void Rollback()
        {
            
        }
    }
}
