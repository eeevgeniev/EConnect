using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;

namespace EConnectUnitTests.Mockups
{
    public class MockDbDataReader : DbDataReader
    {
        private List<List<Dictionary<string, object>>> _results;
        private int _currentResultIndex = 0;
        private int _currentIndex = -1;

        public MockDbDataReader(List<List<Dictionary<string, object>>> results)
        {
            this._results = results ?? new List<List<Dictionary<string, object>>>();
        }

        public override object this[int ordinal] => null;

        public override object this[string name] => null;

        public override int Depth => 0;

        public override int FieldCount => this._currentIndex > -1 ? this._results[this._currentResultIndex][this._currentIndex].Count : 0;

        public override bool HasRows => false;

        public override bool IsClosed => false;

        public override int RecordsAffected => 0;

        public override bool GetBoolean(int ordinal) => this.GetValue<bool>(ordinal);

        public override byte GetByte(int ordinal) => this.GetValue<byte>(ordinal);

        public override long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length)
        {
            int index = 0;
            long readedBytes = -1;

            foreach (var value in this._results[this._currentResultIndex][this._currentIndex].Values)
            {
                if (index == ordinal)
                {
                    byte[] values = value as byte[];

                    if (value != null)
                    {
                        readedBytes = 0;

                        for (int i = bufferOffset; i < length; i++)
                        {
                            buffer[bufferOffset] = values[i];

                            bufferOffset++;
                            readedBytes++;

                            if (i == values.Length - 1)
                            {
                                return readedBytes;
                            }
                        }
                    }
                }

                index++;
            }

            return readedBytes;
        }

        public override char GetChar(int ordinal) => this.GetValue<char>(ordinal);

        public override long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length)
        {
            int index = 0;
            long readedChars = -1;

            foreach (var value in this._results[this._currentResultIndex][this._currentIndex].Values)
            {
                if (index == ordinal)
                {
                    char[] values = value as char[];

                    if (value != null)
                    {
                        readedChars = 0;

                        for (int i = bufferOffset; i < length; i++)
                        {
                            buffer[bufferOffset] = values[i];

                            bufferOffset++;
                            readedChars++;

                            if (i == values.Length - 1)
                            {
                                return readedChars;
                            }
                        }
                    }
                }

                index++;
            }

            return readedChars;
        }

        public override string GetDataTypeName(int ordinal) => string.Empty;

        public override DateTime GetDateTime(int ordinal) => this.GetValue<DateTime>(ordinal);

        public override decimal GetDecimal(int ordinal) => this.GetValue<decimal>(ordinal);

        public override double GetDouble(int ordinal) => this.GetValue<double>(ordinal);

        public override IEnumerator GetEnumerator() => null;

        public override Type GetFieldType(int ordinal)
        {
            int index = 0;

            foreach (string key in this._results[this._currentResultIndex][this._currentIndex].Keys)
            {
                if (index == ordinal)
                {
                    return this._results[this._currentResultIndex][this._currentIndex][key].GetType();
                }

                index++;
            }

            throw new IndexOutOfRangeException("");
        }

        public override float GetFloat(int ordinal) => this.GetValue<float>(ordinal);

        public override Guid GetGuid(int ordinal) => this.GetValue<Guid>(ordinal);

        public override short GetInt16(int ordinal) => this.GetValue<short>(ordinal);

        public override int GetInt32(int ordinal) => this.GetValue<int>(ordinal);

        public override long GetInt64(int ordinal) => this.GetValue<long>(ordinal);

        public override string GetName(int ordinal)
        {
            int index = 0;

            foreach (string key in this._results[this._currentResultIndex][this._currentIndex].Keys)
            {
                if (index == ordinal)
                {
                    return key;
                }

                index++;
            }

            throw new IndexOutOfRangeException("");
        }

        public override int GetOrdinal(string name) => 0;

        public override string GetString(int ordinal)
        {
            int index = 0;

            foreach (var value in this._results[this._currentResultIndex][this._currentIndex].Values)
            {
                if (index == ordinal)
                {
                    if (value is char letter)
                    {
                        return letter.ToString();
                    }
                    else if (value is null)
                    {
                        return null;
                    }
                }

                index++;
            }

            return this.GetValue<string>(ordinal);
        }

        public override object GetValue(int ordinal) => this.GetValue<object>(ordinal);

        public override int GetValues(object[] values) => 1;

        public override Stream GetStream(int ordinal) => this.GetValue<Stream>(ordinal);

        public override bool IsDBNull(int ordinal)
        {
            int index = 0;

            foreach (var value in this._results[this._currentResultIndex][this._currentIndex].Values)
            {
                if (index == ordinal)
                {
                    return value == null;
                }

                index++;
            }

            throw new IndexOutOfRangeException("");
        }

        public override bool NextResult()
        {
            if (this._results.Count > 0)
            {
                if (this._currentResultIndex < this._results.Count - 1)
                {
                    this._currentResultIndex++;
                    this._currentIndex = -1;
                    return true;
                }
            }

            return false;
        }

        public override bool Read()
        {
            if (this._results.Count > 0)
            {
                if (this._currentIndex < this._results[this._currentResultIndex].Count - 1)
                {
                    this._currentIndex++;
                    return true;
                }
            }

            return false;
        }

        private T GetValue<T>(int ordinal)
        {
            int index = 0;

            foreach (var value in this._results[this._currentResultIndex][this._currentIndex].Values)
            {
                if (index == ordinal)
                {
                    return (T)value;
                }

                index++;
            }

            throw new IndexOutOfRangeException("");
        }
    }
}
