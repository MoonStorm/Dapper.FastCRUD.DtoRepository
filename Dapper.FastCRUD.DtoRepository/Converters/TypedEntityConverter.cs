namespace Dapper.FastCrud.DtoRepository.Converters
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Dapper.FastCrud.DtoRepository.Registrations;

    /// <summary>
    /// Generic typed converter used to copy values between a single source and destination entity.
    /// </summary>
    public abstract class TypedEntityConverter<TSource, TDestination>:IEntityConverter
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        protected TypedEntityConverter()
        {
            this.SourcePropertyRegistrations = new TypedEntityPropertyRegistrations<TSource>();
            this.DestinationPropertyRegistrations = new TypedEntityPropertyRegistrations<TDestination>();
        }

        /// <summary>
        /// Typed source property registrations.
        /// </summary>
        public TypedEntityPropertyRegistrations<TSource> SourcePropertyRegistrations { get; }

        /// <summary>
        /// Typed destination property registrations.
        /// </summary>
        public TypedEntityPropertyRegistrations<TDestination> DestinationPropertyRegistrations { get; }

        /// <summary>
        /// Gets the source entity types involved in the conversion and their property registrations.
        /// </summary>
        public IEnumerable<PropertyDescriptor> SourceRegistrations => this.SourcePropertyRegistrations;

        /// <summary>
        /// Gets the destination entity types involved in the conversion and their property registrations.
        /// </summary>
        public IEnumerable<PropertyDescriptor> DestinationRegistrations => this.DestinationPropertyRegistrations;

        /// <summary>
        /// Called to set up a destination from a source.
        /// </summary>
        void IEntityConverter.Convert(EntityConversionContext conversionContext)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called to set up a destination from a source entity and available user contexts.
        /// </summary>
        protected abstract void Convert(TSource source, TDestination destination, GenericTypeObjectMap userContext);
    }
}
