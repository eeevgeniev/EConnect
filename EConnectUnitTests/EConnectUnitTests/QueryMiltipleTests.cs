using EConnect;
using EConnectUnitTests.Mockups;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EConnectUnitTests
{
    [TestClass]
    public class QueryMiltipleTests
    {
        private const string WHITE_SPACE = " ";
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void QueryMultipleTwoParametersThrowsExceptionIfQueryIsNull()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte>(null, null));
        }

        [TestMethod]
        public void QueryMultipleTwoParametersThrowsExceptionIfQueryIsStringEmpty()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte>(string.Empty, null));
        }

        [TestMethod]
        public void QueryMultipleTwoParametersThrowsExceptionIfQueryIsWhiteSpace()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncTwoParametersThrowsExceptionIfQueryIsNull()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte>(null, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncTwoParametersThrowsExceptionIfQueryIsStringEmpty()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte>(string.Empty, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncTwoParametersThrowsExceptionIfQueryIsWhiteSpace()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleTwoParametersThrowsExceptionIfConnectionWasDisposed()
        {
            Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);
            connection.Dispose();

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncTwoParametersThrowsExceptionIfConnectionWasDisposed()
        {
            Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);
            connection.Dispose();

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleThreeParametersThrowsExceptionIfQueryIsNull()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short>(null, null));
        }

        [TestMethod]
        public void QueryMultipleThreeParametersThrowsExceptionIfQueryIsStringEmpty()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short>(string.Empty, null));
        }

        [TestMethod]
        public void QueryMultipleThreeParametersThrowsExceptionIfQueryIsWhiteSpace()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncThreeParametersThrowsExceptionIfQueryIsNull()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short>(null, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncThreeParametersThrowsExceptionIfQueryIsStringEmpty()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short>(string.Empty, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncThreeParametersThrowsExceptionIfQueryIsWhiteSpace()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleThreeParametersThrowsExceptionIfConnectionWasDisposed()
        {
            Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);
            connection.Dispose();

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncThreeParametersThrowsExceptionIfConnectionWasDisposed()
        {
            Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);
            connection.Dispose();

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleFourParametersThrowsExceptionIfQueryIsNull()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short, int>(null, null));
        }

        [TestMethod]
        public void QueryMultipleFourParametersThrowsExceptionIfQueryIsStringEmpty()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short, int>(string.Empty, null));
        }

        [TestMethod]
        public void QueryMultipleFourParametersThrowsExceptionIfQueryIsWhiteSpace()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short, int>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncFourParametersThrowsExceptionIfQueryIsNull()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short, int>(null, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncFourParametersThrowsExceptionIfQueryIsStringEmpty()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short, int>(string.Empty, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncFourParametersThrowsExceptionIfQueryIsWhiteSpace()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short, int>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleFourParametersThrowsExceptionIfConnectionWasDisposed()
        {
            Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);
            connection.Dispose();

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short, int>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncFourParametersThrowsExceptionIfConnectionWasDisposed()
        {
            Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);
            connection.Dispose();

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short, int>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleFiveParametersThrowsExceptionIfQueryIsNull()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short, int, byte>(null, null));
        }

        [TestMethod]
        public void QueryMultipleFiveParametersThrowsExceptionIfQueryIsStringEmpty()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short, int, byte>(string.Empty, null));
        }

        [TestMethod]
        public void QueryMultipleFiveParametersThrowsExceptionIfQueryIsWhiteSpace()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short, int, byte>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncFiveParametersThrowsExceptionIfQueryIsNull()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short, int, byte>(null, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncFiveParametersThrowsExceptionIfQueryIsStringEmpty()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short, int, byte>(string.Empty, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncFiveParametersThrowsExceptionIfQueryIsWhiteSpace()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short, int, byte>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleFiveParametersThrowsExceptionIfConnectionWasDisposed()
        {
            Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);
            connection.Dispose();

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short, int, byte>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncFiveParametersThrowsExceptionIfConnectionWasDisposed()
        {
            Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);
            connection.Dispose();

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short, int, byte>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleSixParametersThrowsExceptionIfQueryIsNull()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short, int, byte, short>(null, null));
        }

        [TestMethod]
        public void QueryMultipleSixParametersThrowsExceptionIfQueryIsStringEmpty()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short, int, byte, short>(string.Empty, null));
        }

        [TestMethod]
        public void QueryMultipleSixParametersThrowsExceptionIfQueryIsWhiteSpace()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short, int, byte, short>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncSixParametersThrowsExceptionIfQueryIsNull()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short, int, byte, short>(null, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncSixParametersThrowsExceptionIfQueryIsStringEmpty()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short, int, byte, short>(string.Empty, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncSixParametersThrowsExceptionIfQueryIsWhiteSpace()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short, int, byte, short>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleSixParametersThrowsExceptionIfConnectionWasDisposed()
        {
            Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);
            connection.Dispose();

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short, int, byte, short>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncSixParametersThrowsExceptionIfConnectionWasDisposed()
        {
            Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);
            connection.Dispose();

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short, int, byte, short>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleSevenParametersThrowsExceptionIfQueryIsNull()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short, int, byte, short, int>(null, null));
        }

        [TestMethod]
        public void QueryMultipleSevenParametersThrowsExceptionIfQueryIsStringEmpty()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short, int, byte, short, int>(string.Empty, null));
        }

        [TestMethod]
        public void QueryMultipleSevenParametersThrowsExceptionIfQueryIsWhiteSpace()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short, int, byte, short, int>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncSevenParametersThrowsExceptionIfQueryIsNull()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short, int, byte, short, int>(null, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncSevenParametersThrowsExceptionIfQueryIsStringEmpty()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short, int, byte, short, int>(string.Empty, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncSevenParametersThrowsExceptionIfQueryIsWhiteSpace()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short, int, byte, short, int>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleSevenParametersThrowsExceptionIfConnectionWasDisposed()
        {
            Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);
            connection.Dispose();

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short, int, byte, short, int>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncSevenParametersThrowsExceptionIfConnectionWasDisposed()
        {
            Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);
            connection.Dispose();

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short, int, byte, short, int>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleEightParametersThrowsExceptionIfQueryIsNull()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short, int, byte, short, int, byte>(null, null));
        }

        [TestMethod]
        public void QueryMultipleEightParametersThrowsExceptionIfQueryIsStringEmpty()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short, int, byte, short, int, byte>(string.Empty, null));
        }

        [TestMethod]
        public void QueryMultipleEightParametersThrowsExceptionIfQueryIsWhiteSpace()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short, int, byte, short, int, byte>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncEightParametersThrowsExceptionIfQueryIsNull()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short, int, byte, short, int, byte>(null, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncEightParametersThrowsExceptionIfQueryIsStringEmpty()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short, int, byte, short, int, byte>(string.Empty, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncEightParametersThrowsExceptionIfQueryIsWhiteSpace()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short, int, byte, short, int, byte>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleEightParametersThrowsExceptionIfConnectionWasDisposed()
        {
            Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);
            connection.Dispose();

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short, int, byte, short, int, byte>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncEightParametersThrowsExceptionIfConnectionWasDisposed()
        {
            Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);
            connection.Dispose();

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short, int, byte, short, int, byte>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleNineParametersThrowsExceptionIfQueryIsNull()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short, int, byte, short, int, byte, short>(null, null));
        }

        [TestMethod]
        public void QueryMultipleNineParametersThrowsExceptionIfQueryIsStringEmpty()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short, int, byte, short, int, byte, short>(string.Empty, null));
        }

        [TestMethod]
        public void QueryMultipleNineParametersThrowsExceptionIfQueryIsWhiteSpace()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short, int, byte, short, int, byte, short>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncNineParametersThrowsExceptionIfQueryIsNull()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short, int, byte, short, int, byte, short>(null, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncNineParametersThrowsExceptionIfQueryIsStringEmpty()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short, int, byte, short, int, byte, short>(string.Empty, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncNineParametersThrowsExceptionIfQueryIsWhiteSpace()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short, int, byte, short, int, byte, short>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleNineParametersThrowsExceptionIfConnectionWasDisposed()
        {
            Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);
            connection.Dispose();

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short, int, byte, short, int, byte, short>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncNineParametersThrowsExceptionIfConnectionWasDisposed()
        {
            Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);
            connection.Dispose();

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short, int, byte, short, int, byte, short>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleTenParametersThrowsExceptionIfQueryIsNull()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short, int, byte, short, int, byte, short, int>(null, null));
        }

        [TestMethod]
        public void QueryMultipleTenParametersThrowsExceptionIfQueryIsStringEmpty()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short, int, byte, short, int, byte, short, int>(string.Empty, null));
        }

        [TestMethod]
        public void QueryMultipleTenParametersThrowsExceptionIfQueryIsWhiteSpace()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short, int, byte, short, int, byte, short, int>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncTenParametersThrowsExceptionIfQueryIsNull()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short, int, byte, short, int, byte, short, int>(null, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncTenParametersThrowsExceptionIfQueryIsStringEmpty()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short, int, byte, short, int, byte, short, int>(string.Empty, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncTenParametersThrowsExceptionIfQueryIsWhiteSpace()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short, int, byte, short, int, byte, short, int>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleTeneParametersThrowsExceptionIfConnectionWasDisposed()
        {
            Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);
            connection.Dispose();

            Assert.ThrowsException<Exception>(() => connection.QueryMultiple<int, byte, short, int, byte, short, int, byte, short, int>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryMultipleAsyncTenParametersThrowsExceptionIfConnectionWasDisposed()
        {
            Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);
            connection.Dispose();

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryMultipleAsync<int, byte, short, int, byte, short, int, byte, short, int>(WHITE_SPACE, null));
        }
    }
}
