namespace Dapper.FastCrud.Dto.Mappings.Builders
{
    using System;
    using Dapper.FastCrud.Dto.Converters;

    public class DestinationPropertyMapping<TSource, TDestination, TSourcePropertyValue, TDestinationPropertyValue>
    {
        public IEntityConverter ComputedWithContext<TContext>(Func<TSourcePropertyValue, TContext, TDestinationPropertyValue> callback)
        {
        }

        public IDtoMapping Computed(Func<TSourcePropertyValue, TDestinationPropertyValue> callback)
        {
            
        }
    }
}
