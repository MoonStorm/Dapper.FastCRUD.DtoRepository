namespace Dapper.FastCrud.Dto.Converters.Entity
{
    using Dapper.FastCrud.Dto.Entity.Converters;

    /// <summary>
    /// The context that flows through the entity converters.
    /// </summary>
    public class EntityConversionContext<TSource, TDestination>
    {
        private readonly ContextStore _userContexts = new ContextStore();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public EntityConversionContext(TSource source, TDestination destination)
        {
            this.Source = source;
            this.Destination = destination;
        }

        /// <summary>
        /// Gives access to the user contexts.
        /// </summary>
        public ContextStore UserContext => _userContexts;

        /// <summary>
        /// Gives access to the source.
        /// </summary>
        public TSource Source { get; }

        /// <summary>
        /// Gives access to the destination.
        /// </summary>
        public TDestination Destination { get; }
    }
}
