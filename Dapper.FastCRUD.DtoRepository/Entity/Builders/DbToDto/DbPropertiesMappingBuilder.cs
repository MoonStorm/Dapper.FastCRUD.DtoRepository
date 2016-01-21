namespace Dapper.FastCrud.Dto.Entity.Builders.DbToDto
{
    using System;
    using System.Linq.Expressions;
    using Dapper.FastCrud.Dto.Mappings;
    using Dapper.FastCrud.DtoRepository;

    /// <summary>
    /// Entity to entity conversion
    /// </summary>
    public class DbPropertiesMappingBuilder<TDb, TDto>
    {
        private readonly AggregatorMapping<TDto, TDb> _mapping;

        public DbPropertiesMappingBuilder(AggregatorMapping<TDto, TDb> mapping)
        {
            _mapping = mapping;
        }

        /// <summary>
        /// Maps a set of properties to the provided db properties.
        /// </summary>
        public DbCallbackMappingBuilder<TDb, TDto> To(params Expression<Func<TDto, object>>[] properties)
        {
            Requires.NotNullOrEmptyOrNullElements(properties, nameof(properties));
            
            _mapping.DtoPropertyRegistrations.AddRange(properties);
            return new DbCallbackMappingBuilder<TDb, TDto>(_mapping);
        }
    }
}
