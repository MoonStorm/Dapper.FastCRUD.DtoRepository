namespace Dapper.FastCrud.Dto.Converters.Entity
{
    /// <summary>
    /// Provides a no-op implementation for a converter.
    /// </summary>
    public class EmptyEntityConverter<TSource, TDestination>:IEntityConverter<TSource, TDestination>
    {
        /// <summary>
        /// Called to set up a destination from a source.
        /// </summary>
        public void Convert(EntityConversionContext<TSource, TDestination> conversionContext)
        {
            throw new System.NotImplementedException();
        }
    }
}
