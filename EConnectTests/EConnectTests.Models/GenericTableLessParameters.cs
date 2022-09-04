using System;

namespace EConnectTests.Models
{
    public class GenericTableLessParameters
    {
        public byte ByteNumber { get; set; }

        public byte? NullableByteNumber { get; set; }

        public bool BoolValue { get; set; }

        public bool? NullableBoolValue { get; set; }

        public byte[] Bytes { get; set; }

        public char? NullableLetter { get; set; }

        public DateTime DateTimeValue { get; set; }

        public DateTime? NullableDateTimeValue { get; set; }

        public decimal DecimalNumber { get; set; }

        public decimal? NullableDecimalNumber { get; set; }

        public double DoubleNumber { get; set; }

        public double? NullableDoubleNumber { get; set; }

        public float FloatNumber { get; set; }

        public float? NullableFloatNumber { get; set; }

        public Guid GuidValue { get; set; }

        public Guid? NullableGuidValue { get; set; }

        public int IntNumber { get; set; }

        public int? NullableIntNumber { get; set; }

        public long LongNumber { get; set; }

        public long? NullableLongNumber { get; set; }

        public sbyte SByteNumber { get; set; }

        public sbyte? NullableSByteNumber { get; set; }

        public short ShortNumber { get; set; }

        public short? NullableShortNumber { get; set; }

        public string StringValue { get; set; }

        public uint UIntNumber { get; set; }

        public uint? NullableUIntNumber { get; set; }

        public ulong ULongNumber { get; set; }

        public ulong? NullableULongNumber { get; set; }

        public ushort UShortNumber { get; set; }

        public ushort? NullableUShortNumber { get; set; }
    }
}
