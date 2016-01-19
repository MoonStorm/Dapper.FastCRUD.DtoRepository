namespace Dapper.FastCrud.Dto.Mappings.Builders
{
    /// <summary>
    /// The contract implemented by a DTO to DB mapping builder.
    /// </summary>
    public interface IMappingBuilder
    {
        /// <summary>
        /// Resolves the final mapping.
        /// </summary>
        IMapping ResolveMapping();
    }
}
