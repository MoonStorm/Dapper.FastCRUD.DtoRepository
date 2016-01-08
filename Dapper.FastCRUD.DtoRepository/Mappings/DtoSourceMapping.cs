using System;

namespace Dapper.FastCrud.DtoRepository.Mappings
{
    using Dapper.FastCrud.DtoRepository.Translators;

    public class DtoSourceMapping<TSource>
    {
        public void MapTo<TDestination>(Func<DtoDestinationMapping<TSource, TDestination>, IEntityTranslator<TSource, TDestination>> mapping)
        {
            
        } 
    }
}
