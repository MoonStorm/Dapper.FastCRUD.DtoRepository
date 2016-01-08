namespace Dapper.FastCrud.DtoRepository.Translators
{
    using System;

    /// <summary>
    /// Single to single property translator
    /// </summary>
    public class CallbackEntityTranslator<TDtoEntity,TDbEntity>:IEntityTranslator<TDtoEntity,TDbEntity>
    {
        private readonly Action<TDbEntity, TDtoEntity> _dbToDtoTranslationCallback;
        private readonly Action<TDtoEntity, TDbEntity> _dtoToDbTranslationCallback;

        /// <summary>
        /// Constructor that takes a callback to perform the DTO to DB entity translation 
        /// </summary>
        public CallbackEntityTranslator(Action<TDtoEntity, TDbEntity> translationCallbackFunc)
        {
            _dtoToDbTranslationCallback = translationCallbackFunc;
        }

        /// <summary>
        /// Constructor that takes a callback to perform the DTO to DB entity translation 
        /// </summary>
        public CallbackEntityTranslator(Action<TDbEntity, TDtoEntity> translationCallbackFunc)
        {
            _dbToDtoTranslationCallback = translationCallbackFunc;
        }

        /// <summary>
        /// Called to set up a DB entity from a DTO entity.
        /// </summary>
        /// <param name="dtoEntitySource">DTO entity source</param>
        /// <param name="dbEntityDestination">DB entity destination</param>
        public void Copy(TDtoEntity dtoEntitySource, TDbEntity dbEntityDestination)
        {
            _dtoToDbTranslationCallback(dtoEntitySource, dbEntityDestination);
        }

        /// <summary>
        /// Called to set up a DTO entity from a DB entity.
        /// </summary>
        /// <param name="dbEntitySource">DB entity source</param>
        /// <param name="dtoEntityDestination">DTO entity destination</param>
        public void Copy(TDbEntity dbEntitySource, TDtoEntity dtoEntityDestination)
        {
            _dbToDtoTranslationCallback(dbEntitySource, dtoEntityDestination);
        }

        /// <summary>
        /// Returns true if the instance supports DTO to DB translations.
        /// </summary>
        public bool SupportsDtoToDbTranslation => _dtoToDbTranslationCallback != null;

        /// <summary>
        /// Returns true if the instance supports DB to DTO translations.
        /// </summary>
        public bool SupportsDbToDtoTranslation => _dbToDtoTranslationCallback != null;
    }
}
