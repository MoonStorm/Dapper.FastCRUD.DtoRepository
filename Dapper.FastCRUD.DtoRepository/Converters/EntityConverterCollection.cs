namespace Dapper.FastCrud.DtoRepository.Converters
{
    using System.Collections.Generic;

    /// <summary>
    /// Acts as an entity converter that wraps the conversion using multiple entity converters.
    /// </summary>
    public class EntityConverterCollection:EntityConverter
    {
        private readonly List<EntityConverter> _dtoToDbTranslators;
        private readonly List<EntityConverter> _dbToDtoTranslators;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public EntityConverterCollection()
        {
            _dbToDtoTranslators = new List<EntityConverter>();
            _dtoToDbTranslators = new List<EntityConverter>();
        }

        /// <summary>
        /// Registers a new translator.
        /// </summary>
        public void RegisterConverter(EntityConverter converter)
        {
            Requires.NotNull(converter, nameof(converter));

            if (converter.SupportsDbToDtoConversion)
            {
                _dbToDtoTranslators.Add(converter);
                this.SupportsDbToDtoConversion = true;
            }

            if (converter.SupportsDtoToDbConversion)
            {
                _dtoToDbTranslators.Add(converter);
                this.SupportsDtoToDbConversion = true;
            }
        }

        /// <summary>
        /// Called to set up a DB entity from a DTO entity.
        /// </summary>
        public override void DtoToDb(EntityConversionContext conversionContext)
        {
            Requires.ValidState(this.SupportsDtoToDbConversion, $"The conversion DTO to DB is not supported. No converters registered in the '{this.GetType()}'.");

            foreach (var converter in _dtoToDbTranslators)
            {
                converter.DtoToDb(conversionContext);
            }
        }

        /// <summary>
        /// Called to set up a DTO entity from a DB entity.
        /// </summary>
        public override void DbToDto(EntityConversionContext conversionContext)
        {
            Requires.ValidState(this.SupportsDtoToDbConversion, $"The conversion DB to DTO is not supported. No converters registered in the '{this.GetType()}'.");

            foreach (var converter in _dbToDtoTranslators)
            {
                converter.DbToDto(conversionContext);
            }
        }
    }
}
