namespace EConnectUnitTests.TestModels
{
    public class TestClassWithPropertiesWhichMustNotBeSet
    {
        public short GetIsShort() => this.IsShort;

        public int GetIsInteger() => this.IsInteger;

        public byte IsByte { get; set; }

        internal byte? IsNullableByte { get; set; }

        private short IsShort { get; set; }

        protected int IsInteger { get; set; }

        protected internal long IsLong { get; set; }
    }
}
