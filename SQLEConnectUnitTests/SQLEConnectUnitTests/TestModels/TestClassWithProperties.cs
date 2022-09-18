using System;
using System.IO;

namespace SQLEConnectUnitTests.TestModels
{
    public class TestClassWithProperties
    {
        public byte IsByte { get; set; }

        public byte? IsNullableByte { get; set; }

        public bool IsBool { get; set; }

        public bool? IsNullableBool { get; set; }

        public byte[] Bytes { get; set; }

        public char[] Chars { get; set; }

        public char IsChar { get; set; }

        public char? IsNullableChar { get; set; }

        public DateTime IsDateTime { get; set; }

        public DateTime? IsNullableDateTime { get; set; }

        public decimal IsDecimal { get; set; }

        public decimal? IsNullableDecimal { get; set; }

        public double IsDouble { get; set; }

        public double? IsNullableDouble { get; set; }

        public float IsFloat { get; set; }

        public float? IsNullableFloat { get; set; }

        public Guid IsGuid { get; set; }

        public Guid? IsNullableGuid { get; set; }

        public int IsInt { get; set; }

        public int? IsNullableInt { get; set; }

        public long IsLong { get; set; }

        public long? IsNullableLong { get; set; }

        public sbyte IsSByte { get; set; }

        public sbyte? IsNullableSByte { get; set; }

        public short IsShort { get; set; }

        public short? IsNullabelShort { get; set; }

        public Stream IsStream { get; set; }

        public string IsString { get; set; }

        public uint IsUInt { get; set; }

        public uint? IsNullableUInt { get; set; }

        public ulong IsULong { get; set; }

        public ulong? IsNullableULong { get; set; }

        public ushort IsUShort { get; set; }

        public ushort? IsNullableUShort { get; set; }
    }
}
