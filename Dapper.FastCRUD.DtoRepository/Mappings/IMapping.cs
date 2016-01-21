namespace Dapper.FastCrud.Dto.Mappings
{
    using Dapper.FastCrud.Dto.Converters.Entity;
    using Dapper.FastCrud.Dto.Registrations;
    using Dapper.FastCrud.Dto.StatementOptions.Converters;

    /// <summary>
    /// Defines a mapping between a set of db entities and a set of dto entities.
    /// </summary>
    public interface IMapping<TDto, TDb>
    {
        /// <summary>
        /// Gets the DTO entity types involved in the conversion and their property registrations.
        /// </summary>
        EntityPropertyRegistrations DtoPropertyRegistrations { get; }

        /// <summary>
        /// Gets the DB entity types involved in the conversion and their property registrations.
        /// </summary>
        EntityPropertyRegistrations DbPropertyRegistrations { get; }

        /// <summary>
        /// Converter for the dto to db conversion and the registrar of properties of both sides used in the process.
        /// </summary>
        IEntityConverter<TDto,TDb> DtoToDbConverter { get; }

        /// <summary>
        /// Converter for the db to dto conversion and the registrar of properties of both sides used in the process.
        /// </summary>
        IEntityConverter<TDb,TDto> DbToDtoConverter { get; }

        /// <summary>
        /// Statement options converter.
        /// </summary>
        IStatementOptionsConverter<TDto, TDb> StatementOptionsConverter { get; }
    }
}
