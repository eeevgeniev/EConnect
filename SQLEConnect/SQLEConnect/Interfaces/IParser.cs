using System.Collections.Generic;
using System.Data.Common;

namespace SQLEConnect.Interfaces
{
    /// <summary>
    /// Base interface for creating Parsers.
    /// </summary>
    /// <typeparam name="TModel">One of the supported types. Look in BaseTypeHelper.</typeparam>
    public interface IParser<TModel> : IBaseParser
    {
        /// <summary>
        /// Reads results from DbDataReader and returns IEnumerable of objects of type TModel.
        /// </summary>
        /// <param name="dbDataReader">DbDataReader.</param>
        /// <returns>List of objects of type TModel.</returns>
        IEnumerable<TModel> Parse(DbDataReader dbDataReader);

        /// <summary>
        /// Reads results from DbDataReader and returns only the first result.
        /// </summary>
        /// <param name="dbDataReader">DbDataReader</param>
        /// <returns>Tuple with two values: hasResult - Boolean if any result is returned and TModel - the first result if hasResult is false, TModel is equal to default for the specific Type</returns>
        (bool hasResult, TModel result) ParseSingle(DbDataReader dbDataReader);
    }
}