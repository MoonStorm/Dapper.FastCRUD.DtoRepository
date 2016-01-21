namespace Dapper.FastCrud.Dto.Converters.Entity
{
    /// <summary>
    /// Generic interface for all the converters used to copy values between two sets of entities.
    /// </summary>
    public interface IEntityConverter<TSource, TDestination>
    {
        /// <summary>
        /// Called to set up a destination from a source.
        /// </summary>
        void Convert(EntityConversionContext<TSource,TDestination> conversionContext);
    }
}
