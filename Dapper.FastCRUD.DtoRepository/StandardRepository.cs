namespace Dapper.FastCrud.Dto
{
    using Dapper.FastCrud.Dto.Mappings.Builders;
    /// <summary>
    /// A DTO repository using the default mapping builder.
    /// </summary>
    public class StandardRepository<TDto>:Repository<DefaultMappingBuilder<TDto>,TDto>
    {
        /// <summary>
        /// Constructs the mapping builder.
        /// </summary>
        protected override DefaultMappingBuilder<TDto> GetBuilder()
        {
            return new DefaultMappingBuilder<TDto>();
        }
    }
}
