namespace EConnect.Interfaces
{
    /// <summary>
    /// Interface for creating parsers.
    /// </summary>
    public interface IParserFactory
    {
        /// <summary>
        /// Creates Parser for specific Type.
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <returns>Object implementing IBaseParser interface for specific Type.</returns>
        IBaseParser CreateParser<TModel>();
    }
}