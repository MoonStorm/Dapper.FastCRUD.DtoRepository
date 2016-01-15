namespace Dapper.FastCrud.DtoRepository.Converters
{
    using System.Collections.Generic;
    using System.ComponentModel;

    /// <summary>
    /// Acts as an entity converter that wraps the conversion using multiple entity converters.
    /// </summary>
    public class CombinedEntityConverter:IEntityConverter
    {
        private readonly List<IEntityConverter> _entityConverters = new List<IEntityConverter>();

        /// <summary>
        /// Registers a new entity converter.
        /// </summary>
        public void Add(IEntityConverter converter)
        {
            _entityConverters.Add(converter);
        }

        /// <summary>
        /// Gets the source entity types involved in the conversion and their property registrations.
        /// </summary>
        IEnumerable<PropertyDescriptor> IEntityConverter.SourceRegistrations
        {
            get
            {
                foreach (var converter in _entityConverters)
                {
                    foreach (var propDescriptor in converter.SourceRegistrations)
                    {
                        yield return propDescriptor;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the destination entity types involved in the conversion and their property registrations.
        /// </summary>
        IEnumerable<PropertyDescriptor> IEntityConverter.DestinationRegistrations
        {
            get
            {
                foreach (var converter in _entityConverters)
                {
                    foreach (var propDescriptor in converter.DestinationRegistrations)
                    {
                        yield return propDescriptor;
                    }
                }
            }
        }

        /// <summary>
        /// Called to set up a destination from a source.
        /// </summary>
        void IEntityConverter.Convert(EntityConversionContext conversionContext)
        {
            foreach (var converter in _entityConverters)
            {
                converter.Convert(conversionContext);
            }
        }
    }
}
