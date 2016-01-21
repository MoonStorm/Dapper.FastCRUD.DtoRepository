namespace Dapper.FastCrud.Dto.Converters.Entity
{
    using Dapper.FastCrud.Dto.Entity.Converters;
    using Dapper.FastCrud.Dto.Registrations;
    using Dapper.FastCrud.DtoRepository;

    /// <summary>
    /// Performs a conversion between two properties.
    /// </summary>
    public class TypedEntityPropertyConverter<TSource, TDestination>:TypedEntityConverter<TSource,TDestination>
    {
        private readonly TypedEntityPropertyRegistration<TSource> _sourceProperty;
        private readonly TypedEntityPropertyRegistration<TDestination> _destinationProperty;

        public TypedEntityPropertyConverter(
            TypedEntityPropertyRegistration<TSource> sourceProperty,
            TypedEntityPropertyRegistration<TDestination> destinationProperty)
        {
            Requires.NotNull(sourceProperty, nameof(sourceProperty));
            Requires.NotNull(destinationProperty, nameof(destinationProperty));

            _sourceProperty = sourceProperty;
            _destinationProperty = destinationProperty;
        }

        /// <summary>
        /// Converts a source to a destination.
        /// </summary>
        protected override void Convert(TSource source, TDestination destination, ContextStore userContextStore)
        {
            var sourceValue = _sourceProperty.GetValue(source);
            _destinationProperty.SetValue(destination, sourceValue);
        }
    }
}
