namespace EConnectUnitTests.TestModels
{
    public class TestClassWithPropertiesNoDefaultConstructor : TestClassWithProperties
    {
        public TestClassWithPropertiesNoDefaultConstructor(string isString)
        {
            this.IsString = isString;
        }
    }
}
