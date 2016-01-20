namespace Dapper.FastCrud.Dto.Mappings.Builders
{
    using System;
    using System.Linq.Expressions;
    using Dapper.FastCrud.DtoRepository;
    using Dapper.FastCrud.DtoRepository.Registrations;

    public class DestinationMappingBuilder<TSource, TDestination>
    {
        private UnifyingMapping _unifyingMapping;

        /// <summary>
        /// Default constructor.
        /// </summary>
        internal DestinationMappingBuilder(UnifyingMapping unifyingMapping)
        {
            Requires.NotNull(unifyingMapping, nameof(unifyingMapping));

            _unifyingMapping = unifyingMapping;
        }

        /// <summary>
        /// Starts a mapping from a property.
        /// </summary>
        public SourcePropertyMappingBuilder<TSource, TDestination, TSourcePropValue> FromProperty<TSourcePropValue>(
            Expression<Func<TSource, TSourcePropValue>> sourceProperty)
        {
            //_propertyName = ((MemberExpression)propertyDefinition.Body).Member.Name;

            var propRegistrations = new TypedEntityPropertyRegistrations<TSource>();
            propRegistrations.Add(sourceProperty);

            return new SourcePropertyMappingBuilder<TSource, TDestination, TSourcePropValue>(_unifyingMapping, propRegistrations);
        }

        /// <summary>
        /// Starts a mapping from a set of properties.
        /// </summary>
        public SourcePropertiesMappingBuilder<TSource, TDestination> FromProperties(params Expression<Func<TSource, object>>[] propertyNames)
        {
            //_propertyName = ((MemberExpression)propertyDefinition.Body).Member.Name;
            return new SourcePropertiesMappingBuilder<TSource, TDestination>(
                _unifyingMapping,
                new TypedEntityPropertyRegistrations<TSource>(propertyNames));
        }
    }
}
