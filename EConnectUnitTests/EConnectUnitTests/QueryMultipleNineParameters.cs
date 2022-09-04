using EConnect;
using EConnectUnitTests.Mockups;
using EConnectUnitTests.TestModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace EConnectUnitTests
{
    [TestClass]
    public class QueryMultipleNineParameters
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void QueryMultipleNineParametersReturnsTupleOfEmptyList()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>(),
                new List<Dictionary<string, object>>(),
                new List<Dictionary<string, object>>(),
                new List<Dictionary<string, object>>(),
                new List<Dictionary<string, object>>(),
                new List<Dictionary<string, object>>(),
                new List<Dictionary<string, object>>(),
                new List<Dictionary<string, object>>(),
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (List<int> firstResult, List<int> secondResult, List<int> thirdResult, List<int> fourthResult, List<int> fifthResult, List<int> sixthResult, List<int> seventhResult, List<int> eightResult, List<int> ninthResult) = connection.QueryMultiple<int, int, int, int, int, int, int, int, int>(QUERY, null);

            Assert.AreEqual(0, firstResult.Count);
            Assert.AreEqual(0, secondResult.Count);
            Assert.AreEqual(0, thirdResult.Count);
            Assert.AreEqual(0, fourthResult.Count);
            Assert.AreEqual(0, fifthResult.Count);
            Assert.AreEqual(0, sixthResult.Count);
            Assert.AreEqual(0, seventhResult.Count);
            Assert.AreEqual(0, eightResult.Count);
            Assert.AreEqual(0, ninthResult.Count);
        }

        [TestMethod]
        public void QueryMultipleAsyncNineParametersReturnsTupleOfEmptyList()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>(),
                new List<Dictionary<string, object>>(),
                new List<Dictionary<string, object>>(),
                new List<Dictionary<string, object>>(),
                new List<Dictionary<string, object>>(),
                new List<Dictionary<string, object>>(),
                new List<Dictionary<string, object>>(),
                new List<Dictionary<string, object>>(),
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (List<int> firstResult, List<int> secondResult, List<int> thirdResult, List<int> fourthResult, List<int> fifthResult, List<int> sixthResult, List<int> seventhResult, List<int> eightResult, List<int> ninthResult) = connection.QueryMultipleAsync<int, int, int, int, int, int, int, int, int>(QUERY, null).Result;

            Assert.AreEqual(0, firstResult.Count);
            Assert.AreEqual(0, secondResult.Count);
            Assert.AreEqual(0, thirdResult.Count);
            Assert.AreEqual(0, fourthResult.Count);
            Assert.AreEqual(0, fifthResult.Count);
            Assert.AreEqual(0, sixthResult.Count);
            Assert.AreEqual(0, seventhResult.Count);
            Assert.AreEqual(0, eightResult.Count);
            Assert.AreEqual(0, ninthResult.Count);
        }

        [TestMethod]
        public void QueryMultipleNineParametersDictionaryReturnsValues()
        {
            string firstKey = "firstkey";
            string secondKey = "secondkey";

            int intFirstValue = 2;
            string stringFirstValue = "test";

            int intSecondValue = 3;
            string stringSecondValue = "another test";

            int intThirdValue = 4;
            string stringThirdValue = "third test";

            int intFourthValue = 5;
            string stringFourthValue = "fourth test";

            int intFifthValue = 6;
            string stringFifthValue = "fifth test";

            int intSixthValue = 7;
            string stringSixthValue = "sixth test";

            int intSeventhValue = 8;
            string stringSeventhValue = "seventh test";

            int intEightValue = 9;
            string stringEightValue = "eight test";

            int intNinthValue = 9;
            string stringNinthValue = "ninth test";

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { firstKey, intFirstValue },
                        { secondKey, stringFirstValue }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { firstKey, intSecondValue },
                        { secondKey, stringSecondValue }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { firstKey, intThirdValue },
                        { secondKey, stringThirdValue }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { firstKey, intFourthValue },
                        { secondKey, stringFourthValue }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { firstKey, intFifthValue },
                        { secondKey, stringFifthValue }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { firstKey, intSixthValue },
                        { secondKey, stringSixthValue }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { firstKey, intSeventhValue },
                        { secondKey, stringSeventhValue }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { firstKey, intEightValue },
                        { secondKey, stringEightValue }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { firstKey, intNinthValue },
                        { secondKey, stringNinthValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (List<Dictionary<string, object>> firstResult,
                List<Dictionary<string, object>> secondResult,
                List<Dictionary<string, object>> thirdResult,
                List<Dictionary<string, object>> fourthResult,
                List<Dictionary<string, object>> fifthResult,
                List<Dictionary<string, object>> sixthResult,
                List<Dictionary<string, object>> seventhResult,
                List<Dictionary<string, object>> eightResult,
                List<Dictionary<string, object>> ninthResult) =
                connection.QueryMultiple<Dictionary<string, object>, Dictionary<string, object>, Dictionary<string, object>, Dictionary<string, object>, Dictionary<string, object>, Dictionary<string, object>, Dictionary<string, object>, Dictionary<string, object>, Dictionary<string, object>>(QUERY, null);

            Assert.AreEqual(1, firstResult.Count);

            Assert.IsTrue(firstResult[0].ContainsKey(firstKey));
            Assert.IsTrue(firstResult[0].ContainsKey(secondKey));

            Assert.AreEqual(intFirstValue, firstResult[0][firstKey]);
            Assert.AreEqual(stringFirstValue, firstResult[0][secondKey]);

            Assert.AreEqual(1, secondResult.Count);

            Assert.IsTrue(secondResult[0].ContainsKey(firstKey));
            Assert.IsTrue(secondResult[0].ContainsKey(secondKey));

            Assert.AreEqual(intSecondValue, secondResult[0][firstKey]);
            Assert.AreEqual(stringSecondValue, secondResult[0][secondKey]);

            Assert.AreEqual(1, thirdResult.Count);

            Assert.IsTrue(thirdResult[0].ContainsKey(firstKey));
            Assert.IsTrue(thirdResult[0].ContainsKey(secondKey));

            Assert.AreEqual(intThirdValue, thirdResult[0][firstKey]);
            Assert.AreEqual(stringThirdValue, thirdResult[0][secondKey]);

            Assert.AreEqual(1, fourthResult.Count);

            Assert.IsTrue(fourthResult[0].ContainsKey(firstKey));
            Assert.IsTrue(fourthResult[0].ContainsKey(secondKey));

            Assert.AreEqual(intFourthValue, fourthResult[0][firstKey]);
            Assert.AreEqual(stringFourthValue, fourthResult[0][secondKey]);

            Assert.AreEqual(1, fifthResult.Count);

            Assert.IsTrue(fifthResult[0].ContainsKey(firstKey));
            Assert.IsTrue(fifthResult[0].ContainsKey(secondKey));

            Assert.AreEqual(intFifthValue, fifthResult[0][firstKey]);
            Assert.AreEqual(stringFifthValue, fifthResult[0][secondKey]);

            Assert.AreEqual(1, sixthResult.Count);

            Assert.IsTrue(sixthResult[0].ContainsKey(firstKey));
            Assert.IsTrue(sixthResult[0].ContainsKey(secondKey));

            Assert.AreEqual(intSixthValue, sixthResult[0][firstKey]);
            Assert.AreEqual(stringSixthValue, sixthResult[0][secondKey]);

            Assert.AreEqual(1, seventhResult.Count);

            Assert.IsTrue(seventhResult[0].ContainsKey(firstKey));
            Assert.IsTrue(seventhResult[0].ContainsKey(secondKey));

            Assert.AreEqual(intSeventhValue, seventhResult[0][firstKey]);
            Assert.AreEqual(stringSeventhValue, seventhResult[0][secondKey]);

            Assert.AreEqual(1, eightResult.Count);

            Assert.IsTrue(eightResult[0].ContainsKey(firstKey));
            Assert.IsTrue(eightResult[0].ContainsKey(secondKey));

            Assert.AreEqual(intEightValue, eightResult[0][firstKey]);
            Assert.AreEqual(stringEightValue, eightResult[0][secondKey]);

            Assert.AreEqual(1, ninthResult.Count);

            Assert.IsTrue(ninthResult[0].ContainsKey(firstKey));
            Assert.IsTrue(ninthResult[0].ContainsKey(secondKey));

            Assert.AreEqual(intNinthValue, ninthResult[0][firstKey]);
            Assert.AreEqual(stringNinthValue, ninthResult[0][secondKey]);
        }

        [TestMethod]
        public void QueryMultipleAsyncNineParametersDictionaryReturnsValues()
        {
            string firstKey = "firstkey";
            string secondKey = "secondkey";

            int intFirstValue = 2;
            string stringFirstValue = "test";

            int intSecondValue = 3;
            string stringSecondValue = "another test";

            int intThirdValue = 4;
            string stringThirdValue = "third test";

            int intFourthValue = 5;
            string stringFourthValue = "fourth test";

            int intFifthValue = 6;
            string stringFifthValue = "fifth test";

            int intSixthValue = 7;
            string stringSixthValue = "sixth test";

            int intSeventhValue = 8;
            string stringSeventhValue = "seventh test";

            int intEightValue = 9;
            string stringEightValue = "eight test";

            int intNinthValue = 9;
            string stringNinthValue = "ninth test";

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { firstKey, intFirstValue },
                        { secondKey, stringFirstValue }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { firstKey, intSecondValue },
                        { secondKey, stringSecondValue }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { firstKey, intThirdValue },
                        { secondKey, stringThirdValue }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { firstKey, intFourthValue },
                        { secondKey, stringFourthValue }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { firstKey, intFifthValue },
                        { secondKey, stringFifthValue }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { firstKey, intSixthValue },
                        { secondKey, stringSixthValue }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { firstKey, intSeventhValue },
                        { secondKey, stringSeventhValue }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { firstKey, intEightValue },
                        { secondKey, stringEightValue }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { firstKey, intNinthValue },
                        { secondKey, stringNinthValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (List<Dictionary<string, object>> firstResult,
                List<Dictionary<string, object>> secondResult,
                List<Dictionary<string, object>> thirdResult,
                List<Dictionary<string, object>> fourthResult,
                List<Dictionary<string, object>> fifthResult,
                List<Dictionary<string, object>> sixthResult,
                List<Dictionary<string, object>> seventhResult,
                List<Dictionary<string, object>> eightResult,
                List<Dictionary<string, object>> ninthResult) =
                connection.QueryMultipleAsync<Dictionary<string, object>, Dictionary<string, object>, Dictionary<string, object>, Dictionary<string, object>, Dictionary<string, object>, Dictionary<string, object>, Dictionary<string, object>, Dictionary<string, object>, Dictionary<string, object>>(QUERY, null).Result;

            Assert.AreEqual(1, firstResult.Count);

            Assert.IsTrue(firstResult[0].ContainsKey(firstKey));
            Assert.IsTrue(firstResult[0].ContainsKey(secondKey));

            Assert.AreEqual(intFirstValue, firstResult[0][firstKey]);
            Assert.AreEqual(stringFirstValue, firstResult[0][secondKey]);

            Assert.AreEqual(1, secondResult.Count);

            Assert.IsTrue(secondResult[0].ContainsKey(firstKey));
            Assert.IsTrue(secondResult[0].ContainsKey(secondKey));

            Assert.AreEqual(intSecondValue, secondResult[0][firstKey]);
            Assert.AreEqual(stringSecondValue, secondResult[0][secondKey]);

            Assert.AreEqual(1, thirdResult.Count);

            Assert.IsTrue(thirdResult[0].ContainsKey(firstKey));
            Assert.IsTrue(thirdResult[0].ContainsKey(secondKey));

            Assert.AreEqual(intThirdValue, thirdResult[0][firstKey]);
            Assert.AreEqual(stringThirdValue, thirdResult[0][secondKey]);

            Assert.AreEqual(1, fourthResult.Count);

            Assert.IsTrue(fourthResult[0].ContainsKey(firstKey));
            Assert.IsTrue(fourthResult[0].ContainsKey(secondKey));

            Assert.AreEqual(intFourthValue, fourthResult[0][firstKey]);
            Assert.AreEqual(stringFourthValue, fourthResult[0][secondKey]);

            Assert.AreEqual(1, fifthResult.Count);

            Assert.IsTrue(fifthResult[0].ContainsKey(firstKey));
            Assert.IsTrue(fifthResult[0].ContainsKey(secondKey));

            Assert.AreEqual(intFifthValue, fifthResult[0][firstKey]);
            Assert.AreEqual(stringFifthValue, fifthResult[0][secondKey]);

            Assert.AreEqual(1, sixthResult.Count);

            Assert.IsTrue(sixthResult[0].ContainsKey(firstKey));
            Assert.IsTrue(sixthResult[0].ContainsKey(secondKey));

            Assert.AreEqual(intSixthValue, sixthResult[0][firstKey]);
            Assert.AreEqual(stringSixthValue, sixthResult[0][secondKey]);

            Assert.AreEqual(1, seventhResult.Count);

            Assert.IsTrue(seventhResult[0].ContainsKey(firstKey));
            Assert.IsTrue(seventhResult[0].ContainsKey(secondKey));

            Assert.AreEqual(intSeventhValue, seventhResult[0][firstKey]);
            Assert.AreEqual(stringSeventhValue, seventhResult[0][secondKey]);

            Assert.AreEqual(1, eightResult.Count);

            Assert.IsTrue(eightResult[0].ContainsKey(firstKey));
            Assert.IsTrue(eightResult[0].ContainsKey(secondKey));

            Assert.AreEqual(intEightValue, eightResult[0][firstKey]);
            Assert.AreEqual(stringEightValue, eightResult[0][secondKey]);

            Assert.AreEqual(1, ninthResult.Count);

            Assert.IsTrue(ninthResult[0].ContainsKey(firstKey));
            Assert.IsTrue(ninthResult[0].ContainsKey(secondKey));

            Assert.AreEqual(intNinthValue, ninthResult[0][firstKey]);
            Assert.AreEqual(stringNinthValue, ninthResult[0][secondKey]);
        }

        [TestMethod]
        public void QueryMultipleNineParametersBoolAndBytesAndCharAndByteAndCharsAndDateTimeAndDecimalAndDoubleAndIntReturnsValues()
        {
            bool boolValue = true;
            byte[] byteValues = { 2, 4, 8, 16 };
            char charValue = 'e';
            byte byteValue = 21;
            char[] charValues = { 'f', 'g', 'h' };
            DateTime dateTimeValue = DateTime.Now;
            decimal decimalValue = 21.6M;
            double doubleValue = 33.6D;
            int intValue = 331;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "bool", boolValue },
                        { "not a bool", 22 }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "bytes", byteValues },
                        { "not bytes", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "char", charValue },
                        { "not a char", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "byte", byteValue },
                        { "not a byte", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "chars", charValues },
                        { "not chars", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "datetime", dateTimeValue },
                        { "not a datetime", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "decimal", decimalValue },
                        { "not a decimal", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "double", doubleValue },
                        { "not a double", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "int", intValue },
                        { "not a int", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (List<bool> boolResults,
                List<byte[]> bytesResults,
                List<char> charResults,
                List<byte> byteResults,
                List<char[]> charsResults,
                List<DateTime> dateTimeResults,
                List<decimal> decimalResults,
                List<double> doubleResults,
                List<int> intResults) = connection.QueryMultiple<bool, byte[], char, byte, char[], DateTime, decimal, double, int>(QUERY, null);

            Assert.AreEqual(1, boolResults.Count);

            Assert.AreEqual(boolValue, boolResults[0]);

            Assert.AreEqual(1, byteResults.Count);

            Assert.AreEqual(byteValues.Length, bytesResults[0].Length);

            for (int i = 0; i < byteValues.Length; i++)
            {
                Assert.AreEqual(byteValues[i], bytesResults[0][i]);
            }

            Assert.AreEqual(1, charResults.Count);

            Assert.AreEqual(charValue, charResults[0]);

            Assert.AreEqual(1, byteResults.Count);

            Assert.AreEqual(byteValue, byteResults[0]);

            Assert.AreEqual(1, charsResults.Count);

            Assert.AreEqual(charValues.Length, charsResults[0].Length);

            for (int i = 0; i < charValues.Length; i++)
            {
                Assert.AreEqual(charValues[i], charsResults[0][i]);
            }

            Assert.AreEqual(1, dateTimeResults.Count);

            Assert.AreEqual(dateTimeValue, dateTimeResults[0]);

            Assert.AreEqual(1, decimalResults.Count);

            Assert.AreEqual(decimalValue, decimalResults[0]);

            Assert.AreEqual(1, doubleResults.Count);

            Assert.AreEqual(doubleValue, doubleResults[0]);

            Assert.AreEqual(1, intResults.Count);

            Assert.AreEqual(intValue, intResults[0]);
        }

        [TestMethod]
        public void QueryMultipleAsyncNineParametersBoolAndBytesAndCharAndByteAndCharsAndDateTimeAndDecimalAndDoubleAndIntReturnsValues()
        {
            bool boolValue = true;
            byte[] byteValues = { 2, 4, 8, 16 };
            char charValue = 'e';
            byte byteValue = 21;
            char[] charValues = { 'f', 'g', 'h' };
            DateTime dateTimeValue = DateTime.Now;
            decimal decimalValue = 21.6M;
            double doubleValue = 33.6D;
            int intValue = 331;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "bool", boolValue },
                        { "not a bool", 22 }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "bytes", byteValues },
                        { "not bytes", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "char", charValue },
                        { "not a char", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "byte", byteValue },
                        { "not a byte", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "chars", charValues },
                        { "not chars", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "datetime", dateTimeValue },
                        { "not a datetime", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "decimal", decimalValue },
                        { "not a decimal", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "double", doubleValue },
                        { "not a double", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "int", intValue },
                        { "not a int", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (List<bool> boolResults,
                List<byte[]> bytesResults,
                List<char> charResults,
                List<byte> byteResults,
                List<char[]> charsResults,
                List<DateTime> dateTimeResults,
                List<decimal> decimalResults,
                List<double> doubleResults,
                List<int> intResults) = connection.QueryMultipleAsync<bool, byte[], char, byte, char[], DateTime, decimal, double, int>(QUERY, null).Result;

            Assert.AreEqual(1, boolResults.Count);

            Assert.AreEqual(boolValue, boolResults[0]);

            Assert.AreEqual(1, byteResults.Count);

            Assert.AreEqual(byteValues.Length, bytesResults[0].Length);

            for (int i = 0; i < byteValues.Length; i++)
            {
                Assert.AreEqual(byteValues[i], bytesResults[0][i]);
            }

            Assert.AreEqual(1, charResults.Count);

            Assert.AreEqual(charValue, charResults[0]);

            Assert.AreEqual(1, byteResults.Count);

            Assert.AreEqual(byteValue, byteResults[0]);

            Assert.AreEqual(1, charsResults.Count);

            Assert.AreEqual(charValues.Length, charsResults[0].Length);

            for (int i = 0; i < charValues.Length; i++)
            {
                Assert.AreEqual(charValues[i], charsResults[0][i]);
            }

            Assert.AreEqual(1, dateTimeResults.Count);

            Assert.AreEqual(dateTimeValue, dateTimeResults[0]);

            Assert.AreEqual(1, decimalResults.Count);

            Assert.AreEqual(decimalValue, decimalResults[0]);

            Assert.AreEqual(1, doubleResults.Count);

            Assert.AreEqual(doubleValue, doubleResults[0]);

            Assert.AreEqual(1, intResults.Count);

            Assert.AreEqual(intValue, intResults[0]);
        }

        [TestMethod]
        public void QueryMultipleNineParametersDateTimeAndDecimalAndDoubleAndIntAndLongAndSByteAndShortAndStringAndUIntAndULongAndUShortAndDecimalAndDoubleReturnsValues()
        {
            long longValue = 535;
            sbyte sByteValue = 33;
            short shortValue = 55;
            string stringValue = "test";
            uint uIntValue = 121;
            ulong uLongValue = 77;
            ushort uShortValue = 35;
            decimal decimalValue = 21.6M;
            double doubleValue = 33.6D;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "long", longValue },
                        { "not a long", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "sbyte", sByteValue },
                        { "not a sbyte", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "short", shortValue },
                        { "not a short", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "string", stringValue },
                        { "not a string", 22 }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "uint", uIntValue },
                        { "not a uint", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ulong", uLongValue },
                        { "not a ulong", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ushort", uShortValue },
                        { "not a ushort", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "decimal", decimalValue },
                        { "not a decimal", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "double", doubleValue },
                        { "not a double", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (List<long> longResults,
                List<sbyte> sbyteResults,
                List<short> shortResults,
                List<string> stringResults,
                List<uint> uintResults,
                List<ulong> ulongResults,
                List<ushort> ushortResults,
                List<decimal> decimalResults,
                List<double> doubleResults) = connection.QueryMultiple<long, sbyte, short, string, uint, ulong, ushort, decimal, double>(QUERY, null);

            Assert.AreEqual(1, longResults.Count);

            Assert.AreEqual(longValue, longResults[0]);

            Assert.AreEqual(1, sbyteResults.Count);

            Assert.AreEqual(sByteValue, sbyteResults[0]);

            Assert.AreEqual(1, shortResults.Count);

            Assert.AreEqual(shortValue, shortResults[0]);

            Assert.AreEqual(1, stringResults.Count);

            Assert.AreEqual(stringValue, stringResults[0]);

            Assert.AreEqual(1, uintResults.Count);

            Assert.AreEqual(uIntValue, uintResults[0]);

            Assert.AreEqual(1, ulongResults.Count);

            Assert.AreEqual(uLongValue, ulongResults[0]);

            Assert.AreEqual(1, ushortResults.Count);

            Assert.AreEqual(uShortValue, ushortResults[0]);

            Assert.AreEqual(1, decimalResults.Count);

            Assert.AreEqual(decimalValue, decimalResults[0]);

            Assert.AreEqual(1, doubleResults.Count);

            Assert.AreEqual(doubleValue, doubleResults[0]);
        }

        [TestMethod]
        public void QueryMultipleAsyncNineParametersDateTimeAndDecimalAndDoubleAndIntAndLongAndSByteAndShortAndStringAndUIntAndULongAndUShortAndDecimalAndDoubleReturnsValues()
        {
            long longValue = 535;
            sbyte sByteValue = 33;
            short shortValue = 55;
            string stringValue = "test";
            uint uIntValue = 121;
            ulong uLongValue = 77;
            ushort uShortValue = 35;
            decimal decimalValue = 21.6M;
            double doubleValue = 33.6D;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "long", longValue },
                        { "not a long", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "sbyte", sByteValue },
                        { "not a sbyte", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "short", shortValue },
                        { "not a short", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "string", stringValue },
                        { "not a string", 22 }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "uint", uIntValue },
                        { "not a uint", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ulong", uLongValue },
                        { "not a ulong", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ushort", uShortValue },
                        { "not a ushort", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "decimal", decimalValue },
                        { "not a decimal", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "double", doubleValue },
                        { "not a double", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (List<long> longResults,
                List<sbyte> sbyteResults,
                List<short> shortResults,
                List<string> stringResults,
                List<uint> uintResults,
                List<ulong> ulongResults,
                List<ushort> ushortResults,
                List<decimal> decimalResults,
                List<double> doubleResults) = connection.QueryMultipleAsync<long, sbyte, short, string, uint, ulong, ushort, decimal, double>(QUERY, null).Result;

            Assert.AreEqual(1, longResults.Count);

            Assert.AreEqual(longValue, longResults[0]);

            Assert.AreEqual(1, sbyteResults.Count);

            Assert.AreEqual(sByteValue, sbyteResults[0]);

            Assert.AreEqual(1, shortResults.Count);

            Assert.AreEqual(shortValue, shortResults[0]);

            Assert.AreEqual(1, stringResults.Count);

            Assert.AreEqual(stringValue, stringResults[0]);

            Assert.AreEqual(1, uintResults.Count);

            Assert.AreEqual(uIntValue, uintResults[0]);

            Assert.AreEqual(1, ulongResults.Count);

            Assert.AreEqual(uLongValue, ulongResults[0]);

            Assert.AreEqual(1, ushortResults.Count);

            Assert.AreEqual(uShortValue, ushortResults[0]);

            Assert.AreEqual(1, decimalResults.Count);

            Assert.AreEqual(decimalValue, decimalResults[0]);

            Assert.AreEqual(1, doubleResults.Count);

            Assert.AreEqual(doubleValue, doubleResults[0]);
        }

        [TestMethod]
        public void QueryMultipleNineParametersStreamAndUShortAndIntAndUIntAndLongAndULongAndDecimalAndObjectWithNoConstructorAndObjectWithConstructorReturnValues()
        {
            byte[] streamValues = { 1, 2, 3, 4 };

            MemoryStream streamValue = new MemoryStream(streamValues);

            ushort uShortValue = 55;
            int intValue = 22;
            uint uIntValue = 133;
            long longValue = 121;
            ulong uLongValue = 77;
            decimal decimalValue = 21.6M;

            byte firstIsByte = 0;
            byte? firstIsNullableByte = 13;
            bool firstIsBool = true;
            bool firstIsNullableBool = false;
            byte[] firstIsBytes = { 1, 2, 3, 4 };
            char[] firstIsChars = { 'a', 'b', 'c' };
            char firstIsChar = 'z';
            char? firstIsNullableChar = 'y';
            DateTime firstIsDateTime = new DateTime(2000, 11, 2);
            DateTime? firstIsNullableDateTime = new DateTime(2002, 6, 5);
            decimal firstIsDecimal = 2m;
            decimal? firstIsNullableDecimal = 21m;
            double firstIsDouble = 2.5d;
            double? firstIsNullableDouble = 3.5d;
            float firstIsFloat = 4.5f;
            float? firstIsNullableFloat = 5.5f;
            Guid firstIsGuid = Guid.NewGuid();
            Guid? firstIsNullableGuid = Guid.NewGuid();
            int firstIsInt = 22;
            int? firstIsNullableInt = 33;
            long firstIsLong = 100;
            long? firstIsNullableLong = 101;
            sbyte firstIsSByte = 11;
            sbyte? firstIsNullableSByte = 12;
            short firstIsShort = 33;
            short? firstIsNullabelShort = 34;
            Stream firstIsStream = new MemoryStream(firstIsBytes);
            string firstIsString = "test one";
            uint firstIsUInt = 1000;
            uint? firstIsNullableUInt = 1001;
            ulong firstIsULong = 10000;
            ulong? firstIsNullableULong = 100001;
            ushort firstIsUShort = 10033;
            ushort? firstIsNullableUShort = 10034;

            byte secondIsByte = 10;
            byte? secondIsNullableByte = 113;
            bool secondIsBool = false;
            bool secondIsNullableBool = true;
            byte[] secondIsBytes = { 4, 3, 2, 1 };
            char[] secondIsChars = { 'c', 'b', 'a' };
            char secondIsChar = 'x';
            char? secondIsNullableChar = 'q';
            DateTime secondIsDateTime = new DateTime(2000, 10, 2);
            DateTime? secondIsNullableDateTime = new DateTime(2002, 1, 5);
            decimal secondIsDecimal = 12m;
            decimal? secondIsNullableDecimal = 31m;
            double secondIsDouble = 6.5d;
            double? secondIsNullableDouble = 9.5d;
            float secondIsFloat = 21.5f;
            float? secondIsNullableFloat = 14.5f;
            Guid secondIsGuid = Guid.NewGuid();
            Guid? secondIsNullableGuid = Guid.NewGuid();
            int secondIsInt = 33;
            int? secondIsNullableInt = 90;
            long secondIsLong = 110;
            long? secondIsNullableLong = 141;
            sbyte secondIsSByte = 112;
            sbyte? secondIsNullableSByte = 121;
            short secondIsShort = 42;
            short? secondIsNullabelShort = 56;
            Stream secondIsStream = new MemoryStream(secondIsBytes);
            string secondIsString = "test two";
            uint secondIsUInt = 1010;
            uint? secondIsNullableUInt = 1011;
            ulong secondIsULong = 10230;
            ulong? secondIsNullableULong = 100045;
            ushort secondIsUShort = 10144;
            ushort? secondIsNullableUShort = 10434;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "stream", streamValue },
                        { "not a stream", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ushort", uShortValue },
                        { "not a ushort", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "int", intValue },
                        { "not a int", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "uint", uIntValue },
                        { "not a uint", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "long", longValue },
                        { "not a long", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ulong", uLongValue },
                        { "not a ulong", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "decimal", decimalValue },
                        { "not a decimal", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "IsByte", firstIsByte },
                        { "IsNullableByte", firstIsNullableByte },
                        { "IsBool", firstIsBool },
                        { "IsNullableBool", firstIsNullableBool },
                        { "Bytes", firstIsBytes },
                        { "Chars", firstIsChars },
                        { "IsChar", firstIsChar },
                        { "IsNullableChar", firstIsNullableChar },
                        { "IsDateTime", firstIsDateTime },
                        { "IsNullableDateTime", firstIsNullableDateTime },
                        { "IsDecimal", firstIsDecimal },
                        { "IsNullableDecimal", firstIsNullableDecimal },
                        { "IsDouble", firstIsDouble },
                        { "IsNullableDouble", firstIsNullableDouble },
                        { "IsFloat", firstIsFloat },
                        { "IsNullableFloat", firstIsNullableFloat },
                        { "IsGuid", firstIsGuid },
                        { "IsNullableGuid", firstIsNullableGuid },
                        { "IsInt", firstIsInt },
                        { "IsNullableInt", firstIsNullableInt },
                        { "IsLong", firstIsLong },
                        { "IsNullableLong", firstIsNullableLong },
                        { "IsSByte", firstIsSByte },
                        { "IsNullableSByte", firstIsNullableSByte },
                        { "IsShort", firstIsShort },
                        { "IsNullabelShort", firstIsNullabelShort },
                        { "IsStream", firstIsStream },
                        { "IsString", firstIsString },
                        { "IsUInt", firstIsUInt },
                        { "IsNullableUInt", firstIsNullableUInt },
                        { "IsULong", firstIsULong },
                        { "IsNullableULong", firstIsNullableULong },
                        { "IsUShort", firstIsUShort },
                        { "IsNullableUShort", firstIsNullableUShort }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "IsByte", secondIsByte },
                        { "IsNullableByte", secondIsNullableByte },
                        { "IsBool", secondIsBool },
                        { "IsNullableBool", secondIsNullableBool },
                        { "Bytes", secondIsBytes },
                        { "Chars", secondIsChars },
                        { "IsChar", secondIsChar },
                        { "IsNullableChar", secondIsNullableChar },
                        { "IsDateTime", secondIsDateTime },
                        { "IsNullableDateTime", secondIsNullableDateTime },
                        { "IsDecimal", secondIsDecimal },
                        { "IsNullableDecimal", secondIsNullableDecimal },
                        { "IsDouble", secondIsDouble },
                        { "IsNullableDouble", secondIsNullableDouble },
                        { "IsFloat", secondIsFloat },
                        { "IsNullableFloat", secondIsNullableFloat },
                        { "IsGuid", secondIsGuid },
                        { "IsNullableGuid", secondIsNullableGuid },
                        { "IsInt", secondIsInt },
                        { "IsNullableInt", secondIsNullableInt },
                        { "IsLong", secondIsLong },
                        { "IsNullableLong", secondIsNullableLong },
                        { "IsSByte", secondIsSByte },
                        { "IsNullableSByte", secondIsNullableSByte },
                        { "IsShort", secondIsShort },
                        { "IsNullabelShort", secondIsNullabelShort },
                        { "IsStream", secondIsStream },
                        { "IsString", secondIsString },
                        { "IsUInt", secondIsUInt },
                        { "IsNullableUInt", secondIsNullableUInt },
                        { "IsULong", secondIsULong },
                        { "IsNullableULong", secondIsNullableULong },
                        { "IsUShort", secondIsUShort },
                        { "IsNullableUShort", secondIsNullableUShort }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (List<Stream> streamResults,
                List<ushort> ushortResults,
                List<int> intResults,
                List<uint> uintResults,
                List<long> longResults,
                List<ulong> ulongResults,
                List<decimal> decimalResults,
                List<TestClassWithProperties> results,
                List<TestClassWithFieldsNoDefaultConstructor> resultsNoConstructor) = connection.QueryMultiple<Stream, ushort, int, uint, long, ulong, decimal, TestClassWithProperties, TestClassWithFieldsNoDefaultConstructor>(QUERY, null);

            Assert.AreEqual(1, streamResults.Count);

            MemoryStream resultStream = new MemoryStream();

            streamResults[0].CopyTo(resultStream);
            resultStream.Position = 0;
            byte[] resultBytes = resultStream.ToArray();

            Assert.AreEqual(streamValues.Length, resultBytes.Length);

            for (int i = 0; i < streamValues.Length; i++)
            {
                Assert.AreEqual(streamValues[i], resultBytes[i]);
            }

            Assert.AreEqual(1, ushortResults.Count);

            Assert.AreEqual(uShortValue, ushortResults[0]);

            Assert.AreEqual(1, intResults.Count);

            Assert.AreEqual(intValue, intResults[0]);

            Assert.AreEqual(1, uintResults.Count);

            Assert.AreEqual(uIntValue, uintResults[0]);

            Assert.AreEqual(1, longResults.Count);

            Assert.AreEqual(longValue, longResults[0]);

            Assert.AreEqual(1, ulongResults.Count);

            Assert.AreEqual(uLongValue, ulongResults[0]);

            Assert.AreEqual(1, decimalResults.Count);

            Assert.AreEqual(decimalValue, decimalResults[0]);

            Assert.AreEqual(1, results.Count);

            Assert.AreEqual(firstIsByte, results[0].IsByte);
            Assert.AreEqual(firstIsNullableByte, results[0].IsNullableByte);
            Assert.AreEqual(firstIsBool, results[0].IsBool);
            Assert.AreEqual(firstIsNullableBool, results[0].IsNullableBool);

            Assert.AreEqual(firstIsBytes.Length, results[0].Bytes.Length);

            for (int i = 0; i < firstIsBytes.Length; i++)
            {
                Assert.AreEqual(firstIsBytes[i], results[0].Bytes[i]);
            }

            Assert.AreEqual(firstIsChars.Length, results[0].Chars.Length);

            for (int i = 0; i < firstIsChars.Length; i++)
            {
                Assert.AreEqual(firstIsChars[i], results[0].Chars[i]);
            }

            Assert.AreEqual(firstIsChar, results[0].IsChar);
            Assert.AreEqual(firstIsNullableChar, results[0].IsNullableChar);
            Assert.AreEqual(firstIsDateTime, results[0].IsDateTime);
            Assert.AreEqual(firstIsNullableDateTime, results[0].IsNullableDateTime);
            Assert.AreEqual(firstIsDecimal, results[0].IsDecimal);
            Assert.AreEqual(firstIsNullableDecimal, results[0].IsNullableDecimal);
            Assert.AreEqual(firstIsDouble, results[0].IsDouble);
            Assert.AreEqual(firstIsNullableDouble, results[0].IsNullableDouble);
            Assert.AreEqual(firstIsFloat, results[0].IsFloat);
            Assert.AreEqual(firstIsNullableFloat, results[0].IsNullableFloat);
            Assert.AreEqual(firstIsGuid, results[0].IsGuid);
            Assert.AreEqual(firstIsNullableGuid, results[0].IsNullableGuid);
            Assert.AreEqual(firstIsInt, results[0].IsInt);
            Assert.AreEqual(firstIsNullableInt, results[0].IsNullableInt);
            Assert.AreEqual(firstIsLong, results[0].IsLong);
            Assert.AreEqual(firstIsNullableLong, results[0].IsNullableLong);
            Assert.AreEqual(firstIsSByte, results[0].IsSByte);
            Assert.AreEqual(firstIsNullableSByte, results[0].IsNullableSByte);
            Assert.AreEqual(firstIsShort, results[0].IsShort);
            Assert.AreEqual(firstIsNullabelShort, results[0].IsNullabelShort);

            MemoryStream firstMS = new MemoryStream();
            results[0].IsStream.CopyTo(firstMS);

            byte[] firstStreamBytes = firstMS.ToArray();

            Assert.AreEqual(firstIsBytes.Length, firstStreamBytes.Length);

            for (int i = 0; i < firstIsBytes.Length; i++)
            {
                Assert.AreEqual(firstStreamBytes[i], firstIsBytes[i]);
            }

            Assert.AreEqual(firstIsString, results[0].IsString);
            Assert.AreEqual(firstIsUInt, results[0].IsUInt);
            Assert.AreEqual(firstIsNullableUInt, results[0].IsNullableUInt);
            Assert.AreEqual(firstIsULong, results[0].IsULong);
            Assert.AreEqual(firstIsNullableULong, results[0].IsNullableULong);
            Assert.AreEqual(firstIsUShort, results[0].IsUShort);
            Assert.AreEqual(firstIsNullableUShort, results[0].IsNullableUShort);

            Assert.AreEqual(1, resultsNoConstructor.Count);

            Assert.AreEqual(secondIsByte, resultsNoConstructor[0].IsByte);
            Assert.AreEqual(secondIsNullableByte, resultsNoConstructor[0].IsNullableByte);
            Assert.AreEqual(secondIsBool, resultsNoConstructor[0].IsBool);
            Assert.AreEqual(secondIsNullableBool, resultsNoConstructor[0].IsNullableBool);

            Assert.AreEqual(secondIsBytes.Length, resultsNoConstructor[0].Bytes.Length);

            for (int i = 0; i < secondIsBytes.Length; i++)
            {
                Assert.AreEqual(secondIsBytes[i], resultsNoConstructor[0].Bytes[i]);
            }

            Assert.AreEqual(secondIsChars.Length, resultsNoConstructor[0].Chars.Length);

            for (int i = 0; i < secondIsChars.Length; i++)
            {
                Assert.AreEqual(secondIsChars[i], resultsNoConstructor[0].Chars[i]);
            }

            Assert.AreEqual(secondIsChar, resultsNoConstructor[0].IsChar);
            Assert.AreEqual(secondIsNullableChar, resultsNoConstructor[0].IsNullableChar);
            Assert.AreEqual(secondIsDateTime, resultsNoConstructor[0].IsDateTime);
            Assert.AreEqual(secondIsNullableDateTime, resultsNoConstructor[0].IsNullableDateTime);
            Assert.AreEqual(secondIsDecimal, resultsNoConstructor[0].IsDecimal);
            Assert.AreEqual(secondIsNullableDecimal, resultsNoConstructor[0].IsNullableDecimal);
            Assert.AreEqual(secondIsDouble, resultsNoConstructor[0].IsDouble);
            Assert.AreEqual(secondIsNullableDouble, resultsNoConstructor[0].IsNullableDouble);
            Assert.AreEqual(secondIsFloat, resultsNoConstructor[0].IsFloat);
            Assert.AreEqual(secondIsNullableFloat, resultsNoConstructor[0].IsNullableFloat);
            Assert.AreEqual(secondIsGuid, resultsNoConstructor[0].IsGuid);
            Assert.AreEqual(secondIsNullableGuid, resultsNoConstructor[0].IsNullableGuid);
            Assert.AreEqual(secondIsInt, resultsNoConstructor[0].IsInt);
            Assert.AreEqual(secondIsNullableInt, resultsNoConstructor[0].IsNullableInt);
            Assert.AreEqual(secondIsLong, resultsNoConstructor[0].IsLong);
            Assert.AreEqual(secondIsNullableLong, resultsNoConstructor[0].IsNullableLong);
            Assert.AreEqual(secondIsSByte, resultsNoConstructor[0].IsSByte);
            Assert.AreEqual(secondIsNullableSByte, resultsNoConstructor[0].IsNullableSByte);
            Assert.AreEqual(secondIsShort, resultsNoConstructor[0].IsShort);
            Assert.AreEqual(secondIsNullabelShort, resultsNoConstructor[0].IsNullabelShort);

            MemoryStream secondMS = new MemoryStream();
            resultsNoConstructor[0].IsStream.CopyTo(secondMS);

            byte[] secondStreamBytes = secondMS.ToArray();

            Assert.AreEqual(secondIsBytes.Length, secondStreamBytes.Length);

            for (int i = 0; i < secondIsBytes.Length; i++)
            {
                Assert.AreEqual(secondIsBytes[i], secondIsBytes[i]);
            }

            Assert.AreEqual(secondIsString, resultsNoConstructor[0].IsString);
            Assert.AreEqual(secondIsUInt, resultsNoConstructor[0].IsUInt);
            Assert.AreEqual(secondIsNullableUInt, resultsNoConstructor[0].IsNullableUInt);
            Assert.AreEqual(secondIsULong, resultsNoConstructor[0].IsULong);
            Assert.AreEqual(secondIsNullableULong, resultsNoConstructor[0].IsNullableULong);
            Assert.AreEqual(secondIsUShort, resultsNoConstructor[0].IsUShort);
            Assert.AreEqual(secondIsNullableUShort, resultsNoConstructor[0].IsNullableUShort);
        }

        [TestMethod]
        public void QueryMultipleAsyncNineParametersStreamAndUShortAndIntAndUIntAndLongAndULongAndDecimalAndObjectWithNoConstructorAndObjectWithConstructorReturnValues()
        {
            byte[] streamValues = { 1, 2, 3, 4 };

            MemoryStream streamValue = new MemoryStream(streamValues);

            ushort uShortValue = 55;
            int intValue = 22;
            uint uIntValue = 133;
            long longValue = 121;
            ulong uLongValue = 77;
            decimal decimalValue = 21.6M;

            byte firstIsByte = 0;
            byte? firstIsNullableByte = 13;
            bool firstIsBool = true;
            bool firstIsNullableBool = false;
            byte[] firstIsBytes = { 1, 2, 3, 4 };
            char[] firstIsChars = { 'a', 'b', 'c' };
            char firstIsChar = 'z';
            char? firstIsNullableChar = 'y';
            DateTime firstIsDateTime = new DateTime(2000, 11, 2);
            DateTime? firstIsNullableDateTime = new DateTime(2002, 6, 5);
            decimal firstIsDecimal = 2m;
            decimal? firstIsNullableDecimal = 21m;
            double firstIsDouble = 2.5d;
            double? firstIsNullableDouble = 3.5d;
            float firstIsFloat = 4.5f;
            float? firstIsNullableFloat = 5.5f;
            Guid firstIsGuid = Guid.NewGuid();
            Guid? firstIsNullableGuid = Guid.NewGuid();
            int firstIsInt = 22;
            int? firstIsNullableInt = 33;
            long firstIsLong = 100;
            long? firstIsNullableLong = 101;
            sbyte firstIsSByte = 11;
            sbyte? firstIsNullableSByte = 12;
            short firstIsShort = 33;
            short? firstIsNullabelShort = 34;
            Stream firstIsStream = new MemoryStream(firstIsBytes);
            string firstIsString = "test one";
            uint firstIsUInt = 1000;
            uint? firstIsNullableUInt = 1001;
            ulong firstIsULong = 10000;
            ulong? firstIsNullableULong = 100001;
            ushort firstIsUShort = 10033;
            ushort? firstIsNullableUShort = 10034;

            byte secondIsByte = 10;
            byte? secondIsNullableByte = 113;
            bool secondIsBool = false;
            bool secondIsNullableBool = true;
            byte[] secondIsBytes = { 4, 3, 2, 1 };
            char[] secondIsChars = { 'c', 'b', 'a' };
            char secondIsChar = 'x';
            char? secondIsNullableChar = 'q';
            DateTime secondIsDateTime = new DateTime(2000, 10, 2);
            DateTime? secondIsNullableDateTime = new DateTime(2002, 1, 5);
            decimal secondIsDecimal = 12m;
            decimal? secondIsNullableDecimal = 31m;
            double secondIsDouble = 6.5d;
            double? secondIsNullableDouble = 9.5d;
            float secondIsFloat = 21.5f;
            float? secondIsNullableFloat = 14.5f;
            Guid secondIsGuid = Guid.NewGuid();
            Guid? secondIsNullableGuid = Guid.NewGuid();
            int secondIsInt = 33;
            int? secondIsNullableInt = 90;
            long secondIsLong = 110;
            long? secondIsNullableLong = 141;
            sbyte secondIsSByte = 112;
            sbyte? secondIsNullableSByte = 121;
            short secondIsShort = 42;
            short? secondIsNullabelShort = 56;
            Stream secondIsStream = new MemoryStream(secondIsBytes);
            string secondIsString = "test two";
            uint secondIsUInt = 1010;
            uint? secondIsNullableUInt = 1011;
            ulong secondIsULong = 10230;
            ulong? secondIsNullableULong = 100045;
            ushort secondIsUShort = 10144;
            ushort? secondIsNullableUShort = 10434;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "stream", streamValue },
                        { "not a stream", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ushort", uShortValue },
                        { "not a ushort", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "int", intValue },
                        { "not a int", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "uint", uIntValue },
                        { "not a uint", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "long", longValue },
                        { "not a long", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ulong", uLongValue },
                        { "not a ulong", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "decimal", decimalValue },
                        { "not a decimal", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "IsByte", firstIsByte },
                        { "IsNullableByte", firstIsNullableByte },
                        { "IsBool", firstIsBool },
                        { "IsNullableBool", firstIsNullableBool },
                        { "Bytes", firstIsBytes },
                        { "Chars", firstIsChars },
                        { "IsChar", firstIsChar },
                        { "IsNullableChar", firstIsNullableChar },
                        { "IsDateTime", firstIsDateTime },
                        { "IsNullableDateTime", firstIsNullableDateTime },
                        { "IsDecimal", firstIsDecimal },
                        { "IsNullableDecimal", firstIsNullableDecimal },
                        { "IsDouble", firstIsDouble },
                        { "IsNullableDouble", firstIsNullableDouble },
                        { "IsFloat", firstIsFloat },
                        { "IsNullableFloat", firstIsNullableFloat },
                        { "IsGuid", firstIsGuid },
                        { "IsNullableGuid", firstIsNullableGuid },
                        { "IsInt", firstIsInt },
                        { "IsNullableInt", firstIsNullableInt },
                        { "IsLong", firstIsLong },
                        { "IsNullableLong", firstIsNullableLong },
                        { "IsSByte", firstIsSByte },
                        { "IsNullableSByte", firstIsNullableSByte },
                        { "IsShort", firstIsShort },
                        { "IsNullabelShort", firstIsNullabelShort },
                        { "IsStream", firstIsStream },
                        { "IsString", firstIsString },
                        { "IsUInt", firstIsUInt },
                        { "IsNullableUInt", firstIsNullableUInt },
                        { "IsULong", firstIsULong },
                        { "IsNullableULong", firstIsNullableULong },
                        { "IsUShort", firstIsUShort },
                        { "IsNullableUShort", firstIsNullableUShort }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "IsByte", secondIsByte },
                        { "IsNullableByte", secondIsNullableByte },
                        { "IsBool", secondIsBool },
                        { "IsNullableBool", secondIsNullableBool },
                        { "Bytes", secondIsBytes },
                        { "Chars", secondIsChars },
                        { "IsChar", secondIsChar },
                        { "IsNullableChar", secondIsNullableChar },
                        { "IsDateTime", secondIsDateTime },
                        { "IsNullableDateTime", secondIsNullableDateTime },
                        { "IsDecimal", secondIsDecimal },
                        { "IsNullableDecimal", secondIsNullableDecimal },
                        { "IsDouble", secondIsDouble },
                        { "IsNullableDouble", secondIsNullableDouble },
                        { "IsFloat", secondIsFloat },
                        { "IsNullableFloat", secondIsNullableFloat },
                        { "IsGuid", secondIsGuid },
                        { "IsNullableGuid", secondIsNullableGuid },
                        { "IsInt", secondIsInt },
                        { "IsNullableInt", secondIsNullableInt },
                        { "IsLong", secondIsLong },
                        { "IsNullableLong", secondIsNullableLong },
                        { "IsSByte", secondIsSByte },
                        { "IsNullableSByte", secondIsNullableSByte },
                        { "IsShort", secondIsShort },
                        { "IsNullabelShort", secondIsNullabelShort },
                        { "IsStream", secondIsStream },
                        { "IsString", secondIsString },
                        { "IsUInt", secondIsUInt },
                        { "IsNullableUInt", secondIsNullableUInt },
                        { "IsULong", secondIsULong },
                        { "IsNullableULong", secondIsNullableULong },
                        { "IsUShort", secondIsUShort },
                        { "IsNullableUShort", secondIsNullableUShort }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (List<Stream> streamResults,
                List<ushort> ushortResults,
                List<int> intResults,
                List<uint> uintResults,
                List<long> longResults,
                List<ulong> ulongResults,
                List<decimal> decimalResults,
                List<TestClassWithProperties> results,
                List<TestClassWithFieldsNoDefaultConstructor> resultsNoConstructor) = connection.QueryMultipleAsync<Stream, ushort, int, uint, long, ulong, decimal, TestClassWithProperties, TestClassWithFieldsNoDefaultConstructor>(QUERY, null).Result;

            Assert.AreEqual(1, streamResults.Count);

            MemoryStream resultStream = new MemoryStream();

            streamResults[0].CopyTo(resultStream);
            resultStream.Position = 0;
            byte[] resultBytes = resultStream.ToArray();

            Assert.AreEqual(streamValues.Length, resultBytes.Length);

            for (int i = 0; i < streamValues.Length; i++)
            {
                Assert.AreEqual(streamValues[i], resultBytes[i]);
            }

            Assert.AreEqual(1, ushortResults.Count);

            Assert.AreEqual(uShortValue, ushortResults[0]);

            Assert.AreEqual(1, intResults.Count);

            Assert.AreEqual(intValue, intResults[0]);

            Assert.AreEqual(1, uintResults.Count);

            Assert.AreEqual(uIntValue, uintResults[0]);

            Assert.AreEqual(1, longResults.Count);

            Assert.AreEqual(longValue, longResults[0]);

            Assert.AreEqual(1, ulongResults.Count);

            Assert.AreEqual(uLongValue, ulongResults[0]);

            Assert.AreEqual(1, decimalResults.Count);

            Assert.AreEqual(decimalValue, decimalResults[0]);

            Assert.AreEqual(1, results.Count);

            Assert.AreEqual(firstIsByte, results[0].IsByte);
            Assert.AreEqual(firstIsNullableByte, results[0].IsNullableByte);
            Assert.AreEqual(firstIsBool, results[0].IsBool);
            Assert.AreEqual(firstIsNullableBool, results[0].IsNullableBool);

            Assert.AreEqual(firstIsBytes.Length, results[0].Bytes.Length);

            for (int i = 0; i < firstIsBytes.Length; i++)
            {
                Assert.AreEqual(firstIsBytes[i], results[0].Bytes[i]);
            }

            Assert.AreEqual(firstIsChars.Length, results[0].Chars.Length);

            for (int i = 0; i < firstIsChars.Length; i++)
            {
                Assert.AreEqual(firstIsChars[i], results[0].Chars[i]);
            }

            Assert.AreEqual(firstIsChar, results[0].IsChar);
            Assert.AreEqual(firstIsNullableChar, results[0].IsNullableChar);
            Assert.AreEqual(firstIsDateTime, results[0].IsDateTime);
            Assert.AreEqual(firstIsNullableDateTime, results[0].IsNullableDateTime);
            Assert.AreEqual(firstIsDecimal, results[0].IsDecimal);
            Assert.AreEqual(firstIsNullableDecimal, results[0].IsNullableDecimal);
            Assert.AreEqual(firstIsDouble, results[0].IsDouble);
            Assert.AreEqual(firstIsNullableDouble, results[0].IsNullableDouble);
            Assert.AreEqual(firstIsFloat, results[0].IsFloat);
            Assert.AreEqual(firstIsNullableFloat, results[0].IsNullableFloat);
            Assert.AreEqual(firstIsGuid, results[0].IsGuid);
            Assert.AreEqual(firstIsNullableGuid, results[0].IsNullableGuid);
            Assert.AreEqual(firstIsInt, results[0].IsInt);
            Assert.AreEqual(firstIsNullableInt, results[0].IsNullableInt);
            Assert.AreEqual(firstIsLong, results[0].IsLong);
            Assert.AreEqual(firstIsNullableLong, results[0].IsNullableLong);
            Assert.AreEqual(firstIsSByte, results[0].IsSByte);
            Assert.AreEqual(firstIsNullableSByte, results[0].IsNullableSByte);
            Assert.AreEqual(firstIsShort, results[0].IsShort);
            Assert.AreEqual(firstIsNullabelShort, results[0].IsNullabelShort);

            MemoryStream firstMS = new MemoryStream();
            results[0].IsStream.CopyTo(firstMS);

            byte[] firstStreamBytes = firstMS.ToArray();

            Assert.AreEqual(firstIsBytes.Length, firstStreamBytes.Length);

            for (int i = 0; i < firstIsBytes.Length; i++)
            {
                Assert.AreEqual(firstStreamBytes[i], firstIsBytes[i]);
            }

            Assert.AreEqual(firstIsString, results[0].IsString);
            Assert.AreEqual(firstIsUInt, results[0].IsUInt);
            Assert.AreEqual(firstIsNullableUInt, results[0].IsNullableUInt);
            Assert.AreEqual(firstIsULong, results[0].IsULong);
            Assert.AreEqual(firstIsNullableULong, results[0].IsNullableULong);
            Assert.AreEqual(firstIsUShort, results[0].IsUShort);
            Assert.AreEqual(firstIsNullableUShort, results[0].IsNullableUShort);

            Assert.AreEqual(1, resultsNoConstructor.Count);

            Assert.AreEqual(secondIsByte, resultsNoConstructor[0].IsByte);
            Assert.AreEqual(secondIsNullableByte, resultsNoConstructor[0].IsNullableByte);
            Assert.AreEqual(secondIsBool, resultsNoConstructor[0].IsBool);
            Assert.AreEqual(secondIsNullableBool, resultsNoConstructor[0].IsNullableBool);

            Assert.AreEqual(secondIsBytes.Length, resultsNoConstructor[0].Bytes.Length);

            for (int i = 0; i < secondIsBytes.Length; i++)
            {
                Assert.AreEqual(secondIsBytes[i], resultsNoConstructor[0].Bytes[i]);
            }

            Assert.AreEqual(secondIsChars.Length, resultsNoConstructor[0].Chars.Length);

            for (int i = 0; i < secondIsChars.Length; i++)
            {
                Assert.AreEqual(secondIsChars[i], resultsNoConstructor[0].Chars[i]);
            }

            Assert.AreEqual(secondIsChar, resultsNoConstructor[0].IsChar);
            Assert.AreEqual(secondIsNullableChar, resultsNoConstructor[0].IsNullableChar);
            Assert.AreEqual(secondIsDateTime, resultsNoConstructor[0].IsDateTime);
            Assert.AreEqual(secondIsNullableDateTime, resultsNoConstructor[0].IsNullableDateTime);
            Assert.AreEqual(secondIsDecimal, resultsNoConstructor[0].IsDecimal);
            Assert.AreEqual(secondIsNullableDecimal, resultsNoConstructor[0].IsNullableDecimal);
            Assert.AreEqual(secondIsDouble, resultsNoConstructor[0].IsDouble);
            Assert.AreEqual(secondIsNullableDouble, resultsNoConstructor[0].IsNullableDouble);
            Assert.AreEqual(secondIsFloat, resultsNoConstructor[0].IsFloat);
            Assert.AreEqual(secondIsNullableFloat, resultsNoConstructor[0].IsNullableFloat);
            Assert.AreEqual(secondIsGuid, resultsNoConstructor[0].IsGuid);
            Assert.AreEqual(secondIsNullableGuid, resultsNoConstructor[0].IsNullableGuid);
            Assert.AreEqual(secondIsInt, resultsNoConstructor[0].IsInt);
            Assert.AreEqual(secondIsNullableInt, resultsNoConstructor[0].IsNullableInt);
            Assert.AreEqual(secondIsLong, resultsNoConstructor[0].IsLong);
            Assert.AreEqual(secondIsNullableLong, resultsNoConstructor[0].IsNullableLong);
            Assert.AreEqual(secondIsSByte, resultsNoConstructor[0].IsSByte);
            Assert.AreEqual(secondIsNullableSByte, resultsNoConstructor[0].IsNullableSByte);
            Assert.AreEqual(secondIsShort, resultsNoConstructor[0].IsShort);
            Assert.AreEqual(secondIsNullabelShort, resultsNoConstructor[0].IsNullabelShort);

            MemoryStream secondMS = new MemoryStream();
            resultsNoConstructor[0].IsStream.CopyTo(secondMS);

            byte[] secondStreamBytes = secondMS.ToArray();

            Assert.AreEqual(secondIsBytes.Length, secondStreamBytes.Length);

            for (int i = 0; i < secondIsBytes.Length; i++)
            {
                Assert.AreEqual(secondIsBytes[i], secondIsBytes[i]);
            }

            Assert.AreEqual(secondIsString, resultsNoConstructor[0].IsString);
            Assert.AreEqual(secondIsUInt, resultsNoConstructor[0].IsUInt);
            Assert.AreEqual(secondIsNullableUInt, resultsNoConstructor[0].IsNullableUInt);
            Assert.AreEqual(secondIsULong, resultsNoConstructor[0].IsULong);
            Assert.AreEqual(secondIsNullableULong, resultsNoConstructor[0].IsNullableULong);
            Assert.AreEqual(secondIsUShort, resultsNoConstructor[0].IsUShort);
            Assert.AreEqual(secondIsNullableUShort, resultsNoConstructor[0].IsNullableUShort);
        }

        [TestMethod]
        public void QueryMultipleNineParametersStreamAndUShortAndIntAndUIntAndLongAndULongAndDecimalAndObjectWithFieldsAndNoConstructorAndObjectWithFieldsAndConstructorReturnsValues()
        {
            byte[] streamValues = { 1, 2, 3, 4 };

            MemoryStream streamValue = new MemoryStream(streamValues);

            ushort uShortValue = 55;
            int intValue = 45;
            uint uIntValue = 133;
            long longValue = 121;
            ulong uLongValue = 77;
            decimal decimalValue = 21.6M;

            byte firstIsByte = 0;
            byte? firstIsNullableByte = 13;
            bool firstIsBool = true;
            bool firstIsNullableBool = false;
            byte[] firstIsBytes = { 1, 2, 3, 4 };
            char[] firstIsChars = { 'a', 'b', 'c' };
            char firstIsChar = 'z';
            char? firstIsNullableChar = 'y';
            DateTime firstIsDateTime = new DateTime(2000, 11, 2);
            DateTime? firstIsNullableDateTime = new DateTime(2002, 6, 5);
            decimal firstIsDecimal = 2m;
            decimal? firstIsNullableDecimal = 21m;
            double firstIsDouble = 2.5d;
            double? firstIsNullableDouble = 3.5d;
            float firstIsFloat = 4.5f;
            float? firstIsNullableFloat = 5.5f;
            Guid firstIsGuid = Guid.NewGuid();
            Guid? firstIsNullableGuid = Guid.NewGuid();
            int firstIsInt = 22;
            int? firstIsNullableInt = 33;
            long firstIsLong = 100;
            long? firstIsNullableLong = 101;
            sbyte firstIsSByte = 11;
            sbyte? firstIsNullableSByte = 12;
            short firstIsShort = 33;
            short? firstIsNullabelShort = 34;
            Stream firstIsStream = new MemoryStream(firstIsBytes);
            string firstIsString = "test one";
            uint firstIsUInt = 1000;
            uint? firstIsNullableUInt = 1001;
            ulong firstIsULong = 10000;
            ulong? firstIsNullableULong = 100001;
            ushort firstIsUShort = 10033;
            ushort? firstIsNullableUShort = 10034;

            byte secondIsByte = 10;
            byte? secondIsNullableByte = 113;
            bool secondIsBool = false;
            bool secondIsNullableBool = true;
            byte[] secondIsBytes = { 4, 3, 2, 1 };
            char[] secondIsChars = { 'c', 'b', 'a' };
            char secondIsChar = 'x';
            char? secondIsNullableChar = 'q';
            DateTime secondIsDateTime = new DateTime(2000, 10, 2);
            DateTime? secondIsNullableDateTime = new DateTime(2002, 1, 5);
            decimal secondIsDecimal = 12m;
            decimal? secondIsNullableDecimal = 31m;
            double secondIsDouble = 6.5d;
            double? secondIsNullableDouble = 9.5d;
            float secondIsFloat = 21.5f;
            float? secondIsNullableFloat = 14.5f;
            Guid secondIsGuid = Guid.NewGuid();
            Guid? secondIsNullableGuid = Guid.NewGuid();
            int secondIsInt = 33;
            int? secondIsNullableInt = 90;
            long secondIsLong = 110;
            long? secondIsNullableLong = 141;
            sbyte secondIsSByte = 112;
            sbyte? secondIsNullableSByte = 121;
            short secondIsShort = 42;
            short? secondIsNullabelShort = 56;
            Stream secondIsStream = new MemoryStream(secondIsBytes);
            string secondIsString = "test two";
            uint secondIsUInt = 1010;
            uint? secondIsNullableUInt = 1011;
            ulong secondIsULong = 10230;
            ulong? secondIsNullableULong = 100045;
            ushort secondIsUShort = 10144;
            ushort? secondIsNullableUShort = 10434;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "stream", streamValue },
                        { "not a stream", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ushort", uShortValue },
                        { "not a ushort", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "int", intValue },
                        { "not a int", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "uint", uIntValue },
                        { "not a uint", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "long", longValue },
                        { "not a long", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ulong", uLongValue },
                        { "not a ulong", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "decimal", decimalValue },
                        { "not a decimal", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "IsByte", firstIsByte },
                        { "IsNullableByte", firstIsNullableByte },
                        { "IsBool", firstIsBool },
                        { "IsNullableBool", firstIsNullableBool },
                        { "Bytes", firstIsBytes },
                        { "Chars", firstIsChars },
                        { "IsChar", firstIsChar },
                        { "IsNullableChar", firstIsNullableChar },
                        { "IsDateTime", firstIsDateTime },
                        { "IsNullableDateTime", firstIsNullableDateTime },
                        { "IsDecimal", firstIsDecimal },
                        { "IsNullableDecimal", firstIsNullableDecimal },
                        { "IsDouble", firstIsDouble },
                        { "IsNullableDouble", firstIsNullableDouble },
                        { "IsFloat", firstIsFloat },
                        { "IsNullableFloat", firstIsNullableFloat },
                        { "IsGuid", firstIsGuid },
                        { "IsNullableGuid", firstIsNullableGuid },
                        { "IsInt", firstIsInt },
                        { "IsNullableInt", firstIsNullableInt },
                        { "IsLong", firstIsLong },
                        { "IsNullableLong", firstIsNullableLong },
                        { "IsSByte", firstIsSByte },
                        { "IsNullableSByte", firstIsNullableSByte },
                        { "IsShort", firstIsShort },
                        { "IsNullabelShort", firstIsNullabelShort },
                        { "IsStream", firstIsStream },
                        { "IsString", firstIsString },
                        { "IsUInt", firstIsUInt },
                        { "IsNullableUInt", firstIsNullableUInt },
                        { "IsULong", firstIsULong },
                        { "IsNullableULong", firstIsNullableULong },
                        { "IsUShort", firstIsUShort },
                        { "IsNullableUShort", firstIsNullableUShort }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "IsByte", secondIsByte },
                        { "IsNullableByte", secondIsNullableByte },
                        { "IsBool", secondIsBool },
                        { "IsNullableBool", secondIsNullableBool },
                        { "Bytes", secondIsBytes },
                        { "Chars", secondIsChars },
                        { "IsChar", secondIsChar },
                        { "IsNullableChar", secondIsNullableChar },
                        { "IsDateTime", secondIsDateTime },
                        { "IsNullableDateTime", secondIsNullableDateTime },
                        { "IsDecimal", secondIsDecimal },
                        { "IsNullableDecimal", secondIsNullableDecimal },
                        { "IsDouble", secondIsDouble },
                        { "IsNullableDouble", secondIsNullableDouble },
                        { "IsFloat", secondIsFloat },
                        { "IsNullableFloat", secondIsNullableFloat },
                        { "IsGuid", secondIsGuid },
                        { "IsNullableGuid", secondIsNullableGuid },
                        { "IsInt", secondIsInt },
                        { "IsNullableInt", secondIsNullableInt },
                        { "IsLong", secondIsLong },
                        { "IsNullableLong", secondIsNullableLong },
                        { "IsSByte", secondIsSByte },
                        { "IsNullableSByte", secondIsNullableSByte },
                        { "IsShort", secondIsShort },
                        { "IsNullabelShort", secondIsNullabelShort },
                        { "IsStream", secondIsStream },
                        { "IsString", secondIsString },
                        { "IsUInt", secondIsUInt },
                        { "IsNullableUInt", secondIsNullableUInt },
                        { "IsULong", secondIsULong },
                        { "IsNullableULong", secondIsNullableULong },
                        { "IsUShort", secondIsUShort },
                        { "IsNullableUShort", secondIsNullableUShort }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (List<Stream> streamResults,
                List<ushort> ushortResults,
                List<int> intResults,
                List<uint> uintResults,
                List<long> longResults,
                List<ulong> ulongResults,
                List<decimal> decimalResults,
                List<TestClassWithFields> results,
                List<TestClassWithFieldsNoDefaultConstructor> resultsNoConstructor) = connection.QueryMultiple<Stream, ushort, int, uint, long, ulong, decimal, TestClassWithFields, TestClassWithFieldsNoDefaultConstructor>(QUERY, null);

            Assert.AreEqual(1, streamResults.Count);

            MemoryStream resultStream = new MemoryStream();

            streamResults[0].CopyTo(resultStream);
            resultStream.Position = 0;
            byte[] resultBytes = resultStream.ToArray();

            Assert.AreEqual(streamValues.Length, resultBytes.Length);

            for (int i = 0; i < streamValues.Length; i++)
            {
                Assert.AreEqual(streamValues[i], resultBytes[i]);
            }

            Assert.AreEqual(1, ushortResults.Count);

            Assert.AreEqual(uShortValue, ushortResults[0]);

            Assert.AreEqual(1, intResults.Count);

            Assert.AreEqual(intValue, intResults[0]);

            Assert.AreEqual(1, uintResults.Count);

            Assert.AreEqual(uIntValue, uintResults[0]);

            Assert.AreEqual(1, longResults.Count);

            Assert.AreEqual(longValue, longResults[0]);

            Assert.AreEqual(1, ulongResults.Count);

            Assert.AreEqual(uLongValue, ulongResults[0]);

            Assert.AreEqual(1, decimalResults.Count);

            Assert.AreEqual(decimalValue, decimalResults[0]);

            Assert.AreEqual(1, results.Count);

            Assert.AreEqual(firstIsByte, results[0].IsByte);
            Assert.AreEqual(firstIsNullableByte, results[0].IsNullableByte);
            Assert.AreEqual(firstIsBool, results[0].IsBool);
            Assert.AreEqual(firstIsNullableBool, results[0].IsNullableBool);

            Assert.AreEqual(firstIsBytes.Length, results[0].Bytes.Length);

            for (int i = 0; i < firstIsBytes.Length; i++)
            {
                Assert.AreEqual(firstIsBytes[i], results[0].Bytes[i]);
            }

            Assert.AreEqual(firstIsChars.Length, results[0].Chars.Length);

            for (int i = 0; i < firstIsChars.Length; i++)
            {
                Assert.AreEqual(firstIsChars[i], results[0].Chars[i]);
            }

            Assert.AreEqual(firstIsChar, results[0].IsChar);
            Assert.AreEqual(firstIsNullableChar, results[0].IsNullableChar);
            Assert.AreEqual(firstIsDateTime, results[0].IsDateTime);
            Assert.AreEqual(firstIsNullableDateTime, results[0].IsNullableDateTime);
            Assert.AreEqual(firstIsDecimal, results[0].IsDecimal);
            Assert.AreEqual(firstIsNullableDecimal, results[0].IsNullableDecimal);
            Assert.AreEqual(firstIsDouble, results[0].IsDouble);
            Assert.AreEqual(firstIsNullableDouble, results[0].IsNullableDouble);
            Assert.AreEqual(firstIsFloat, results[0].IsFloat);
            Assert.AreEqual(firstIsNullableFloat, results[0].IsNullableFloat);
            Assert.AreEqual(firstIsGuid, results[0].IsGuid);
            Assert.AreEqual(firstIsNullableGuid, results[0].IsNullableGuid);
            Assert.AreEqual(firstIsInt, results[0].IsInt);
            Assert.AreEqual(firstIsNullableInt, results[0].IsNullableInt);
            Assert.AreEqual(firstIsLong, results[0].IsLong);
            Assert.AreEqual(firstIsNullableLong, results[0].IsNullableLong);
            Assert.AreEqual(firstIsSByte, results[0].IsSByte);
            Assert.AreEqual(firstIsNullableSByte, results[0].IsNullableSByte);
            Assert.AreEqual(firstIsShort, results[0].IsShort);
            Assert.AreEqual(firstIsNullabelShort, results[0].IsNullabelShort);

            MemoryStream firstMS = new MemoryStream();
            results[0].IsStream.CopyTo(firstMS);

            byte[] firstStreamBytes = firstMS.ToArray();

            Assert.AreEqual(firstIsBytes.Length, firstStreamBytes.Length);

            for (int i = 0; i < firstIsBytes.Length; i++)
            {
                Assert.AreEqual(firstStreamBytes[i], firstIsBytes[i]);
            }

            Assert.AreEqual(firstIsString, results[0].IsString);
            Assert.AreEqual(firstIsUInt, results[0].IsUInt);
            Assert.AreEqual(firstIsNullableUInt, results[0].IsNullableUInt);
            Assert.AreEqual(firstIsULong, results[0].IsULong);
            Assert.AreEqual(firstIsNullableULong, results[0].IsNullableULong);
            Assert.AreEqual(firstIsUShort, results[0].IsUShort);
            Assert.AreEqual(firstIsNullableUShort, results[0].IsNullableUShort);

            Assert.AreEqual(1, resultsNoConstructor.Count);

            Assert.AreEqual(secondIsByte, resultsNoConstructor[0].IsByte);
            Assert.AreEqual(secondIsNullableByte, resultsNoConstructor[0].IsNullableByte);
            Assert.AreEqual(secondIsBool, resultsNoConstructor[0].IsBool);
            Assert.AreEqual(secondIsNullableBool, resultsNoConstructor[0].IsNullableBool);

            Assert.AreEqual(secondIsBytes.Length, resultsNoConstructor[0].Bytes.Length);

            for (int i = 0; i < secondIsBytes.Length; i++)
            {
                Assert.AreEqual(secondIsBytes[i], resultsNoConstructor[0].Bytes[i]);
            }

            Assert.AreEqual(secondIsChars.Length, resultsNoConstructor[0].Chars.Length);

            for (int i = 0; i < secondIsChars.Length; i++)
            {
                Assert.AreEqual(secondIsChars[i], resultsNoConstructor[0].Chars[i]);
            }

            Assert.AreEqual(secondIsChar, resultsNoConstructor[0].IsChar);
            Assert.AreEqual(secondIsNullableChar, resultsNoConstructor[0].IsNullableChar);
            Assert.AreEqual(secondIsDateTime, resultsNoConstructor[0].IsDateTime);
            Assert.AreEqual(secondIsNullableDateTime, resultsNoConstructor[0].IsNullableDateTime);
            Assert.AreEqual(secondIsDecimal, resultsNoConstructor[0].IsDecimal);
            Assert.AreEqual(secondIsNullableDecimal, resultsNoConstructor[0].IsNullableDecimal);
            Assert.AreEqual(secondIsDouble, resultsNoConstructor[0].IsDouble);
            Assert.AreEqual(secondIsNullableDouble, resultsNoConstructor[0].IsNullableDouble);
            Assert.AreEqual(secondIsFloat, resultsNoConstructor[0].IsFloat);
            Assert.AreEqual(secondIsNullableFloat, resultsNoConstructor[0].IsNullableFloat);
            Assert.AreEqual(secondIsGuid, resultsNoConstructor[0].IsGuid);
            Assert.AreEqual(secondIsNullableGuid, resultsNoConstructor[0].IsNullableGuid);
            Assert.AreEqual(secondIsInt, resultsNoConstructor[0].IsInt);
            Assert.AreEqual(secondIsNullableInt, resultsNoConstructor[0].IsNullableInt);
            Assert.AreEqual(secondIsLong, resultsNoConstructor[0].IsLong);
            Assert.AreEqual(secondIsNullableLong, resultsNoConstructor[0].IsNullableLong);
            Assert.AreEqual(secondIsSByte, resultsNoConstructor[0].IsSByte);
            Assert.AreEqual(secondIsNullableSByte, resultsNoConstructor[0].IsNullableSByte);
            Assert.AreEqual(secondIsShort, resultsNoConstructor[0].IsShort);
            Assert.AreEqual(secondIsNullabelShort, resultsNoConstructor[0].IsNullabelShort);

            MemoryStream secondMS = new MemoryStream();
            resultsNoConstructor[0].IsStream.CopyTo(secondMS);

            byte[] secondStreamBytes = secondMS.ToArray();

            Assert.AreEqual(secondIsBytes.Length, secondStreamBytes.Length);

            for (int i = 0; i < secondIsBytes.Length; i++)
            {
                Assert.AreEqual(secondIsBytes[i], secondIsBytes[i]);
            }

            Assert.AreEqual(secondIsString, resultsNoConstructor[0].IsString);
            Assert.AreEqual(secondIsUInt, resultsNoConstructor[0].IsUInt);
            Assert.AreEqual(secondIsNullableUInt, resultsNoConstructor[0].IsNullableUInt);
            Assert.AreEqual(secondIsULong, resultsNoConstructor[0].IsULong);
            Assert.AreEqual(secondIsNullableULong, resultsNoConstructor[0].IsNullableULong);
            Assert.AreEqual(secondIsUShort, resultsNoConstructor[0].IsUShort);
            Assert.AreEqual(secondIsNullableUShort, resultsNoConstructor[0].IsNullableUShort);
        }

        [TestMethod]
        public void QueryMultipleAsyncNineParametersStreamAndUShortAndIntAndUIntAndLongAndULongAndDecimalAndObjectWithFieldsAndNoConstructorAndObjectWithFieldsAndConstructorReturnsValues()
        {
            byte[] streamValues = { 1, 2, 3, 4 };

            MemoryStream streamValue = new MemoryStream(streamValues);

            ushort uShortValue = 55;
            int intValue = 45;
            uint uIntValue = 133;
            long longValue = 121;
            ulong uLongValue = 77;
            decimal decimalValue = 21.6M;

            byte firstIsByte = 0;
            byte? firstIsNullableByte = 13;
            bool firstIsBool = true;
            bool firstIsNullableBool = false;
            byte[] firstIsBytes = { 1, 2, 3, 4 };
            char[] firstIsChars = { 'a', 'b', 'c' };
            char firstIsChar = 'z';
            char? firstIsNullableChar = 'y';
            DateTime firstIsDateTime = new DateTime(2000, 11, 2);
            DateTime? firstIsNullableDateTime = new DateTime(2002, 6, 5);
            decimal firstIsDecimal = 2m;
            decimal? firstIsNullableDecimal = 21m;
            double firstIsDouble = 2.5d;
            double? firstIsNullableDouble = 3.5d;
            float firstIsFloat = 4.5f;
            float? firstIsNullableFloat = 5.5f;
            Guid firstIsGuid = Guid.NewGuid();
            Guid? firstIsNullableGuid = Guid.NewGuid();
            int firstIsInt = 22;
            int? firstIsNullableInt = 33;
            long firstIsLong = 100;
            long? firstIsNullableLong = 101;
            sbyte firstIsSByte = 11;
            sbyte? firstIsNullableSByte = 12;
            short firstIsShort = 33;
            short? firstIsNullabelShort = 34;
            Stream firstIsStream = new MemoryStream(firstIsBytes);
            string firstIsString = "test one";
            uint firstIsUInt = 1000;
            uint? firstIsNullableUInt = 1001;
            ulong firstIsULong = 10000;
            ulong? firstIsNullableULong = 100001;
            ushort firstIsUShort = 10033;
            ushort? firstIsNullableUShort = 10034;

            byte secondIsByte = 10;
            byte? secondIsNullableByte = 113;
            bool secondIsBool = false;
            bool secondIsNullableBool = true;
            byte[] secondIsBytes = { 4, 3, 2, 1 };
            char[] secondIsChars = { 'c', 'b', 'a' };
            char secondIsChar = 'x';
            char? secondIsNullableChar = 'q';
            DateTime secondIsDateTime = new DateTime(2000, 10, 2);
            DateTime? secondIsNullableDateTime = new DateTime(2002, 1, 5);
            decimal secondIsDecimal = 12m;
            decimal? secondIsNullableDecimal = 31m;
            double secondIsDouble = 6.5d;
            double? secondIsNullableDouble = 9.5d;
            float secondIsFloat = 21.5f;
            float? secondIsNullableFloat = 14.5f;
            Guid secondIsGuid = Guid.NewGuid();
            Guid? secondIsNullableGuid = Guid.NewGuid();
            int secondIsInt = 33;
            int? secondIsNullableInt = 90;
            long secondIsLong = 110;
            long? secondIsNullableLong = 141;
            sbyte secondIsSByte = 112;
            sbyte? secondIsNullableSByte = 121;
            short secondIsShort = 42;
            short? secondIsNullabelShort = 56;
            Stream secondIsStream = new MemoryStream(secondIsBytes);
            string secondIsString = "test two";
            uint secondIsUInt = 1010;
            uint? secondIsNullableUInt = 1011;
            ulong secondIsULong = 10230;
            ulong? secondIsNullableULong = 100045;
            ushort secondIsUShort = 10144;
            ushort? secondIsNullableUShort = 10434;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "stream", streamValue },
                        { "not a stream", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ushort", uShortValue },
                        { "not a ushort", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "int", intValue },
                        { "not a int", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "uint", uIntValue },
                        { "not a uint", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "long", longValue },
                        { "not a long", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ulong", uLongValue },
                        { "not a ulong", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "decimal", decimalValue },
                        { "not a decimal", "test" }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "IsByte", firstIsByte },
                        { "IsNullableByte", firstIsNullableByte },
                        { "IsBool", firstIsBool },
                        { "IsNullableBool", firstIsNullableBool },
                        { "Bytes", firstIsBytes },
                        { "Chars", firstIsChars },
                        { "IsChar", firstIsChar },
                        { "IsNullableChar", firstIsNullableChar },
                        { "IsDateTime", firstIsDateTime },
                        { "IsNullableDateTime", firstIsNullableDateTime },
                        { "IsDecimal", firstIsDecimal },
                        { "IsNullableDecimal", firstIsNullableDecimal },
                        { "IsDouble", firstIsDouble },
                        { "IsNullableDouble", firstIsNullableDouble },
                        { "IsFloat", firstIsFloat },
                        { "IsNullableFloat", firstIsNullableFloat },
                        { "IsGuid", firstIsGuid },
                        { "IsNullableGuid", firstIsNullableGuid },
                        { "IsInt", firstIsInt },
                        { "IsNullableInt", firstIsNullableInt },
                        { "IsLong", firstIsLong },
                        { "IsNullableLong", firstIsNullableLong },
                        { "IsSByte", firstIsSByte },
                        { "IsNullableSByte", firstIsNullableSByte },
                        { "IsShort", firstIsShort },
                        { "IsNullabelShort", firstIsNullabelShort },
                        { "IsStream", firstIsStream },
                        { "IsString", firstIsString },
                        { "IsUInt", firstIsUInt },
                        { "IsNullableUInt", firstIsNullableUInt },
                        { "IsULong", firstIsULong },
                        { "IsNullableULong", firstIsNullableULong },
                        { "IsUShort", firstIsUShort },
                        { "IsNullableUShort", firstIsNullableUShort }
                    }
                },
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "IsByte", secondIsByte },
                        { "IsNullableByte", secondIsNullableByte },
                        { "IsBool", secondIsBool },
                        { "IsNullableBool", secondIsNullableBool },
                        { "Bytes", secondIsBytes },
                        { "Chars", secondIsChars },
                        { "IsChar", secondIsChar },
                        { "IsNullableChar", secondIsNullableChar },
                        { "IsDateTime", secondIsDateTime },
                        { "IsNullableDateTime", secondIsNullableDateTime },
                        { "IsDecimal", secondIsDecimal },
                        { "IsNullableDecimal", secondIsNullableDecimal },
                        { "IsDouble", secondIsDouble },
                        { "IsNullableDouble", secondIsNullableDouble },
                        { "IsFloat", secondIsFloat },
                        { "IsNullableFloat", secondIsNullableFloat },
                        { "IsGuid", secondIsGuid },
                        { "IsNullableGuid", secondIsNullableGuid },
                        { "IsInt", secondIsInt },
                        { "IsNullableInt", secondIsNullableInt },
                        { "IsLong", secondIsLong },
                        { "IsNullableLong", secondIsNullableLong },
                        { "IsSByte", secondIsSByte },
                        { "IsNullableSByte", secondIsNullableSByte },
                        { "IsShort", secondIsShort },
                        { "IsNullabelShort", secondIsNullabelShort },
                        { "IsStream", secondIsStream },
                        { "IsString", secondIsString },
                        { "IsUInt", secondIsUInt },
                        { "IsNullableUInt", secondIsNullableUInt },
                        { "IsULong", secondIsULong },
                        { "IsNullableULong", secondIsNullableULong },
                        { "IsUShort", secondIsUShort },
                        { "IsNullableUShort", secondIsNullableUShort }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (List<Stream> streamResults,
                List<ushort> ushortResults,
                List<int> intResults,
                List<uint> uintResults,
                List<long> longResults,
                List<ulong> ulongResults,
                List<decimal> decimalResults,
                List<TestClassWithFields> results,
                List<TestClassWithFieldsNoDefaultConstructor> resultsNoConstructor) = connection.QueryMultipleAsync<Stream, ushort, int, uint, long, ulong, decimal, TestClassWithFields, TestClassWithFieldsNoDefaultConstructor>(QUERY, null).Result;

            Assert.AreEqual(1, streamResults.Count);

            MemoryStream resultStream = new MemoryStream();

            streamResults[0].CopyTo(resultStream);
            resultStream.Position = 0;
            byte[] resultBytes = resultStream.ToArray();

            Assert.AreEqual(streamValues.Length, resultBytes.Length);

            for (int i = 0; i < streamValues.Length; i++)
            {
                Assert.AreEqual(streamValues[i], resultBytes[i]);
            }

            Assert.AreEqual(1, ushortResults.Count);

            Assert.AreEqual(uShortValue, ushortResults[0]);

            Assert.AreEqual(1, intResults.Count);

            Assert.AreEqual(intValue, intResults[0]);

            Assert.AreEqual(1, uintResults.Count);

            Assert.AreEqual(uIntValue, uintResults[0]);

            Assert.AreEqual(1, longResults.Count);

            Assert.AreEqual(longValue, longResults[0]);

            Assert.AreEqual(1, ulongResults.Count);

            Assert.AreEqual(uLongValue, ulongResults[0]);

            Assert.AreEqual(1, decimalResults.Count);

            Assert.AreEqual(decimalValue, decimalResults[0]);

            Assert.AreEqual(1, results.Count);

            Assert.AreEqual(firstIsByte, results[0].IsByte);
            Assert.AreEqual(firstIsNullableByte, results[0].IsNullableByte);
            Assert.AreEqual(firstIsBool, results[0].IsBool);
            Assert.AreEqual(firstIsNullableBool, results[0].IsNullableBool);

            Assert.AreEqual(firstIsBytes.Length, results[0].Bytes.Length);

            for (int i = 0; i < firstIsBytes.Length; i++)
            {
                Assert.AreEqual(firstIsBytes[i], results[0].Bytes[i]);
            }

            Assert.AreEqual(firstIsChars.Length, results[0].Chars.Length);

            for (int i = 0; i < firstIsChars.Length; i++)
            {
                Assert.AreEqual(firstIsChars[i], results[0].Chars[i]);
            }

            Assert.AreEqual(firstIsChar, results[0].IsChar);
            Assert.AreEqual(firstIsNullableChar, results[0].IsNullableChar);
            Assert.AreEqual(firstIsDateTime, results[0].IsDateTime);
            Assert.AreEqual(firstIsNullableDateTime, results[0].IsNullableDateTime);
            Assert.AreEqual(firstIsDecimal, results[0].IsDecimal);
            Assert.AreEqual(firstIsNullableDecimal, results[0].IsNullableDecimal);
            Assert.AreEqual(firstIsDouble, results[0].IsDouble);
            Assert.AreEqual(firstIsNullableDouble, results[0].IsNullableDouble);
            Assert.AreEqual(firstIsFloat, results[0].IsFloat);
            Assert.AreEqual(firstIsNullableFloat, results[0].IsNullableFloat);
            Assert.AreEqual(firstIsGuid, results[0].IsGuid);
            Assert.AreEqual(firstIsNullableGuid, results[0].IsNullableGuid);
            Assert.AreEqual(firstIsInt, results[0].IsInt);
            Assert.AreEqual(firstIsNullableInt, results[0].IsNullableInt);
            Assert.AreEqual(firstIsLong, results[0].IsLong);
            Assert.AreEqual(firstIsNullableLong, results[0].IsNullableLong);
            Assert.AreEqual(firstIsSByte, results[0].IsSByte);
            Assert.AreEqual(firstIsNullableSByte, results[0].IsNullableSByte);
            Assert.AreEqual(firstIsShort, results[0].IsShort);
            Assert.AreEqual(firstIsNullabelShort, results[0].IsNullabelShort);

            MemoryStream firstMS = new MemoryStream();
            results[0].IsStream.CopyTo(firstMS);

            byte[] firstStreamBytes = firstMS.ToArray();

            Assert.AreEqual(firstIsBytes.Length, firstStreamBytes.Length);

            for (int i = 0; i < firstIsBytes.Length; i++)
            {
                Assert.AreEqual(firstStreamBytes[i], firstIsBytes[i]);
            }

            Assert.AreEqual(firstIsString, results[0].IsString);
            Assert.AreEqual(firstIsUInt, results[0].IsUInt);
            Assert.AreEqual(firstIsNullableUInt, results[0].IsNullableUInt);
            Assert.AreEqual(firstIsULong, results[0].IsULong);
            Assert.AreEqual(firstIsNullableULong, results[0].IsNullableULong);
            Assert.AreEqual(firstIsUShort, results[0].IsUShort);
            Assert.AreEqual(firstIsNullableUShort, results[0].IsNullableUShort);

            Assert.AreEqual(1, resultsNoConstructor.Count);

            Assert.AreEqual(secondIsByte, resultsNoConstructor[0].IsByte);
            Assert.AreEqual(secondIsNullableByte, resultsNoConstructor[0].IsNullableByte);
            Assert.AreEqual(secondIsBool, resultsNoConstructor[0].IsBool);
            Assert.AreEqual(secondIsNullableBool, resultsNoConstructor[0].IsNullableBool);

            Assert.AreEqual(secondIsBytes.Length, resultsNoConstructor[0].Bytes.Length);

            for (int i = 0; i < secondIsBytes.Length; i++)
            {
                Assert.AreEqual(secondIsBytes[i], resultsNoConstructor[0].Bytes[i]);
            }

            Assert.AreEqual(secondIsChars.Length, resultsNoConstructor[0].Chars.Length);

            for (int i = 0; i < secondIsChars.Length; i++)
            {
                Assert.AreEqual(secondIsChars[i], resultsNoConstructor[0].Chars[i]);
            }

            Assert.AreEqual(secondIsChar, resultsNoConstructor[0].IsChar);
            Assert.AreEqual(secondIsNullableChar, resultsNoConstructor[0].IsNullableChar);
            Assert.AreEqual(secondIsDateTime, resultsNoConstructor[0].IsDateTime);
            Assert.AreEqual(secondIsNullableDateTime, resultsNoConstructor[0].IsNullableDateTime);
            Assert.AreEqual(secondIsDecimal, resultsNoConstructor[0].IsDecimal);
            Assert.AreEqual(secondIsNullableDecimal, resultsNoConstructor[0].IsNullableDecimal);
            Assert.AreEqual(secondIsDouble, resultsNoConstructor[0].IsDouble);
            Assert.AreEqual(secondIsNullableDouble, resultsNoConstructor[0].IsNullableDouble);
            Assert.AreEqual(secondIsFloat, resultsNoConstructor[0].IsFloat);
            Assert.AreEqual(secondIsNullableFloat, resultsNoConstructor[0].IsNullableFloat);
            Assert.AreEqual(secondIsGuid, resultsNoConstructor[0].IsGuid);
            Assert.AreEqual(secondIsNullableGuid, resultsNoConstructor[0].IsNullableGuid);
            Assert.AreEqual(secondIsInt, resultsNoConstructor[0].IsInt);
            Assert.AreEqual(secondIsNullableInt, resultsNoConstructor[0].IsNullableInt);
            Assert.AreEqual(secondIsLong, resultsNoConstructor[0].IsLong);
            Assert.AreEqual(secondIsNullableLong, resultsNoConstructor[0].IsNullableLong);
            Assert.AreEqual(secondIsSByte, resultsNoConstructor[0].IsSByte);
            Assert.AreEqual(secondIsNullableSByte, resultsNoConstructor[0].IsNullableSByte);
            Assert.AreEqual(secondIsShort, resultsNoConstructor[0].IsShort);
            Assert.AreEqual(secondIsNullabelShort, resultsNoConstructor[0].IsNullabelShort);

            MemoryStream secondMS = new MemoryStream();
            resultsNoConstructor[0].IsStream.CopyTo(secondMS);

            byte[] secondStreamBytes = secondMS.ToArray();

            Assert.AreEqual(secondIsBytes.Length, secondStreamBytes.Length);

            for (int i = 0; i < secondIsBytes.Length; i++)
            {
                Assert.AreEqual(secondIsBytes[i], secondIsBytes[i]);
            }

            Assert.AreEqual(secondIsString, resultsNoConstructor[0].IsString);
            Assert.AreEqual(secondIsUInt, resultsNoConstructor[0].IsUInt);
            Assert.AreEqual(secondIsNullableUInt, resultsNoConstructor[0].IsNullableUInt);
            Assert.AreEqual(secondIsULong, resultsNoConstructor[0].IsULong);
            Assert.AreEqual(secondIsNullableULong, resultsNoConstructor[0].IsNullableULong);
            Assert.AreEqual(secondIsUShort, resultsNoConstructor[0].IsUShort);
            Assert.AreEqual(secondIsNullableUShort, resultsNoConstructor[0].IsNullableUShort);
        }
    }
}
