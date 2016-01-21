namespace Dapper.FastCrud.Dto
{
    using System;
    using System.Threading;
    using Dapper.FastCrud.Dto.Mappings;
    using Dapper.FastCrud.Dto.Mappings.Builders;

    /// <summary>
    /// A repository for a DTO entity.
    /// </summary>
    /// <typeparam name="TDto">DTO type</typeparam>
    public abstract class Repository<TDto>
    {
    
    }

    /// <summary>
    /// A repository for a DTO using a mapping builder.
    /// </summary>
    /// <typeparam name="TMappingBuilder">Mapping builder type.</typeparam>
    /// <typeparam name="TDto">DTO entity type</typeparam>
    public abstract class Repository<TMappingBuilder, TDto> :Repository<TDto>
        where TMappingBuilder:IMappingBuilder
    {
        private readonly Lazy<TMappingBuilder> _mappingBuilder;

        /// <summary>
        /// Default constructor.
        /// </summary>
        protected Repository()
        {
            _mappingBuilder = new Lazy<TMappingBuilder>(this.GetBuilder, LazyThreadSafetyMode.None);
        }

        /// <summary>
        /// Gets the mapping builder.
        /// </summary>
        public TMappingBuilder Map => _mappingBuilder.Value;

        /// <summary>
        /// Constructs the mapping builder.
        /// </summary>
        protected abstract TMappingBuilder GetBuilder();
    }
}
