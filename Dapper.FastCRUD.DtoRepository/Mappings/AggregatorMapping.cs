namespace Dapper.FastCrud.Dto.Mappings
{
    using Dapper.FastCrud.Dto.Converters.Entity;
    using Dapper.FastCrud.Dto.Registrations;
    using Dapper.FastCrud.Dto.StatementOptions.Converters;

    /// <summary>
    /// Aggregates property registrations, entity converters and statement options converters.
    /// </summary>
    public class AggregatorMapping<TDto, TDb> : IMapping<TDto, TDb>
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public AggregatorMapping()
        {
            this.DbToDtoConverter = new AggregatorEntityConverter<TDb, TDto>();
            this.DtoToDbConverter = new AggregatorEntityConverter<TDto, TDb>();
            this.DbPropertyRegistrations = new EntityPropertyRegistrations();
            this.DtoPropertyRegistrations = new EntityPropertyRegistrations();
            this.StatementOptionsConverter = new AggregatorStatementOptionsConverter<TDto, TDb>();
        }

        /// <summary>
        /// Gets the DTO entity types involved in the conversion and their property registrations.
        /// </summary>
        public EntityPropertyRegistrations DtoPropertyRegistrations { get; }

        /// <summary>
        /// Gets the DB entity types involved in the conversion and their property registrations.
        /// </summary>
        public EntityPropertyRegistrations DbPropertyRegistrations { get; }

        /// <summary>
        /// Converter for the dto to db conversion and the registrar of properties of both sides used in the process.
        /// </summary>
        public AggregatorEntityConverter<TDto, TDb> DtoToDbConverter { get; }

        /// <summary>
        /// Converter for the db to dto conversion and the registrar of properties of both sides used in the process.
        /// </summary>
        public AggregatorEntityConverter<TDb, TDto> DbToDtoConverter { get; }

        /// <summary>
        /// Statement options converter.
        /// </summary>
        public AggregatorStatementOptionsConverter<TDto, TDb> StatementOptionsConverter { get; }

        /// <summary>
        /// Converter for the dto to db conversion and the registrar of properties of both sides used in the process.
        /// </summary>
        IEntityConverter<TDto, TDb> IMapping<TDto, TDb>.DtoToDbConverter => this.DtoToDbConverter;

        /// <summary>
        /// Converter for the db to dto conversion and the registrar of properties of both sides used in the process.
        /// </summary>
        IEntityConverter<TDb, TDto> IMapping<TDto, TDb>.DbToDtoConverter => this.DbToDtoConverter;

        /// <summary>
        /// Statement options converter.
        /// </summary>
        IStatementOptionsConverter<TDto, TDb> IMapping<TDto, TDb>.StatementOptionsConverter => this.StatementOptionsConverter;
    }
}
