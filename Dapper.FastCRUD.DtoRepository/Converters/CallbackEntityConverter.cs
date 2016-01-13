namespace Dapper.FastCrud.DtoRepository.Converters
{
    using System;

    /// <summary>
    /// DTO to DB entity to entity custom converter using callbacks.
    /// </summary>
    public class CallbackEntityConverter<TDtoEntity,TDbEntity>:EntityConverter
    {
        private readonly Action<TDbEntity, TDtoEntity> _dbToDtoTranslationCallback;
        private readonly Action<TDtoEntity, TDbEntity> _dtoToDbTranslationCallback;

        /// <summary>
        /// Constructor that takes a callback to perform the DTO to DB entity translation 
        /// </summary>
        public CallbackEntityConverter(Action<TDtoEntity, TDbEntity> conversionFct)
        {
            Requires.NotNull(conversionFct, nameof(conversionFct));

            _dtoToDbTranslationCallback = conversionFct;
            this.SupportsDtoToDbConversion = true;
        }

        /// <summary>
        /// Constructor that takes a callback to perform the DTO to DB entity translation 
        /// </summary>
        public CallbackEntityConverter(Action<TDbEntity, TDtoEntity> conversionFct)
        {
            Requires.NotNull(conversionFct, nameof(conversionFct));

            _dbToDtoTranslationCallback = conversionFct;
            this.SupportsDbToDtoConversion = true;
        }

        /// <summary>
        /// Called to set up a DB entity from a DTO entity.
        /// </summary>
        public override void DtoToDb(EntityConversionContext conversionContext)
        {
            Requires.ValidState(this.SupportsDtoToDbConversion, $"Conversion from '{typeof(TDtoEntity)}' to '{typeof(TDbEntity)}' is not supported.");

            var dtoEntity = conversionContext.GetDtoEntity<TDtoEntity>();
            var dbEntity = conversionContext.GetDbEntity<TDbEntity>();
            _dtoToDbTranslationCallback(dtoEntity, dbEntity);
        }

        /// <summary>
        /// Called to set up a DTO entity from a DB entity.
        /// </summary>
        public override void DbToDto(EntityConversionContext conversionContext)
        {
            Requires.ValidState(this.SupportsDtoToDbConversion, $"Conversion from '{typeof(TDbEntity)}' to '{typeof(TDtoEntity)}' is not supported.");

            var dtoEntity = conversionContext.GetDtoEntity<TDtoEntity>();
            var dbEntity = conversionContext.GetDbEntity<TDbEntity>();
            _dbToDtoTranslationCallback(dbEntity, dtoEntity);
        }
    }
}
