using EConnect.Infrastructure;
using System;
using System.Data;
using System.Data.Common;

namespace EConnect
{
    /// <summary>
    /// Base class for passing SqlParameters.
    /// Implements IDataParameter and IDbDataParameter.
    /// Return correct DbParameter, based on the DbCommand type (ConvertToDbParameter method).
    /// </summary>
    public class SqlEParameter : IDataParameter, IDbDataParameter
    {
        /// <summary>
        /// Constructor to create initial SqlEParameter with parameter name and default value.
        /// </summary>
        /// <param name="parameterName">String the name of the parameter must includes the prefix (for example: @).</param>
        /// <param name="value">The value of the parameter.</param>
        public SqlEParameter(string parameterName, object value)
        {
            this.SetInitialProperties(parameterName, value);
        }

        /// <summary>
        /// Constructor to create parameter with DBNull value and correct SqlType based on the Type parameter.
        /// </summary>
        /// <param name="parameterName">String the name of the parameter must includes the prefix (for example: @).</param>
        /// <param name="type">Type - used to correctly create the SqlType.</param>
        public SqlEParameter(string parameterName, Type type)
        {
            this.SetInitialProperties(parameterName, null, type);
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="other">SqlEParameter - must not be null</param>
        /// <exception cref="ArgumentNullException">If other is null.</exception>
        internal SqlEParameter(SqlEParameter other)
        {
            if (other == null)
            {
                throw new ArgumentNullException($"Parameter {nameof(other)} cannot be null.");
            }

            this.SetInitialProperties(other.ParameterName, other.Value);

            this.DbType = other.DbType;
            this.Direction = other.Direction;
            this.IsNullable = other.IsNullable;
            this.SourceColumn = other.SourceColumn;
            this.SourceVersion = other.SourceVersion;
            this.Precision = other.Precision;
            this.Scale = other.Scale;
            this.Size = other.Size;
            this.SourceColumnNullMapping = other.SourceColumnNullMapping;
        }

        /// <summary>
        /// Overrides base implementation.
        /// </summary>
        public string ParameterName { get; set; }

        /// <summary>
        /// Overrides base implementation.
        /// </summary>
        public object Value { get; set;  }

        /// <summary>
        /// Overrides base implementation.
        /// </summary>
        public DbType DbType { get; set; }

        /// <summary>
        /// Overrides base implementation.
        /// </summary>
        public ParameterDirection Direction { get; set; } = ParameterDirection.Input;

        /// <summary>
        /// Overrides base implementation.
        /// </summary>
        public bool IsNullable { get; set; }

        /// <summary>
        /// Overrides base implementation.
        /// </summary>
        public string SourceColumn { get; set; }

        /// <summary>
        /// Overrides base implementation.
        /// </summary>
        public DataRowVersion SourceVersion { get; set; } = DataRowVersion.Current;

        /// <summary>
        /// Overrides base implementation.
        /// </summary>
        public byte Precision { get; set; }

        /// <summary>
        /// Overrides base implementation.
        /// </summary>
        public byte Scale { get; set; }

        /// <summary>
        /// Overrides base implementation.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Overrides base implementation.
        /// </summary>
        public bool SourceColumnNullMapping { get; set; }

        /// <summary>
        /// Converts the parameter to correct DbParameter for the spcific DbCommand implementation.
        /// </summary>
        internal DbParameter ConvertToDbParameter(DbCommand dbCommand)
        {
            if (dbCommand == null)
            {
                throw new ArgumentNullException($"Parameter {nameof(dbCommand)} is null");
            }

            DbParameter dbParameter = dbCommand.CreateParameter();

            dbParameter.ParameterName = this.ParameterName;
            dbParameter.Value = this.Value != null ? this.Value : DBNull.Value;
            dbParameter.DbType = this.DbType;
            dbParameter.Direction = this.Direction;

            dbParameter.IsNullable = this.Value != null ? this.IsNullable : true;
            dbParameter.SourceColumn = this.SourceColumn != default ? this.SourceColumn : default;
            dbParameter.SourceVersion = this.SourceVersion != default ? this.SourceVersion : default;
            
            if (this.Precision != default)
            {
                dbParameter.Precision = this.Precision;
            }

            if (this.Scale != default)
            {
                dbParameter.Scale = this.Scale;
            }

            if (this.Size != default)
            {
                dbParameter.Size = this.Size;
            }

            dbParameter.SourceColumnNullMapping = this.SourceColumnNullMapping;

            return dbParameter;
        }

        private void SetInitialProperties(string parameterName, object value, Type type = null)
        {
            if (string.IsNullOrWhiteSpace(parameterName))
            {
                throw new ArgumentException($"Parameter {nameof(parameterName)} cannot be null or white space.");
            }

            this.ParameterName = parameterName;
            this.Value = value;

            Type valueType = this.Value != null ? this.Value.GetType() : type;

            if (valueType == null)
            {
                return;
            }

            if (valueType == BaseTypeHelper.StringType)
            {
                this.DbType = DbType.String;
            }
            else if (valueType == BaseTypeHelper.ByteType)
            {
                this.DbType = DbType.Byte;
            }
            else if (valueType == BaseTypeHelper.NullableByteType)
            {
                this.DbType = DbType.Byte;
            }
            else if (valueType == BaseTypeHelper.ShortType)
            {
                this.DbType = DbType.Int16;
            }
            else if (valueType == BaseTypeHelper.NullableShortType)
            {
                this.DbType = DbType.Int16;
            }
            else if (valueType == BaseTypeHelper.IntegerType)
            {
                this.DbType = DbType.Int32;
            }
            else if (valueType == BaseTypeHelper.NullableIntegerType)
            {
                this.DbType = DbType.Int32;
            }
            else if (valueType == BaseTypeHelper.LongType)
            {
                this.DbType = DbType.Int64;
            }
            else if (valueType == BaseTypeHelper.NullableLongType)
            {
                this.DbType = DbType.Int64;
            }
            else if (valueType == BaseTypeHelper.FloatType)
            {
                this.DbType = DbType.Single;
            }
            else if (valueType == BaseTypeHelper.NullableFloatType)
            {
                this.DbType = DbType.Single;
            }
            else if (valueType == BaseTypeHelper.DoubleType)
            {
                this.DbType = DbType.Double;
            }
            else if (valueType == BaseTypeHelper.NullableDoubleType)
            {
                this.DbType = DbType.Double;
            }
            else if (valueType == BaseTypeHelper.DecimalType)
            {
                this.DbType = DbType.Decimal;
            }
            else if (valueType == BaseTypeHelper.NullableDecimalType)
            {
                this.DbType = DbType.Decimal;
            }
            else if (valueType == BaseTypeHelper.DateTimeType)
            {
                this.DbType = DbType.DateTime2;
            }
            else if (valueType == BaseTypeHelper.NullableDateTimeType)
            {
                this.DbType = DbType.DateTime2;
            }
            else if (valueType == BaseTypeHelper.BooleanType)
            {
                this.DbType = DbType.Boolean;
            }
            else if (valueType == BaseTypeHelper.CharType)
            {
                this.DbType = DbType.String;
            }
            else if (valueType == BaseTypeHelper.NullableCharType)
            {
                this.DbType = DbType.String;
            }
            else if (valueType == BaseTypeHelper.NullableBooleanType)
            {
                this.DbType = DbType.Boolean;
            }
            else if (valueType == BaseTypeHelper.GuidType)
            {
                this.DbType = DbType.Guid;
            }
            else if (valueType == BaseTypeHelper.NullableGuidType)
            {
                this.DbType = DbType.Guid;
            }
            else if (valueType == BaseTypeHelper.ByteArrayType)
            {
                this.DbType = DbType.Binary;
            }
            else if (valueType == BaseTypeHelper.CharArrayType)
            {
                this.DbType = DbType.String;
            }
            else if (valueType == BaseTypeHelper.SByteType)
            {
                this.DbType = DbType.SByte;
            }
            else if (valueType == BaseTypeHelper.NullableSByteType)
            {
                this.DbType = DbType.SByte;
            }
            else if (valueType == BaseTypeHelper.UShortType)
            {
                this.DbType = DbType.UInt16;
            }
            else if (valueType == BaseTypeHelper.NullableUShortType)
            {
                this.DbType = DbType.UInt16;
            }
            else if (valueType == BaseTypeHelper.UIntegerType)
            {
                this.DbType = DbType.UInt32;
            }
            else if (valueType == BaseTypeHelper.NullableUIntegerType)
            {
                this.DbType = DbType.UInt32;
            }
            else if (valueType == BaseTypeHelper.ULongType)
            {
                this.DbType = DbType.UInt64;
            }
            else if (valueType == BaseTypeHelper.NullableULongType)
            {
                this.DbType = DbType.UInt64;
            }
        }
    }
}