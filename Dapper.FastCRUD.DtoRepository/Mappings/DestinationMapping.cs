namespace Dapper.FastCrud.DtoRepository.Mappings
{
    using System;
    using System.Linq.Expressions;
    using Dapper.FastCrud.DtoRepository.Converters;

    public class DestinationMapping<TSource, TDestination>
    {
        private CombinedEntityConverter _combinedEntityConverter;

        public DestinationMapping(CombinedEntityConverter combinedEntityConverter)
        {
            _combinedEntityConverter = combinedEntityConverter;
        }

        public SourcePropertyMapping<TSource, TDestination, TSourcePropValue> FromProperty<TSourcePropValue>(Expression<Func<TSource, TSourcePropValue>> sourceProperty)
        {
            //_propertyName = ((MemberExpression)propertyDefinition.Body).Member.Name;
        }

        public DtoSourceDestinationCustomMapping<TSource, TDestination> Custom(params )
        {
            //_propertyName = ((MemberExpression)propertyDefinition.Body).Member.Name;
        }
    }
}
