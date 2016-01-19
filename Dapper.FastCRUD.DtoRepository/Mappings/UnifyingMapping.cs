namespace Dapper.FastCrud.Dto.Mappings
{
    using Dapper.FastCrud.Dto.Converters;
    using Dapper.FastCrud.DtoRepository;

    /// <summary>
    /// Defines a mapping between a set of db entities and a set of dto entities.
    /// </summary>
    public abstract class UnifyingMapping:IMapping
    {
        private readonly AggregatedEntityConverter _aggregatedSourceToDestinationConverter;
        private readonly AggregatedEntityConverter _aggregatedDestinationToSourceConverter;

        /// <summary>
        /// Initializes an instance from a set of optional converters.
        /// </summary>
        protected UnifyingMapping(IEntityConverter sourceToDestinationConverter = null, IEntityConverter destinationToSourceConverter = null)
        {
            _aggregatedDestinationToSourceConverter = new AggregatedEntityConverter();
            _aggregatedSourceToDestinationConverter = new AggregatedEntityConverter();

            if (sourceToDestinationConverter != null)
                _aggregatedSourceToDestinationConverter.Add(sourceToDestinationConverter);
            if(destinationToSourceConverter != null)
                _aggregatedDestinationToSourceConverter.Add(destinationToSourceConverter);
        }

        /// <summary>
        /// Gets the converter responsible for converting the source to the destination.
        /// </summary>
        public AggregatedEntityConverter SourceToDestinationConverter => _aggregatedSourceToDestinationConverter;

        /// <summary>
        /// Gets the converter responsible for converting the destination to the source.
        /// </summary>
        public AggregatedEntityConverter DestinationToSourceConverter => _aggregatedDestinationToSourceConverter;

        /// <summary>
        /// Converter for the dto to db conversion and the registrar of properties of both sides used in the process.
        /// </summary>
        public abstract IEntityConverter DtoToDbConverter { get; }

        /// <summary>
        /// Converter for the db to dto conversion and the registrar of properties of both sides used in the process.
        /// </summary>
        public abstract IEntityConverter DbToDtoConverter { get; }
    }
}