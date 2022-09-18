namespace SQLEConnectUnitTests.TestModels
{
    public class TestClassWithPropertiesNoDefaultConstructor : TestClassWithProperties
    {
        public TestClassWithPropertiesNoDefaultConstructor(string isString)
        {
            this.IsString = isString;
        }
    }
}
