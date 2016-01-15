namespace Dapper.FastCrud.DtoRepository.Converters
{
    using System;

    /// <summary>
    /// DTO to DB entity to entity custom converter using callbacks.
    /// </summary>
    public class CallbackEntityConverter<TSource,TDestination>:TypedEntityConverter<TSource, TDestination>
    {
        private readonly Action<TSource, TDestination, GenericTypeObjectMap> _conversionCallback;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CallbackEntityConverter(Action<TSource, TDestination, GenericTypeObjectMap> conversionFct)
        {
            Requires.NotNull(conversionFct, nameof(conversionFct));

            _conversionCallback = conversionFct;
        }

        /// <summary>
        /// Called to set up a destination from a source entity and available user contexts.
        /// </summary>
        protected override void Convert(TSource source, TDestination destination, GenericTypeObjectMap userContexts)
        {
            _conversionCallback(source, destination, userContexts);
        }
    }
}
