namespace Dapper.FastCrud.Dto.Mappings.Builders
{
    using System;
    using Dapper.FastCrud.DtoRepository;

    /// <summary>
    /// A standard DTO to DB mapping builder.
    /// </summary>
    public class DefaultMappingBuilder<TDto>:IMappingBuilder
    {
        private readonly AggregatedMapping _aggregatedMappings;

        /// <summary>
        /// Default constructor
        /// </summary>
        public DefaultMappingBuilder()
        {
            _aggregatedMappings = new AggregatedMapping();
        }

        /// <summary>
        /// Defines the mapping required for DTO to DB conversions.
        /// </summary>
        public void To<TDb>(Func<DestinationMappingBuilder<TDto, TDb>, IMapping> dtoToDbMappingFunc)
        {
            Requires.NotNull(dtoToDbMappingFunc, nameof(dtoToDbMappingFunc));

            var destinationMappingBuilder = new DestinationMappingBuilder<TDto,TDb>(new DtoToDbUnifyingMapping());
            var dtoToDbMapping = dtoToDbMappingFunc(destinationMappingBuilder);
            _aggregatedMappings.Add(dtoToDbMapping);
        }

        /// <summary>
        /// Defines the mapping required for DB to DTO conversions.
        /// </summary>
        public void From<TDb>(Func<DestinationMappingBuilder<TDb, TDto>, IMapping> dbToDtoMappingFunc)
        {
            Requires.NotNull(dbToDtoMappingFunc, nameof(dbToDtoMappingFunc));

            var destinationMappingBuilder = new DestinationMappingBuilder<TDb, TDto>(new DbToDtoUnifyingMapping());
            var dbToDtoMapping = dbToDtoMappingFunc(destinationMappingBuilder);
            _aggregatedMappings.Add(dbToDtoMapping);
        }

        /// <summary>
        /// Resolves the final mapping.
        /// </summary>
        public IMapping ResolveMapping()
        {
            return _aggregatedMappings;
        }
    }
}
