namespace Dapper.FastCrud.Dto.Mappings.Builders
{
    using System;
    using System.Linq.Expressions;
    using Dapper.FastCrud.DtoRepository;

    public class DestinationMappingBuilder<TSource, TDestination>
    {
        private UnifyingMapping _unifyingMapping;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public DestinationMappingBuilder(UnifyingMapping unifyingMapping)
        {
            Requires.NotNull(unifyingMapping, nameof(unifyingMapping));

            _unifyingMapping = unifyingMapping;
        }

        public SourcePropertyMapping<TSource, TDestination, TSourcePropValue> Property<TSourcePropValue>(Expression<Func<TSource, TSourcePropValue>> sourceProperty)
        {
            //_propertyName = ((MemberExpression)propertyDefinition.Body).Member.Name;
            return new SourcePropertyMapping<TSource, TDestination, TSourcePropValue>();
        }

        public SourcePropertiesMappingBuilder<TSource, TDestination> FromProperties(params Expression<Func<TSource, object>>[] propertyNames)
        {
            //_propertyName = ((MemberExpression)propertyDefinition.Body).Member.Name;
            return new SourcePropertiesMappingBuilder<TSource, TDestination>(_unifyingMapping, propertyNames);
        }
    }
}
