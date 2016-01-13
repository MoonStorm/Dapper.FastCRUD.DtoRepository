namespace Dapper.FastCrud.DtoRepository.Mappings
{
    using System;
    using System.Linq.Expressions;
    using Dapper.FastCrud.DtoRepository.Converters;

    public class DtoSourcePropertyMapping<TSource, TDestination, TSourcePropertyValue>
    {
        public DtoSourceDestinationPropertyMapping<TSource, TDestination, TSourcePropertyValue, TDestinationPropertyValue> 
            OneWayTo<TDestinationPropertyValue>(Expression<Func<TDestination, TDestinationPropertyValue>> destination)
        {            
        }

        public EntityConverter TwoWayTo<TDestinationPropertyValue>(Expression<Func<TDestination, TDestinationPropertyValue>> destination)
        {

        }
    }
}
