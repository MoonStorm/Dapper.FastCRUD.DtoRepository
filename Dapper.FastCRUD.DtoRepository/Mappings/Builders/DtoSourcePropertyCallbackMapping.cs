namespace Dapper.FastCrud.Dto.Mappings
{
    using System;
    using System.Linq.Expressions;

    public class DtoSourcePropertyCallbackMapping<TSource, TDestination, TSourceValueProperty>
    {
        public DtoSourcePropertyCallbackMapping<TSource, TDestination, TSourceValueProperty> To<TDestinationValueProperty>(
            Expression<Func<TDestination, TDestinationValueProperty>> destinationProperty)
        {
            return this;
        }


    }
}
