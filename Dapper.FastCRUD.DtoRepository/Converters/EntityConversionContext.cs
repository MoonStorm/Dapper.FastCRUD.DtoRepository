namespace Dapper.FastCrud.Dto.Converters
{
    /// <summary>
    /// The context that flows through the entity converters.
    /// </summary>
    public class EntityConversionContext
    {
        private readonly TypedObjectStore _userContexts = new TypedObjectStore();
        private readonly TypedObjectStore _sourceEntities = new TypedObjectStore();
        private readonly TypedObjectStore _destinationEntities = new TypedObjectStore();

        /// <summary>
        /// Gives access to the user contexts.
        /// </summary>
        public TypedObjectStore UserContexts => _userContexts;

        /// <summary>
        /// Gives access to the entities representing the source.
        /// </summary>
        public TypedObjectStore Source => _sourceEntities;

        /// <summary>
        /// Gives access to the entities representing the destination.
        /// </summary>
        public TypedObjectStore Destination => _destinationEntities;
    }
}
