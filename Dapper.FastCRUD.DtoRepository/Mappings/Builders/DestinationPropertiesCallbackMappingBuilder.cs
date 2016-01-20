namespace Dapper.FastCrud.Dto.Mappings.Builders
{
    using System;
    using Dapper.FastCrud.Dto.Converters;
    using Dapper.FastCrud.DtoRepository;
    using Dapper.FastCrud.DtoRepository.Registrations;

    /// <summary>
    /// Partial builder for a source and a set of properties
    /// </summary>
    public class DestinationPropertiesCallbackMappingBuilder<TSource, TDestination>:DestinationTransitionalMappingBuilder<TSource, TDestination>
    {
        private readonly TypedEntityPropertyRegistrations<TSource> _sourcePropertyRegistrations;
        private readonly TypedEntityPropertyRegistrations<TDestination> _destinationPropertyRegistrations;
        private readonly Action<TSource, TDestination, TypedObjectStore> _callbackAction;

        internal DestinationPropertiesCallbackMappingBuilder(
            UnifyingMapping unifyingMapping,
            TypedEntityPropertyRegistrations<TSource> sourcePropertyRegistrations,
            TypedEntityPropertyRegistrations<TDestination> destinationPropertyRegistrations,
            Action<TSource, TDestination, TypedObjectStore> callbackAction)
            :base(unifyingMapping)
        {
            Requires.NotNull(sourcePropertyRegistrations, nameof(sourcePropertyRegistrations));
            Requires.NotNull(destinationPropertyRegistrations, nameof(destinationPropertyRegistrations));
            Requires.NotNull(callbackAction, nameof(callbackAction));

            _callbackAction = callbackAction;
            _sourcePropertyRegistrations = sourcePropertyRegistrations;
            _destinationPropertyRegistrations = destinationPropertyRegistrations;            
        }

        protected override void PrepareMapping(UnifyingMapping mapping)
        {
            base.PrepareMapping(mapping);

            var sourceToDestinationConverter = new CallbackEntityConverter<TSource, TDestination>(_callbackAction, _sourcePropertyRegistrations, _destinationPropertyRegistrations);
            mapping.SourceToDestinationConverter.Add(sourceToDestinationConverter);
        }
    }
}
