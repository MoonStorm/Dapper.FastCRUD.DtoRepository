namespace Dapper.FastCrud.Dto.Entity.Builders.DtoToDb
{
    using System;
    using Dapper.FastCrud.Dto.Converters.Entity;
    using Dapper.FastCrud.Dto.Entity.Converters;
    using Dapper.FastCrud.Dto.Mappings;
    using Dapper.FastCrud.DtoRepository;

    /// <summary>
    /// Entity to entity conversion using a callback
    /// </summary>
    public class DtoCallbackMappingBuilder<TDto, TDb>
    {
        private readonly AggregatorMapping<TDto, TDb> _mapping;

        public DtoCallbackMappingBuilder(AggregatorMapping<TDto, TDb> mapping)
        {
            _mapping = mapping;
        }

        /// <summary>
        /// Maps two entities via a callback.
        /// </summary>
        public DtoMappingTransitionBuilder<TDto, TDb> UsingCallback(Action<TDto, TDb, ContextStore> conversionAction)
        {
            Requires.NotNull(conversionAction, nameof(conversionAction));

            _mapping.DtoToDbConverter.Add(new TypedEntityCallbackConverter<TDto,TDb>(conversionAction));

            return new DtoMappingTransitionBuilder<TDto, TDb>(_mapping);
        }
    }
}
