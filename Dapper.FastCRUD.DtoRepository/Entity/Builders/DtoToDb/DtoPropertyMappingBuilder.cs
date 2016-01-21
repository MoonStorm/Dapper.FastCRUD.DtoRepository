namespace Dapper.FastCrud.Dto.Entity.Builders.DtoToDb
{
    using System;
    using System.Linq.Expressions;
    using Dapper.FastCrud.Dto.Converters.Entity;
    using Dapper.FastCrud.Dto.Mappings;
    using Dapper.FastCrud.Dto.Registrations;

    public class DtoPropertyMappingBuilder<TDto, TDb>
    {
        private readonly AggregatorMapping<TDto, TDb> _mapping;
        private readonly TypedEntityPropertyRegistration<TDto> _dtoProperty;

        public DtoPropertyMappingBuilder(
            TypedEntityPropertyRegistration<TDto> dtoProperty, 
            AggregatorMapping<TDto, TDb> mapping)
        {
            _mapping = mapping;
            _dtoProperty = dtoProperty;
        }

        /// <summary>
        /// One way mapping to the provided property.
        /// </summary>
        public DtoMappingTransitionBuilder<TDto, TDb> OneWayTo(Expression<Func<TDb, object>> property)
        {
            var dbProperty = _mapping.DbPropertyRegistrations.Add(property);
            _mapping.DtoToDbConverter.Add(new TypedEntityPropertyConverter<TDto, TDb>(_dtoProperty, dbProperty));

            return new DtoMappingTransitionBuilder<TDto, TDb>(_mapping);
        }

        /// <summary>
        /// Two way mapping to the provided property.
        /// </summary>
        public DtoMappingTransitionBuilder<TDto, TDb> TwoWayTo(Expression<Func<TDb, object>> property)
        {
            var dbProperty = _mapping.DbPropertyRegistrations.Add(property);
            _mapping.DtoToDbConverter.Add(new TypedEntityPropertyConverter<TDto, TDb>(_dtoProperty, dbProperty));
            _mapping.DbToDtoConverter.Add(new TypedEntityPropertyConverter<TDb, TDto>(dbProperty, _dtoProperty));

            return new DtoMappingTransitionBuilder<TDto, TDb>(_mapping);
        }
    }
}
