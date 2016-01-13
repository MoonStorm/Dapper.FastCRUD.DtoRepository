namespace Dapper.FastCrud.DtoRepository.Converters
{
    using Dapper.FastCrud.DtoRepository.Registrations;

    /// <summary>
    /// Used to copy values between a source and a destination entity.
    /// </summary>
    public abstract class EntityConverter
    {
        /// <summary>
        /// Gets the source entity types involved in the conversion and their property registrations.
        /// </summary>
        public MultiEntityPropertyRegistrations SourceRegistrations { get; }

        /// <summary>
        /// Gets the destination entity types involved in the conversion and their property registrations.
        /// </summary>
        public MultiEntityPropertyRegistrations DestinationRegistrations { get; }

        /// <summary>
        /// Called to set up a destination from a source.
        /// </summary>
        public abstract void Convert(EntityConversionContext conversionContext);
    }
}
