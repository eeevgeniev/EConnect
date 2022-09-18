using System;
using System.Collections;
using System.Data.Common;

namespace SQLEConnectUnitTests.Mockups
{
    public class MockDbParameterCollection : DbParameterCollection
    {
        public override int Count => 0;

        public override object SyncRoot => new object();

        public override int Add(object value) => 1;

        public override void AddRange(Array values)
        {
            
        }

        public override void Clear()
        {
            
        }

        public override bool Contains(object value) => false;

        public override bool Contains(string value) => false;

        public override void CopyTo(Array array, int index)
        {
            
        }

        public override IEnumerator GetEnumerator() => null;

        public override int IndexOf(object value) => 1;

        public override int IndexOf(string parameterName) => 1;

        public override void Insert(int index, object value)
        {
            
        }

        public override void Remove(object value)
        {
            
        }

        public override void RemoveAt(int index)
        {
            
        }

        public override void RemoveAt(string parameterName)
        {
            
        }

        protected override DbParameter GetParameter(int index) => null;

        protected override DbParameter GetParameter(string parameterName) => null;

        protected override void SetParameter(int index, DbParameter value)
        {
            
        }

        protected override void SetParameter(string parameterName, DbParameter value)
        {
            
        }
    }
}
