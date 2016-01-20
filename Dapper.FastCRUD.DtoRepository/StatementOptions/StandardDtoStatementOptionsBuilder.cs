namespace Dapper.FastCrud.Configuration.StatementOptions.Builders
{
    using Dapper.FastCrud.Dto.StatementOptions;

    /// <summary>
    /// Standard sql options builder for a statement.
    /// </summary>
    public class StandardSqlStatementOptionsBuilder<TDto>
        : StandardSqlStatementOptionsBuilder<TDto, StandardSqlStatementOptionsBuilder<TDto>>
    {
        protected override StandardSqlStatementOptionsBuilder<TDto> Builder => this;
    }

    public abstract class StandardSqlStatementOptionsBuilder<TDto, TStatementOptionsBuilder> :InternalSqlStatementOptions<TDto, TStatementOptionsBuilder>
        where TStatementOptionsBuilder : StandardSqlStatementOptionsBuilder<TDto>
    {
    }
}
