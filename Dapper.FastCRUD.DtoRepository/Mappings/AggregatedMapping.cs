namespace Dapper.FastCrud.Dto.Mappings
{
    using Dapper.FastCrud.Dto.Converters;
    using Dapper.FastCrud.DtoRepository;

    /// <summary>
    /// Aggregates multiple mappings
    /// </summary>
    public class AggregatedMapping:IMapping
    {
        private readonly AggregatedEntityConverter _dbToDtoConverter;
        private readonly AggregatedEntityConverter _dtoToDbConverter;

        /// <summary>
        /// Combines multiple mappings.
        /// </summary>
        public AggregatedMapping(params IMapping[] mappings)
        {
            _dbToDtoConverter = new AggregatedEntityConverter();
            _dtoToDbConverter = new AggregatedEntityConverter();

            foreach (var mapping in mappings)
            {
                this.Add(mapping);
            }
        }

        /// <summary>
        /// Takes specific converters for each direction.
        /// </summary>
        public AggregatedMapping(IEntityConverter dtoToDbConverter, IEntityConverter dbToDtoConverter)
            :this()
        {
            Requires.NotNull(dtoToDbConverter, nameof(dtoToDbConverter));
            Requires.NotNull(dbToDtoConverter, nameof(dbToDtoConverter));

            _dbToDtoConverter.Add(dbToDtoConverter);
            _dtoToDbConverter.Add(_dtoToDbConverter);
        }

        /// <summary>
        /// Registers a new mapping
        /// </summary>
        public void Add(IMapping mapping)
        {
            Requires.NotNull(mapping, nameof(mapping));

            if (mapping.DbToDtoConverter != null)
            {
                _dbToDtoConverter.Add(mapping.DbToDtoConverter);
            }

            if (mapping.DtoToDbConverter != null)
            {
                _dtoToDbConverter.Add(mapping.DtoToDbConverter);
            }
        }

        /// <summary>
        /// Converter for the dto to db conversion and the registrar of properties of both sides used in the process.
        /// </summary>
        public IEntityConverter DtoToDbConverter => _dbToDtoConverter;

        /// <summary>
        /// Converter for the db to dto conversion and the registrar of properties of both sides used in the process.
        /// </summary>
        public IEntityConverter DbToDtoConverter => _dtoToDbConverter;
    }
}
