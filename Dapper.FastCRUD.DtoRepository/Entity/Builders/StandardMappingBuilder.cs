namespace Dapper.FastCrud.Dto.Entity.Builders
{
    using System;
    using Dapper.FastCrud.Dto.Entity.Builders.DbToDto;
    using Dapper.FastCrud.Dto.Entity.Builders.DtoToDb;
    using Dapper.FastCrud.Dto.Mappings;
    using Dapper.FastCrud.DtoRepository;

    /// <summary>
    /// A standard DTO to DB mapping builder.
    /// </summary>
    public class StandardMappingBuilder<TDto, TDb>:IMappingBuilder<TDto, TDb>
    {
        private readonly AggregatorMapping<TDto,TDb> _aggregatedMappings;

        /// <summary>
        /// Default constructor
        /// </summary>
        public StandardMappingBuilder()
        {
            _aggregatedMappings = new AggregatorMapping<TDto, TDb>();
        }

        /// <summary>
        /// Defines the mapping required for DTO to DB conversions.
        /// </summary>
        public void To(Func<DtoMappingBuilder<TDto, TDb>, IMappingBuilder<TDto,TDb>> dtoToDbMappingFunc)
        {
            Requires.NotNull(dtoToDbMappingFunc, nameof(dtoToDbMappingFunc));

            var destinationMappingBuilder = new DtoMappingBuilder<TDto,TDb>(_aggregatedMappings);
            var dtoToDbMapping = dtoToDbMappingFunc(destinationMappingBuilder);
        }

        /// <summary>
        /// Defines the mapping required for DB to DTO conversions.
        /// </summary>
        public void From(Func<DbMappingBuilder<TDb, TDto>, IMappingBuilder<TDb,TDto>> dbToDtoMappingFunc)
        {
            Requires.NotNull(dbToDtoMappingFunc, nameof(dbToDtoMappingFunc));

            var destinationMappingBuilder = new DbMappingBuilder<TDb, TDto>(_aggregatedMappings);
            var dtoToDbMapping = dbToDtoMappingFunc(destinationMappingBuilder);
        }

        /// <summary>
        /// Resolves the final mapping.
        /// </summary>
        public IMapping<TDto, TDb> ConstructMapping()
        {
            throw new NotImplementedException();
        }
    }
}
