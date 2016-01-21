namespace Dapper.FastCrud.Dto.Entity.Builders.DbToDto
{
    using Dapper.FastCrud.Dto.Mappings;

    /// <summary>
    /// Used in transitioning between various partial mappings or terminates the mapping building and returns the mapping.
    /// </summary>
    public class DbMappingTransitionBuilder<TDb, TDto>:IMappingBuilder<TDto, TDb>
    {
        private AggregatorMapping<TDto, TDb> _mapping;

        public DbMappingTransitionBuilder(AggregatorMapping<TDto, TDb> mapping)
        {
            _mapping = mapping;
        }

        /// <summary>
        /// Continues the construction of the mapping
        /// </summary>
        public DbMappingBuilder<TDb, TDto> And => new DbMappingBuilder<TDb, TDto>(_mapping);

        /// <summary>
        /// Resolves the final mapping.
        /// </summary>
        public IMapping<TDto, TDb> ConstructMapping()
        {
            return _mapping;
        }
    }
}
