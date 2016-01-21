namespace Dapper.FastCrud.Dto.Entity.Builders.DbToDto
{
    using System;
    using System.Linq.Expressions;
    using Dapper.FastCrud.Dto.Converters.Entity;
    using Dapper.FastCrud.Dto.Mappings;
    using Dapper.FastCrud.Dto.Registrations;

    public class DbPropertyMappingBuilder<TDb, TDto>
    {
        private readonly AggregatorMapping<TDto, TDb> _mapping;
        private readonly TypedEntityPropertyRegistration<TDb> _dbProperty;

        public DbPropertyMappingBuilder(
            TypedEntityPropertyRegistration<TDb> dbProperty, 
            AggregatorMapping<TDto, TDb> mapping)
        {
            _mapping = mapping;
            _dbProperty = dbProperty;
        }

        /// <summary>
        /// One way mapping to the provided property.
        /// </summary>
        public DbMappingTransitionBuilder<TDb, TDto> OneWayTo(Expression<Func<TDto, object>> property)
        {
            var dtoProperty = _mapping.DtoPropertyRegistrations.Add(property);
            _mapping.DbToDtoConverter.Add(new TypedEntityPropertyConverter<TDb, TDto>(_dbProperty,dtoProperty));

            return new DbMappingTransitionBuilder<TDb, TDto>(_mapping);
        }

        /// <summary>
        /// Two way mapping to the provided property.
        /// </summary>
        public DbMappingTransitionBuilder<TDb, TDto> TwoWayTo(Expression<Func<TDto, object>> property)
        {
            var dtoProperty = _mapping.DtoPropertyRegistrations.Add(property);
            _mapping.DtoToDbConverter.Add(new TypedEntityPropertyConverter<TDto, TDb>(dtoProperty, _dbProperty));
            _mapping.DbToDtoConverter.Add(new TypedEntityPropertyConverter<TDb, TDto>(_dbProperty, dtoProperty));

            return new DbMappingTransitionBuilder<TDb, TDto>(_mapping);
        }
    }
}
