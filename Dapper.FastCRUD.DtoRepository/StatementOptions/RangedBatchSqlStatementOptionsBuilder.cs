namespace Dapper.FastCrud.Configuration.StatementOptions.Builders
{
    using Dapper.FastCrud.Dto.StatementOptions;

    /// <summary>
    /// Ranged conditional sql options builder for a statement.
    /// </summary>
    public interface IRangedBatchSqlStatementOptionsOptionsBuilder<TEntity>
        :IRangedConditionalSqlStatementOptionsSetter<TEntity, IRangedBatchSqlStatementOptionsOptionsBuilder<TEntity>>
    {
    }

    /// <summary>
    /// Ranged conditional sql options builder for a statement.
    /// </summary>
    internal class RangedBatchSqlStatementOptionsOptionsBuilder<TEntity>
        : InternalSqlStatementOptions<TEntity, IRangedBatchSqlStatementOptionsOptionsBuilder<TEntity>>
        , IRangedBatchSqlStatementOptionsOptionsBuilder<TEntity>
    {
        protected override IRangedBatchSqlStatementOptionsOptionsBuilder<TEntity> Builder => this;
    }
}
