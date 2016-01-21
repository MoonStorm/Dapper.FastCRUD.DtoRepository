namespace Dapper.FastCrud.Dto.Entity.Builders.DtoToDb
{
    using System;
    using System.Linq.Expressions;
    using Dapper.FastCrud.Dto.Mappings;
    using Dapper.FastCrud.DtoRepository;

    /// <summary>
    /// Entity to entity conversion
    /// </summary>
    public class DtoPropertiesMappingBuilder<TDto, TDb>
    {
        private readonly AggregatorMapping<TDto, TDb> _mapping;

        public DtoPropertiesMappingBuilder(AggregatorMapping<TDto, TDb> mapping)
        {
            _mapping = mapping;
        }

        /// <summary>
        /// Maps a set of properties to the provided db properties.
        /// </summary>
        public DtoCallbackMappingBuilder<TDto, TDb> To(params Expression<Func<TDb, object>>[] properties)
        {
            Requires.NotNullOrEmptyOrNullElements(properties, nameof(properties));
            
            _mapping.DbPropertyRegistrations.AddRange(properties);
            return new DtoCallbackMappingBuilder<TDto, TDb>(_mapping);
        }
    }
}
