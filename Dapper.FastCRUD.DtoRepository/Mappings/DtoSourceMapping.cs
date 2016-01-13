using System;

namespace Dapper.FastCrud.DtoRepository.Mappings
{
    using Dapper.FastCrud.DtoRepository.Converters;

    public class DtoSourceMapping<TSource>
    {
        public void To<TDestination>(Func<DbDestinationMapping<TSource, TDestination>, EntityConverter> mappingEntityConverter)
        {
            
        } 
    }
}
