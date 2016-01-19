namespace Dapper.FastCrud.Dto.Mappings.Builders
{
    using System;
    using System.Threading;
    using Dapper.FastCrud.Dto.Converters;
    using Dapper.FastCrud.DtoRepository;

    /// <summary>
    /// Transitional mapping builder which can also be used as a terminal point.
    /// </summary>
    public class DestinationTransitionalMappingBuilder<TSource, TDestination>:IMapping
    {
        private readonly Lazy<UnifyingMapping> _outputMapping;

        public DestinationTransitionalMappingBuilder(UnifyingMapping unifyingMapping)
        {
            Requires.NotNull(unifyingMapping, nameof(unifyingMapping));
            _outputMapping = new Lazy<UnifyingMapping>(
                () =>
                    {
                        this.PrepareMapping(unifyingMapping);
                        return unifyingMapping;
                    }, LazyThreadSafetyMode.None);
        }

        /// <summary>
        /// Continues with additional mappings.
        /// </summary>
        public DestinationMappingBuilder<TSource, TDestination> And()
        {
            return new DestinationMappingBuilder<TSource, TDestination>(_outputMapping.Value);
        }

        /// <summary>
        /// Converter for the dto to db conversion and the registrar of properties of both sides used in the process.
        /// </summary>
        public IEntityConverter DtoToDbConverter => _outputMapping.Value.DtoToDbConverter;

        /// <summary>
        /// Converter for the db to dto conversion and the registrar of properties of both sides used in the process.
        /// </summary>
        public IEntityConverter DbToDtoConverter => _outputMapping.Value.DbToDtoConverter;

        protected virtual void PrepareMapping(UnifyingMapping mapping)
        {            
        }
    }
}
