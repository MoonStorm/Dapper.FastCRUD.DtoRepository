namespace Dapper.FastCrud.Dto.Converters.Entity
{
    using System;
    using Dapper.FastCrud.Dto.Entity.Converters;
    using Dapper.FastCrud.DtoRepository;

    /// <summary>
    /// Entity converter using a callback.
    /// </summary>
    public class TypedEntityCallbackConverter<TSource, TDestination>:TypedEntityConverter<TSource, TDestination>
    {
        private Action<TSource, TDestination, ContextStore> _conversionCallback;

        /// <summary>
        /// Constructor
        /// </summary>
        public TypedEntityCallbackConverter(Action<TSource, TDestination, ContextStore> conversionCallback)
        {
            Requires.NotNull(conversionCallback, nameof(conversionCallback));
            _conversionCallback = conversionCallback;
        }

        /// <summary>
        /// Converts a source to a destination.
        /// </summary>
        protected override void Convert(TSource source, TDestination destination, ContextStore userContextStore)
        {
            _conversionCallback(source, destination, userContextStore);
        }
    }
}
