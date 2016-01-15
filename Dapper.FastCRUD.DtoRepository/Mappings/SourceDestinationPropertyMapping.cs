namespace Dapper.FastCrud.DtoRepository.Mappings
{
    using System;
    using Dapper.FastCrud.DtoRepository.Converters;

    public class SourceDestinationPropertyMapping<TSource, TDestination, TSourcePropertyValue, TDestinationPropertyValue>
    {
        public IEntityConverter ComputedWithContext<TContext>(Func<TSourcePropertyValue, TContext, TDestinationPropertyValue> callback)
        {
            return new Call
        }

        public IDtoMapping Computed(Func<TSourcePropertyValue, TDestinationPropertyValue> callback)
        {
            
        }
    }
}
