namespace Dapper.FastCrud.Dto.Mappings
{
    using Dapper.FastCrud.Dto.Converters;

    /// <summary>
    /// Defines a mapping between a set of db entities and a set of dto entities.
    /// </summary>
    public interface IMapping
    {
        /// <summary>
        /// Converter for the dto to db conversion and the registrar of properties of both sides used in the process.
        /// </summary>
        IEntityConverter DtoToDbConverter { get; }

        /// <summary>
        /// Converter for the db to dto conversion and the registrar of properties of both sides used in the process.
        /// </summary>
        IEntityConverter DbToDtoConverter { get; }
    }
}
