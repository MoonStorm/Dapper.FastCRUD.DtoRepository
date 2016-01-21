namespace Dapper.FastCrud.Dto.Converters.Entity
{
    using System.Collections.Generic;
    using Dapper.FastCrud.DtoRepository;

    /// <summary>
    /// Aggregates multiple entity converters.
    /// </summary>
    public class AggregatorEntityConverter<TSource, TDestination>:IEntityConverter<TSource, TDestination>
    {
        private readonly List<IEntityConverter<TSource,TDestination>> _aggregatedConverters = new List<IEntityConverter<TSource, TDestination>>();

        /// <summary>
        /// Registers a new entity converter.
        /// </summary>
        public void Add(IEntityConverter<TSource,TDestination> entityConverter)
        {
            Requires.NotNull(entityConverter, nameof(entityConverter));

            _aggregatedConverters.Add(entityConverter);
        }

        /// <summary>
        /// Called to set up a destination from a source.
        /// </summary>
        public void Convert(EntityConversionContext<TSource, TDestination> conversionContext)
        {
            foreach (var converter in _aggregatedConverters)
            {
                converter.Convert(conversionContext);
            }
        }
    }
}
