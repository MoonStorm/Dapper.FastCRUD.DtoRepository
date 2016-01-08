namespace Dapper.FastCrud.DtoRepository.Translators
{
    using System.ComponentModel;

    /// <summary>
    /// Single to single property translator
    /// </summary>
    public class SinglePropertyEntityTranslator<TDtoEntity,TDbEntity>:IEntityTranslator<TDtoEntity,TDbEntity>
    {
        private readonly PropertyDescriptor _dtoPropertyInfo;
        private readonly PropertyDescriptor _dbPropertyInfo;

        /// <summary>
        /// Default contructor.
        /// </summary>
        /// <param name="dtoProperty">Dto property info</param>
        /// <param name="dbProperty">Db property info</param>
        /// <param name="allowDtoToDbTranslation">Allows DTO to DB translation</param>
        /// <param name="allowDbToDtoTranslation">Allows DB to DTO translation</param>
        public SinglePropertyEntityTranslator(
            PropertyDescriptor dtoProperty, 
            PropertyDescriptor dbProperty,
            bool allowDtoToDbTranslation,
            bool allowDbToDtoTranslation)
        {
            Requires.NotNull(dtoProperty, nameof(dtoProperty));
            Requires.NotNull(dbProperty, nameof(dbProperty));

            _dtoPropertyInfo = dtoProperty;
            _dbPropertyInfo = dbProperty;
            this.SupportsDtoToDbTranslation = allowDtoToDbTranslation;
            this.SupportsDbToDtoTranslation = allowDbToDtoTranslation;
        }

        /// <summary>
        /// Called to set up a DB entity from a DTO entity.
        /// </summary>
        /// <param name="dtoEntitySource">DTO entity source</param>
        /// <param name="dbEntityDestination">DB entity destination</param>
        public void Copy(TDtoEntity dtoEntitySource, TDbEntity dbEntityDestination)
        {
            var sourceValue = _dtoPropertyInfo.GetValue(dtoEntitySource);
            _dbPropertyInfo.SetValue(dbEntityDestination, sourceValue);
        }

        /// <summary>
        /// Called to set up a DTO entity from a DB entity.
        /// </summary>
        /// <param name="dbEntitySource">DB entity source</param>
        /// <param name="dtoEntityDestination">DTO entity destination</param>
        public void Copy(TDbEntity dbEntitySource, TDtoEntity dtoEntityDestination)
        {
            var sourceValue = _dbPropertyInfo.GetValue(dbEntitySource);
            _dtoPropertyInfo.SetValue(dtoEntityDestination, sourceValue);
        }

        /// <summary>
        /// Returns true if the instance supports DTO to DB translations.
        /// </summary>
        public bool SupportsDtoToDbTranslation { get; }

        /// <summary>
        /// Returns true if the instance supports DB to DTO translations.
        /// </summary>
        public bool SupportsDbToDtoTranslation { get; }
    }
}
