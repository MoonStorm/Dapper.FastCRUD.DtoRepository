namespace Dapper.FastCrud.Dto.Mappings
{
    using System;
    using System.Linq.Expressions;
    using Dapper.FastCrud.Dto.Converters;
    using Dapper.FastCrud.Dto.Mappings.Builders;
    using Dapper.FastCrud.DtoRepository;

    /// <summary>
    /// Represents a mapping with a source property.
    /// </summary>
    public class SourcePropertyMapping<TSource, TDestination, TSourcePropertyValue>
    {
        private Expression<Func<TSource, TSourcePropertyValue>> _sourceProperty;

        /// <summary>
        /// Constructor that requires a lambda expression to provide the source.
        /// </summary>
        public SourcePropertyMapping(Expression<Func<TSource, TSourcePropertyValue>> sourceProperty)
        {
            Requires.NotNull(sourceProperty, nameof(sourceProperty));
            _sourceProperty = sourceProperty;
        }

        public DestinationPropertyMapping<TSource, TDestination, TSourcePropertyValue, TDestinationPropertyValue> 
            OneWayTo<TDestinationPropertyValue>(Expression<Func<TDestination, TDestinationPropertyValue>> destinationProperty)
        {
            return new PropertyEntityConverter<TSource, TDestination, TSourcePropertyValue>(_sourceProperty, destinationProperty);
        }

        public IEntityConverter TwoWayTo<TDestinationPropertyValue>(Expression<Func<TDestination, TDestinationPropertyValue>> destination)
        {

        }
    }
}
