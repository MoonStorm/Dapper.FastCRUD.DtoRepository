namespace Dapper.FastCrud.Dto.Mappings
{
    using System;
    using System.Linq.Expressions;
    using Dapper.FastCrud.Dto.Converters;
    using Dapper.FastCrud.Dto.Mappings.Builders;
    using Dapper.FastCrud.DtoRepository;
    using Dapper.FastCrud.DtoRepository.Registrations;

    /// <summary>
    /// Represents a mapping builder for a single source property.
    /// </summary>
    public class SourcePropertyMappingBuilder<TSource, TDestination, TSourcePropertyValue>
    {
        private readonly TypedEntityPropertyRegistrations<TSource> _sourcePropertyRegistrations;
        private readonly UnifyingMapping _unifyingMapping;

        /// <summary>
        /// Constructor that takes a single property registration.
        /// </summary>
        internal SourcePropertyMappingBuilder(UnifyingMapping unifyingMapping, TypedEntityPropertyRegistrations<TSource> sourcePropertyRegistrations)
        {
            Requires.NotNull(unifyingMapping, nameof(unifyingMapping));
            Requires.NotNull(sourcePropertyRegistrations, nameof(sourcePropertyRegistrations));
            Requires.Range(sourcePropertyRegistrations.Count == 1, nameof(sourcePropertyRegistrations), $"A single property registration is required.");

            _unifyingMapping = unifyingMapping;
            _sourcePropertyRegistrations = sourcePropertyRegistrations;
        }

        /// <summary>
        ///Creates a one way mapping with a destination property. 
        /// </summary>
        public DestinationTransitionalMappingBuilder<TSource, TDestination> 
            OneWayToPropert(Expression<Func<TDestination, TSourcePropertyValue>> destinationProperty)
        {
            var destinationPropertyRegistrations = new TypedEntityPropertyRegistrations<TDestination>();
            destinationPropertyRegistrations.Add(destinationProperty);

            var converter = new PropertyEntityConverter<TSource, TDestination>(_sourcePropertyRegistrations, destinationPropertyRegistrations);
            _unifyingMapping.SourceToDestinationConverter.Add(converter);

            return new DestinationTransitionalMappingBuilder<TSource, TDestination>(_unifyingMapping);
        }

        /// <summary>
        ///Creates a one way mapping with a destination property. 
        /// </summary>
        public DestinationTransitionalMappingBuilder<TSource, TDestination> 
            TwoWayToProperty(Expression<Func<TDestination, TSourcePropertyValue>> destinationProperty)
        {
            var destinationPropertyRegistrations = new TypedEntityPropertyRegistrations<TDestination>();
            destinationPropertyRegistrations.Add(destinationProperty);

            var sourceToDestConverter = new PropertyEntityConverter<TSource, TDestination>(_sourcePropertyRegistrations, destinationPropertyRegistrations);
            var destToSourceConverter = new PropertyEntityConverter<TSource, TDestination>(_sourcePropertyRegistrations, destinationPropertyRegistrations);

            _unifyingMapping.SourceToDestinationConverter.Add(sourceToDestConverter);
            _unifyingMapping.DestinationToSourceConverter.Add(destToSourceConverter);

            return new DestinationTransitionalMappingBuilder<TSource, TDestination>(_unifyingMapping);
        }
    }
}
