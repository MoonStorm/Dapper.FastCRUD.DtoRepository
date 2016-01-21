namespace Dapper.FastCrud.Dto.Converters.Entity
{
    using Dapper.FastCrud.Dto.Entity.Converters;

    /// <summary>
    /// Entity converter between a single source and a destination.
    /// </summary>
    public abstract class TypedEntityConverter<TSource, TDestination>:IEntityConverter<TSource, TDestination>
    {
        /// <summary>
        /// Called to set up a destination from a source.
        /// </summary>
        public void Convert(EntityConversionContext<TSource, TDestination> conversionContext)
        {
            this.Convert(
                conversionContext.Source, 
                conversionContext.Destination,
                conversionContext.UserContext);
        }

        /// <summary>
        /// Converts a source to a destination.
        /// </summary>
        protected abstract void Convert(TSource source, TDestination destination, ContextStore userContextStore);
    }
}
