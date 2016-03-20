namespace Dapper.FastCrud.Dto
{
    using Dapper.FastCrud.Dto.Entity.Builders;

    /// <summary>
    /// A DTO repository using the default mapping builder.
    /// </summary>
    public class StandardRepository<TDto, TDb>:Repository<TDto, TDb, StandardMappingBuilder<TDto, TDb>>
    {
        /// <summary>
        /// Constructs the mapping builder.
        /// </summary>
        protected sealed override StandardMappingBuilder<TDto, TDb> GetBuilder()
        {
            return new StandardMappingBuilder<TDto, TDb>();
        }
    }
}
