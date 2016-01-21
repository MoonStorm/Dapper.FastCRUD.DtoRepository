namespace Dapper.FastCrud.Dto.Mappings
{
    /// <summary>
    /// The contract implemented by a DTO to DB mapping builder.
    /// </summary>
    public interface IMappingBuilder<TDto, TDb>
    {
        /// <summary>
        /// Resolves the final mapping.
        /// </summary>
        IMapping<TDto,TDb> ConstructMapping();
    }
}
