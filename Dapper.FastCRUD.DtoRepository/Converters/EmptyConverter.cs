namespace Dapper.FastCrud.Dto.Converters
{
    using System.Collections.Generic;
    using System.ComponentModel;

    public class EmptyConverter:IEntityConverter
    {
        private static readonly PropertyDescriptor[] _emptyPropertyDescriptorCollection = new PropertyDescriptor[0];

        /// <summary>
        /// Gets the source entity types involved in the conversion and their property registrations.
        /// </summary>
        public IEnumerable<PropertyDescriptor> SourceRegistrations => _emptyPropertyDescriptorCollection;

        /// <summary>
        /// Gets the destination entity types involved in the conversion and their property registrations.
        /// </summary>
        public IEnumerable<PropertyDescriptor> DestinationRegistrations => _emptyPropertyDescriptorCollection;

        /// <summary>
        /// Called to set up a destination from a source.
        /// </summary>
        public void Convert(EntityConversionContext conversionContext)
        {
        }
    }
}
