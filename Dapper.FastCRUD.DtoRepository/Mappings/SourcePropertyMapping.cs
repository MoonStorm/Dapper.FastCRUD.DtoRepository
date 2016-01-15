namespace Dapper.FastCrud.DtoRepository.Mappings
{
    using System;
    using System.Linq.Expressions;
    using Dapper.FastCrud.DtoRepository.Converters;

    /// <summary>
    /// Represents a mapping with a source property.
    /// </summary>
    public class SourcePropertyMapping<TSource, TDestination, TSourcePropertyValue>
    {
        public IEntityConverter To(Expression<Func<TDestination, TSourcePropertyValue>> destination)
        {
            return new PropertyEntityConverter<TSource,TDestination,TSourcePropertyValue>();
        }

        public SourceDestinationPropertyMapping<TSource, TDestination, TSourcePropertyValue, TDestinationPropertyValue> 
            OneWayTo<TDestinationPropertyValue>(Expression<Func<TDestination, TDestinationPropertyValue>> destination)
        {            
        }

        public IEntityConverter TwoWayTo<TDestinationPropertyValue>(Expression<Func<TDestination, TDestinationPropertyValue>> destination)
        {

        }
    }
}
