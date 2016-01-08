namespace Dapper.FastCrud.DtoRepository.Mappings
{
    using System;
    using System.Linq.Expressions;

    public class DtoSourcePropertyMapping<TSource, TDestination, TSourcePropertyValue>
    {
        public DtoSourceDestinationPropertyMapping<TSource, TDestination, TSourcePropertyValue, TDestinationPropertyValue> 
            OneWay<TDestinationPropertyValue>(Expression<Func<TDestination, TDestinationPropertyValue>> destination)
        {            
        }

        public IDtoMapping TwoWay<TDestinationPropertyValue>(Expression<Func<TDestination, TDestinationPropertyValue>> destination)
        {
        }


    }
}
