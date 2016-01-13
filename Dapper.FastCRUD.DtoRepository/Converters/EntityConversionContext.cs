namespace Dapper.FastCrud.DtoRepository.Converters
{
    /// <summary>
    /// The context that flows through the entity converters.
    /// </summary>
    public class EntityConversionContext
    {
        private readonly GenericTypeObjectMap _userContexts = new GenericTypeObjectMap();
        private readonly GenericTypeObjectMap _sourceEntities = new GenericTypeObjectMap();
        private readonly GenericTypeObjectMap _destinationEntities = new GenericTypeObjectMap();

        /// <summary>
        /// Gives access to the user contexts.
        /// </summary>
        public GenericTypeObjectMap UserContexts => _userContexts;

        /// <summary>
        /// Gives access to the entities representing the source.
        /// </summary>
        public GenericTypeObjectMap Source => _sourceEntities;

        /// <summary>
        /// Gives access to the entities representing the destination.
        /// </summary>
        public GenericTypeObjectMap Destination => _destinationEntities;
    }
}
