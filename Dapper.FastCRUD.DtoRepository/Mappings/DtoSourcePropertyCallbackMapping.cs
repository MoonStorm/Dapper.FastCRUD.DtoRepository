using System;
using System.Linq.Expressions;

namespace Dapper.FastCrud.DtoRepository.Mappings
{
    public class DtoSourcePropertyCallbackMapping<TSource, TDestination, TSourceValueProperty>
    {
        public DtoSourcePropertyCallbackMapping<TSource, TDestination, TSourceValueProperty> To<TDestinationValueProperty>(
            Expression<Func<TDestination, TDestinationValueProperty>> destinationProperty)
        {
            return this;
        }


    }
}
