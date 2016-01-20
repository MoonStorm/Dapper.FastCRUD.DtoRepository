namespace Dapper.FastCrud.Dto.StatementOptions
{
    using System;
    using System.Data;
    using Dapper.FastCrud.Configuration.StatementOptions.Builders;
    using Dapper.FastCrud.DtoRepository;

    public abstract class DtoStatementOptionsBuilderBase<TDto,TStatementOptionsBuilder> where TStatementOptionsBuilder:StandardSqlStatementOptionsBuilder<TDto>
    {
        protected DtoStatementOptionsBuilderBase()
        {
        }

        ///// <summary>
        ///// The transaction to be used by the statement.
        ///// </summary>
        //internal IDbTransaction Transaction { get; private set; }

        ///// <summary>
        ///// Gets a timeout for the command being executed.
        ///// </summary>
        //internal TimeSpan? CommandTimeout { get; private set; }

        ///// <summary>
        ///// Parameters used by the statement.
        ///// </summary>
        //internal object Parameters { get; private set; }

        ///// <summary>
        ///// Gets or sets a where clause.
        ///// </summary>
        //internal FormattableString WhereClause { get; private set; }

        ///// <summary>
        ///// Gets or sets a where clause.
        ///// </summary>
        //internal FormattableString OrderClause { get; set; }

        ///// <summary>
        ///// Gets or sets a limit on the number of rows returned.
        ///// </summary>
        //internal long? LimitResults { get; set; }

        ///// <summary>
        ///// Gets or sets a number of rows to be skipped.
        ///// </summary>
        //internal long? SkipResults { get; set; }

        ///// <summary>
        ///// Gets or sets a flag indicating the results should be streamed.
        ///// </summary>
        //internal bool ForceStreamResults { get; set; }

        ///// <summary>
        ///// Limits the results set by the top number of records returned.
        ///// </summary>
        //public TStatementOptionsBuilder Top(long? topRecords)
        //{
        //    Requires.Argument(topRecords == null || topRecords > 0, nameof(topRecords), "The top record count must be a positive value");

        //    this.LimitResults = topRecords;
        //    return this.Builder;
        //}

        ///// <summary>
        ///// Adds an ORDER BY clause to the statement.
        ///// </summary>
        //public TStatementOptionsBuilder OrderBy(FormattableString orderByClause)
        //{
        //    this.OrderClause = orderByClause;
        //    return this.Builder;
        //}

        ///// <summary>
        ///// Skips the initial set of results.
        ///// </summary>
        //public TStatementOptionsBuilder Skip(long? skipRecordsCount)
        //{
        //    Requires.Argument(skipRecordsCount == null || skipRecordsCount >= 0, nameof(skipRecordsCount), "The number of records to skip must be a positive value");

        //    this.SkipResults = skipRecordsCount;
        //    return this.Builder;
        //}

        ///// <summary>
        ///// Causes the result set to be streamed.
        ///// </summary>
        //public TStatementOptionsBuilder StreamResults()
        //{
        //    this.ForceStreamResults = true;
        //    return this.Builder;
        //}

        ///// <summary>
        ///// Limits the result set with a where clause.
        ///// </summary>
        //public TStatementOptionsBuilder Where(FormattableString whereClause)
        //{
        //    this.WhereClause = whereClause;
        //    return this.Builder;
        //}

        ///// <summary>
        ///// Sets the parameters to be used by the statement.
        ///// </summary>
        //public TStatementOptionsBuilder WithParameters(object parameters)
        //{
        //    this.Parameters = parameters;
        //    return this.Builder;
        //}

        ///// <summary>
        ///// Enforces a maximum time span on the current command.
        ///// </summary>
        //public TStatementOptionsBuilder WithTimeout(TimeSpan? commandTimeout)
        //{
        //    this.CommandTimeout = commandTimeout;
        //    return this.Builder;
        //}

        ///// <summary>
        ///// Attaches the current command to an existing transaction.
        ///// </summary>
        //public TStatementOptionsBuilder AttachToTransaction(IDbTransaction transaction)
        //{
        //    this.Transaction = transaction;
        //    return this.Builder;
        //}

        protected abstract TStatementOptionsBuilder Builder { get; }
    }
}
