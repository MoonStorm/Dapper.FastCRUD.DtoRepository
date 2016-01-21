namespace Dapper.FastCrud.Dto.Entity.Builders.DtoToDb
{
    using System;
    using System.Linq.Expressions;
    using Dapper.FastCrud.Dto.Mappings;

    public class DtoMappingBuilder<TDto, TDb>
    {
        private readonly AggregatorMapping<TDto, TDb> _mapping;

        public DtoMappingBuilder(AggregatorMapping<TDto, TDb> mapping)
        {
            _mapping = mapping;
        }

        /// <summary>
        /// Creates a mapping on a DTO property
        /// </summary>
        public DtoPropertyMappingBuilder<TDto, TDb> Property(Expression<Func<TDto, object>> property)
        {
            var dtoProperty = _mapping.DtoPropertyRegistrations.Add(property);

            return new DtoPropertyMappingBuilder<TDto, TDb>(dtoProperty, _mapping);
        }

        /// <summary>
        /// Creates a mapping for a set of DTO properties
        /// </summary>
        public DtoPropertiesMappingBuilder<TDto, TDb> Properties(params Expression<Func<TDto, object>>[] properties)
        {
            _mapping.DtoPropertyRegistrations.AddRange(properties);

            return new DtoPropertiesMappingBuilder<TDto, TDb>(_mapping);
        }

    }
}
