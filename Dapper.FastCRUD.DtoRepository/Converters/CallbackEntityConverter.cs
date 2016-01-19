namespace Dapper.FastCrud.Dto.Converters
{
    using System;
    using Dapper.FastCrud.DtoRepository;
    using Dapper.FastCrud.DtoRepository.Registrations;

    /// <summary>
    /// DTO to DB entity to entity custom converter using callbacks.
    /// </summary>
    public class CallbackEntityConverter<TSource,TDestination>:TypedEntityConverter<TSource, TDestination>
    {
        private readonly Action<TSource, TDestination, TypedObjectStore> _conversionCallback;

        /// <summary>
        /// Constructor that takes a conversion callback as a parameter.
        /// </summary>
        public CallbackEntityConverter(Action<TSource, TDestination, TypedObjectStore> conversionFct)
        {
            Requires.NotNull(conversionFct, nameof(conversionFct));

            _conversionCallback = conversionFct;
        }

        /// <summary>
        /// Constructor that takes a conversion callback as a parameter, plus source and destination registrations.
        /// </summary>
        public CallbackEntityConverter(
            Action<TSource, TDestination, TypedObjectStore> conversionCallback,
            TypedEntityPropertyRegistrations<TSource> sourcePropertyRegistrations, 
            TypedEntityPropertyRegistrations<TDestination> destinationPropertyRegistrations)
            : base(sourcePropertyRegistrations, destinationPropertyRegistrations)
        {
            _conversionCallback = conversionCallback;
        }

        /// <summary>
        /// Called to set up a destination from a source entity and available user contexts.
        /// </summary>
        protected override void Convert(TSource source, TDestination destination, TypedObjectStore userContexts)
        {
            _conversionCallback(source, destination, userContexts);
        }
    }
}
