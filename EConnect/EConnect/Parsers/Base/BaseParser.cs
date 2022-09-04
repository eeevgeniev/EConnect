using System;
using System.Data.Common;

namespace EConnect.Parsers.Base
{
    /// <summary>
    /// Base, helper class for parser, adds not null validation for DbDataReader
    /// </summary>
    internal abstract class BaseParser
    {
        protected void ValidateDbDataReader(DbDataReader dbDataReader)
        {
            if (dbDataReader == null)
            {
                throw new ArgumentNullException($"Parameter {nameof(dbDataReader)} is null.");
            }
        }
    }
}
