namespace Dapper.FastCrud.Dto.Entity.Builders.DbToDto
{
    using System;
    using System.Linq.Expressions;
    using Dapper.FastCrud.Dto.Mappings;

    public class DbMappingBuilder<TDb, TDto>
    {
        private readonly AggregatorMapping<TDto, TDb> _mapping;

        public DbMappingBuilder(AggregatorMapping<TDto, TDb> mapping)
        {
            _mapping = mapping;
        }

        /// <summary>
        /// Creates a mapping on a DTO property
        /// </summary>
        public DbPropertyMappingBuilder<TDb, TDto> Property(Expression<Func<TDb, object>> property)
        {
            var dbProperty = _mapping.DbPropertyRegistrations.Add(property);

            return new DbPropertyMappingBuilder<TDb, TDto>(dbProperty, _mapping);
        }

        /// <summary>
        /// Creates a mapping for a set of DTO properties
        /// </summary>
        public DbPropertiesMappingBuilder<TDb, TDto> Properties(params Expression<Func<TDb, object>>[] properties)
        {
            _mapping.DbPropertyRegistrations.AddRange(properties);

            return new DbPropertiesMappingBuilder<TDb, TDto>(_mapping);
        }

    }
}
