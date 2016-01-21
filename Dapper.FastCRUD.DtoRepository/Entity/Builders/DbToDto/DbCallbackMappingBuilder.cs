namespace Dapper.FastCrud.Dto.Entity.Builders.DbToDto
{
    using System;
    using Dapper.FastCrud.Dto.Converters.Entity;
    using Dapper.FastCrud.Dto.Entity.Converters;
    using Dapper.FastCrud.Dto.Mappings;
    using Dapper.FastCrud.DtoRepository;

    /// <summary>
    /// Entity to entity conversion using a callback
    /// </summary>
    public class DbCallbackMappingBuilder<TDb, TDto>
    {
        private AggregatorMapping<TDto, TDb> _mapping;

        public DbCallbackMappingBuilder(AggregatorMapping<TDto, TDb> mapping)
        {
            _mapping = mapping;
        }

        /// <summary>
        /// Maps two entities via a callback.
        /// </summary>
        public DbMappingTransitionBuilder<TDb, TDto> UsingCallback(Action<TDb, TDto, ContextStore> conversionAction)
        {
            Requires.NotNull(conversionAction, nameof(conversionAction));

            _mapping.DbToDtoConverter.Add(new TypedEntityCallbackConverter<TDb,TDto>(conversionAction));

            return new DbMappingTransitionBuilder<TDb, TDto>(_mapping);
        }
    }
}
