using System;

namespace SQLEConnect.Interfaces
{
    /// <summary>
    /// Base interface for parsers.
    /// </summary>
    public interface IBaseParser
    {
        /// <summary>
        /// The Type for which the parser is responible.
        /// </summary>
        /// <returns>Type</returns>
        Type Type();
    }
}
