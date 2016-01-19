namespace Dapper.FastCrud.Dto.Converters
{
    using Dapper.FastCrud.DtoRepository;
    using Dapper.FastCrud.DtoRepository.Registrations;

    /// <summary>
    /// Single property to property converter.
    /// </summary>
    public class PropertyEntityConverter<TSource,TDestination>:TypedEntityConverter<TSource,TDestination>
    {
        public PropertyEntityConverter(
            TypedEntityPropertyRegistrations<TSource> sourcePropertyRegistrations,
            TypedEntityPropertyRegistrations<TDestination> destinationPropertyRegistrations)
            :base(sourcePropertyRegistrations, destinationPropertyRegistrations)
        {      
            Requires.Range(
                destinationPropertyRegistrations.Count==sourcePropertyRegistrations.Count, 
                nameof(destinationPropertyRegistrations),
                $"Property registrations for the destination '{typeof(TDestination)}' must match the ones for the source '{typeof(TSource)}'"); 
        }

        /// <summary>
        /// Called to set up a destination from a source entity and available user contexts.
        /// </summary>
        protected override void Convert(TSource source, TDestination destination, TypedObjectStore userContext)
        {
            for (var propRegistrationIndex = 0; propRegistrationIndex < this.SourcePropertyRegistrations.Count; propRegistrationIndex++)
            {
                var sourcePropRegistration = this.SourcePropertyRegistrations[propRegistrationIndex];
                var destinationPropRegistration = this.DestinationPropertyRegistrations[propRegistrationIndex];

                var sourcePropValue = sourcePropRegistration.GetValue(source);
                destinationPropRegistration.SetValue(destination, sourcePropValue);
            }
        }
    }
}
