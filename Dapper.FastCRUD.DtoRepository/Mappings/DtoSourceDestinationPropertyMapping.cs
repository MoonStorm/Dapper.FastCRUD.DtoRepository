namespace Dapper.FastCrud.DtoRepository.Mappings
{
    using System;

    public class DtoSourceDestinationPropertyMapping<TSource, TDestination, TSourcePropertyValue, TDestinationPropertyValue> : IDtoMapping
    {
        public IDtoMapping ComputedWithContext<TContext>(Func<TSourcePropertyValue, TContext, TDestinationPropertyValue> callback)
        {
        }

        public IDtoMapping Computed(Func<TSourcePropertyValue, TDestinationPropertyValue> callback)
        {
            
        }
    }
}
