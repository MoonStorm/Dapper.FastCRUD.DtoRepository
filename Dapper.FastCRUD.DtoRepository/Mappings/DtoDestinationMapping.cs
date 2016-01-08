using System;
using System.Linq.Expressions;

namespace Dapper.FastCrud.DtoRepository.Mappings
{
    public class DtoDestinationMapping<TSource, TDestination>
    {
        public DtoSourcePropertyMapping<TSource, TDestination, TSourcePropValue> From<TSourcePropValue>(Expression<Func<TSource, TSourcePropValue>> sourceProperty)
        {
            //_propertyName = ((MemberExpression)propertyDefinition.Body).Member.Name;
        }

        public DtoSourceDestinationCustomMapping<TSource, TDestination> Custom(params )
        {
            //_propertyName = ((MemberExpression)propertyDefinition.Body).Member.Name;
        }
    }
}
