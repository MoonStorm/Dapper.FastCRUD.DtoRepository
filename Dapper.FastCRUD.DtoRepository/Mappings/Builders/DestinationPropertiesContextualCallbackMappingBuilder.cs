namespace Dapper.FastCrud.Dto.Mappings.Builders
{
    using System;
    using Dapper.FastCrud.Dto.Converters;
    using Dapper.FastCrud.DtoRepository;
    using Dapper.FastCrud.DtoRepository.Registrations;

    /// <summary>
    /// Partial builder for a source, a destination, a set of properties, and a context.
    /// </summary>
    public class DestinationPropertiesContextualCallbackMappingBuilder<TSource, TDestination, TContext>
    {
        private readonly UnifyingMapping _unifyingMapping;
        private readonly TypedEntityPropertyRegistrations<TSource> _sourcePropertyRegistrations;
        private readonly TypedEntityPropertyRegistrations<TDestination> _destinationPropertyRegistrations;
        private readonly Func<TSource, TContext> _contextResolver;

        public DestinationPropertiesContextualCallbackMappingBuilder(
            UnifyingMapping unifyingMapping,
            TypedEntityPropertyRegistrations<TSource> sourcePropertyRegistrations,
            TypedEntityPropertyRegistrations<TDestination> destinationPropertyRegistrations,
            Func<TSource, TContext> contextResolver = null )
        {
            Requires.NotNull(unifyingMapping, nameof(unifyingMapping));
            Requires.NotNull(sourcePropertyRegistrations, nameof(sourcePropertyRegistrations));
            Requires.NotNull(destinationPropertyRegistrations, nameof(destinationPropertyRegistrations));
            Requires.Range(sourcePropertyRegistrations.Count > 0, $"Please provide all the properties used in the conversion of '{typeof(TSource)}' to '{typeof(TDestination)}'.");
            Requires.Range(destinationPropertyRegistrations.Count > 0, $"Please provide all the properties used in the conversion of '{typeof(TSource)}' to '{typeof(TDestination)}'.");

            _unifyingMapping = unifyingMapping;
            _sourcePropertyRegistrations = sourcePropertyRegistrations;
            _destinationPropertyRegistrations = destinationPropertyRegistrations;
            _contextResolver = contextResolver;
        }

        /// <summary>
        /// Converts between the source and destination using a mandatory callback.
        /// </summary>
        public DestinationPropertiesCallbackMappingBuilder<TSource, TDestination> UsingCallback(Action<TSource, TContext, TDestination> conversionAction)
        {
            Requires.NotNull(conversionAction, nameof(conversionAction));

            return new DestinationPropertiesCallbackMappingBuilder<TSource, TDestination>(
                _unifyingMapping,
                _sourcePropertyRegistrations, 
                _destinationPropertyRegistrations,
                (source, destination, typedStore) => conversionAction(source, this.ResolveContext(source, typedStore), destination));
        }

        private TContext ResolveContext(TSource source, TypedObjectStore contextStore)
        {
            TContext context;
            if (_contextResolver != null)
            {
                context = _contextResolver(source);
            }
            else
            {
                context = contextStore.Get<TContext>();
            }

            return context;
        }
    }
}
