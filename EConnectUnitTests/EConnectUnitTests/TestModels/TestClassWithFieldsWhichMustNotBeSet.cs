namespace EConnectUnitTests.TestModels
{
    public class TestClassWithFieldsWhichMustNotBeSet
    {
        public short GetIsShort() => this.IsShort;

        public int GetIsInteger() => this.IsInteger;

        public byte IsByte;

        internal byte? IsNullableByte;

        private short IsShort;

        protected int IsInteger;

        protected internal long IsLong;
    }
}
