namespace Dapper.FastCrud.Dto.Mappings.Builders
{
    using System;
    using Dapper.FastCrud.DtoRepository;
    using Dapper.FastCrud.DtoRepository.Registrations;

    /// <summary>
    /// Partial builder for a source and a set of properties
    /// </summary>
    public class DestinationPropertiesMappingBuilder<TSource, TDestination>
    {
        private readonly UnifyingMapping _unifyingMapping;
        private readonly TypedEntityPropertyRegistrations<TSource> _sourcePropertyRegistrations;
        private readonly TypedEntityPropertyRegistrations<TDestination> _destinationPropertyRegistrations;

        public DestinationPropertiesMappingBuilder(
            UnifyingMapping unifyingMapping,
            TypedEntityPropertyRegistrations<TSource> sourcePropertyRegistrations,
            TypedEntityPropertyRegistrations<TDestination> destinationPropertyRegistrations)
        {
            Requires.NotNull(unifyingMapping, nameof(unifyingMapping));
            Requires.NotNull(sourcePropertyRegistrations, nameof(sourcePropertyRegistrations));
            Requires.NotNull(destinationPropertyRegistrations, nameof(destinationPropertyRegistrations));

            Requires.Range(sourcePropertyRegistrations.Count > 0, $"Please provide all the properties used in the conversion of '{typeof(TSource)}' to '{typeof(TDestination)}'.");
            Requires.Range(destinationPropertyRegistrations.Count > 0, $"Please provide all the properties used in the conversion of '{typeof(TSource)}' to '{typeof(TDestination)}'.");

            _unifyingMapping = unifyingMapping;
            _sourcePropertyRegistrations = sourcePropertyRegistrations;
            _destinationPropertyRegistrations = destinationPropertyRegistrations;
        }

        /// <summary>
        /// Converts between the source and destination using a mandatory callback.
        /// </summary>
        public DestinationPropertiesCallbackMappingBuilder<TSource, TDestination> UsingCallback(Action<TSource, TDestination> conversionAction)
        {
            Requires.NotNull(conversionAction, nameof(conversionAction));

            return new DestinationPropertiesCallbackMappingBuilder<TSource, TDestination>(
                _unifyingMapping,
                _sourcePropertyRegistrations,
                _destinationPropertyRegistrations,
                (source, destination, typedStore) =>
                {
                    conversionAction(source, destination);
                });
        }

        /// <summary>
        /// Converts between the source and destination using a context.
        /// </summary>
        public DestinationPropertiesContextualCallbackMappingBuilder<TSource, TDestination, TContext> WithContext<TContext>(TContext context)
        {
            return WithContextResolver<TContext>((source) => context);
        }

        /// <summary>
        /// Converts between the source and destination using a context.
        /// </summary>
        public DestinationPropertiesContextualCallbackMappingBuilder<TSource, TDestination, TContext> WithContextResolver<TContext>(Func<TSource,TContext> contextResolverFunc)
        {
            Requires.NotNull(contextResolverFunc, nameof(contextResolverFunc));

            return new DestinationPropertiesContextualCallbackMappingBuilder<TSource, TDestination, TContext>(
                _unifyingMapping,
                _sourcePropertyRegistrations,
                _destinationPropertyRegistrations,
                contextResolverFunc);
        }

        /// <summary>
        /// Converts between the source and destination using a context resolved at the moment of conversion.
        /// </summary>
        public DestinationPropertiesContextualCallbackMappingBuilder<TSource, TDestination, TContext> WithDynamicContext<TContext>()
        {
            return new DestinationPropertiesContextualCallbackMappingBuilder<TSource, TDestination, TContext>(
                _unifyingMapping,
                _sourcePropertyRegistrations,
                _destinationPropertyRegistrations);
        }
    }
}
