using System;
using System.Text;

namespace SQLEConnectTests.Models
{
    public  class Constants
    {
        public static byte ByteNumber2 { get; } = 1;
        public static byte? NullableByteNumber2 { get; } = 2;
        public static bool BoolValue2 { get; } = true;
        public static bool? NullableBoolValue2 { get; } = true;
        public static byte[] Bytes2 { get; } = new byte[] { 1, 2, 3 };
        public static string Chars2 { get; } = "abc";
        public static char Letter2 { get; } = 'd';
        public static char? NullableLetter2 { get; } = 'e';
        public static DateTime DateTimeValue2 { get; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        public static DateTime? NullableDateTimeValue2 { get; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second).AddDays(1);
        public static decimal? DecimalNumber2 { get; } = 99.9M;
        public static decimal NullableDecimalNumber2 { get; } = 88.8M;
        public static double DoubleNumber2 { get; } = 12.44D;
        public static double? NullableDoubleNumber2 { get; } = 12.44D;
        public static float FloatNumber2 { get; } = 12.5F;
        public static float? NullableFloatNumber2 { get; } = 14.5F;
        public static Guid GuidValue2 { get; } = Guid.NewGuid();
        public static Guid? NullableGuidValue2 { get; } = Guid.NewGuid();
        public static int IntNumber2 { get; } = 22;
        public static int? NullableIntNumber2 { get; } = 33;
        public static long LongNumber2 { get; } = 44;
        public static long? NullableLongNumber2 { get; } = 55;
        public static byte SByteNumber2 { get; } = 66;
        public static byte? NullableSByteNumber2 { get; } = 77;
        public static short ShortNumber2 { get; } = 88;
        public static short? NullableShortNumber2 { get; } = 99;
        public static byte[] StreamValue2 { get; } = Encoding.UTF8.GetBytes("Hello world");
        public static string StringValue2 { get; } = "Bye world";
        public static int UIntNumber2 { get; } = 45;
        public static int? NullableUIntNumber2 { get; } = 101;
        public static long ULongNumber2 { get; } = 14;
        public static long? NullableULongNumber2 { get; } = 19;
        public static short UShortNumber2 { get; } = 32;
        public static short? NullableUShortNumber2 { get; } = 23;
    }
}
