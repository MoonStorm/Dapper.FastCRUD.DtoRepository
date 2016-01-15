namespace Dapper.FastCrud.DtoRepository.Converters
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    /// <summary>
    /// Single property to property converter.
    /// </summary>
    public class PropertyEntityConverter<TSource,TDestination,TPropertyValue>:TypedEntityConverter<TSource,TDestination>
    {
        private readonly PropertyDescriptor _sourcePropertyDescriptor;
        private readonly PropertyDescriptor _destinationPropertyDescriptor;

        /// <summary>
        /// Constructor taking the definition of two corresponding properties used in the conversion. 
        /// </summary>
        public PropertyEntityConverter(
            Expression<Func<TSource, TPropertyValue>> sourceProperty, 
            Expression<Func<TDestination, TPropertyValue>> destinationProperty)
        {
            Requires.NotNull(sourceProperty, nameof(sourceProperty));
            Requires.NotNull(destinationProperty, nameof(destinationProperty));

            _sourcePropertyDescriptor = this.SourcePropertyRegistrations.Add(sourceProperty);
            _destinationPropertyDescriptor = this.DestinationPropertyRegistrations.Add(destinationProperty);
        }

        /// <summary>
        /// Called to set up a destination from a source entity and available user contexts.
        /// </summary>
        protected override void Convert(TSource source, TDestination destination, GenericTypeObjectMap userContext)
        {
            var sourcePropValue = _sourcePropertyDescriptor.GetValue(source);
            _destinationPropertyDescriptor.SetValue(destination, sourcePropValue);
        }
    }
}
