namespace Dapper.FastCrud.Dto.Entity.Builders.DtoToDb
{
    using Dapper.FastCrud.Dto.Mappings;
    /// <summary>
    /// Used in transitioning between various partial mappings or terminates the mapping building and returns the mapping.
    /// </summary>
    public class DtoMappingTransitionBuilder<TDto, TDb>:IMappingBuilder<TDto, TDb>
    {
        private readonly AggregatorMapping<TDto, TDb> _mapping;

        public DtoMappingTransitionBuilder(AggregatorMapping<TDto, TDb> mapping)
        {
            _mapping = mapping;
        }

        /// <summary>
        /// Continues the construction of the mapping
        /// </summary>
        public DtoMappingBuilder<TDto, TDb> And => new DtoMappingBuilder<TDto, TDb>(_mapping);

        /// <summary>
        /// Resolves the final mapping.
        /// </summary>
        public IMapping<TDto, TDb> ConstructMapping()
        {
            return _mapping;
        }
    }
}
