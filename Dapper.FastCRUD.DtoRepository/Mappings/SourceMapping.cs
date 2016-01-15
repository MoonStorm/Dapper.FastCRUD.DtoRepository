
namespace Dapper.FastCrud.DtoRepository.Mappings
{
    using System;
    using Dapper.FastCrud.DtoRepository.Converters;

    public class SourceMapping<TSource>
    {
        public void To<TDestination>(Func<DestinationMapping<TSource, TDestination>, IEntityConverter> mappingEntityConverter)
        {
            var combinedConverter = new CombinedEntityConverter();
        } 
    }
}
