namespace Dapper.FastCrud.Configuration.StatementOptions.Builders
{
    using Dapper.FastCrud.Dto.StatementOptions;

    /// <summary>
    /// Ranged conditional sql options builder for a statement.
    /// </summary>
    public interface IConditionalSqlStatementOptionsBuilder<TEntity>
        : IConditionalSqlStatementOptionsOptionsSetter<TEntity, IConditionalSqlStatementOptionsBuilder<TEntity>>
    {
    }

    /// <summary>
    /// Ranged conditional sql options builder for a statement.
    /// </summary>
    internal class ConditionalSqlStatementOptionsBuilder<TEntity>
        : InternalSqlStatementOptions<TEntity, IConditionalSqlStatementOptionsBuilder<TEntity>>
        , IConditionalSqlStatementOptionsBuilder<TEntity>
    {
        protected override IConditionalSqlStatementOptionsBuilder<TEntity> Builder => this;
    }
}
