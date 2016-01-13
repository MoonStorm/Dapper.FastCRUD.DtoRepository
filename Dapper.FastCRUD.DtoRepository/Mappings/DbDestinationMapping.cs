namespace Dapper.FastCrud.DtoRepository.Mappings
{
    using System;
    using System.Linq.Expressions;

    public class DbDestinationMapping<TSource, TDestination>
    {
        public DtoSourcePropertyMapping<TSource, TDestination, TSourcePropValue> FromProperty<TSourcePropValue>(Expression<Func<TSource, TSourcePropValue>> sourceProperty)
        {
            //_propertyName = ((MemberExpression)propertyDefinition.Body).Member.Name;
        }

        public DtoSourceDestinationCustomMapping<TSource, TDestination> Custom(params )
        {
            //_propertyName = ((MemberExpression)propertyDefinition.Body).Member.Name;
        }
    }
}
