namespace Dapper.FastCrud.DtoRepository.Converters
{
    using System.Collections.Generic;
    using System.ComponentModel;

    /// <summary>
    /// Generic interface for all the converters used to copy values between two sets of entities.
    /// </summary>
    public interface IEntityConverter
    {
        /// <summary>
        /// Gets the source entity types involved in the conversion and their property registrations.
        /// </summary>
        IEnumerable<PropertyDescriptor> SourceRegistrations { get; }

        /// <summary>
        /// Gets the destination entity types involved in the conversion and their property registrations.
        /// </summary>
        IEnumerable<PropertyDescriptor> DestinationRegistrations { get; }

        /// <summary>
        /// Called to set up a destination from a source.
        /// </summary>
        void Convert(EntityConversionContext conversionContext);
    }
}
