namespace Dapper.FastCrud.DtoRepository.Converters
{
    using System.ComponentModel;

    /// <summary>
    /// Single to single property translator
    /// </summary>
    public class SinglePropertyEntityConverter<TDtoEntity,TDbEntity>:EntityConverter
    {
        private readonly PropertyDescriptor _dtoPropertyInfo;
        private readonly PropertyDescriptor _dbPropertyInfo;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="dtoProperty">Dto property info</param>
        /// <param name="dbProperty">Db property info</param>
        /// <param name="allowDtoToDbTranslation">Allows DTO to DB translation</param>
        /// <param name="allowDbToDtoTranslation">Allows DB to DTO translation</param>
        public SinglePropertyEntityConverter(
            PropertyDescriptor dtoProperty, 
            PropertyDescriptor dbProperty,
            bool allowDtoToDbTranslation,
            bool allowDbToDtoTranslation)
        {
            Requires.NotNull(dtoProperty, nameof(dtoProperty));
            Requires.NotNull(dbProperty, nameof(dbProperty));

            _dtoPropertyInfo = dtoProperty;
            _dbPropertyInfo = dbProperty;
            this.SupportsDtoToDbConversion = allowDtoToDbTranslation;
            this.SupportsDbToDtoConversion = allowDbToDtoTranslation;
        }

        /// <summary>
        /// Called to set up a DB entity from a DTO entity.
        /// </summary>
        public override void DtoToDb(EntityConversionContext conversionContext)
        {
            Requires.ValidState(this.SupportsDtoToDbConversion, $"Conversion from '{typeof(TDtoEntity)}' to '{typeof(TDbEntity)}' is not supported.");

            var dtoEntitySource = conversionContext.GetDtoEntity<TDtoEntity>();
            var dbEntityDestination = conversionContext.GetDbEntity<TDbEntity>();

            var sourceValue = _dtoPropertyInfo.GetValue(dtoEntitySource);
            _dbPropertyInfo.SetValue(dbEntityDestination, sourceValue);
        }

        /// <summary>
        /// Called to set up a DTO entity from a DB entity.
        /// </summary>
        public override void DbToDto(EntityConversionContext conversionContext)
        {
            Requires.ValidState(this.SupportsDtoToDbConversion, $"Conversion from '{typeof(TDbEntity)}' to '{typeof(TDtoEntity)}' is not supported.");

            var dbEntitySource = conversionContext.GetDbEntity<TDbEntity>();
            var dtoEntityDestination = conversionContext.GetDtoEntity<TDtoEntity>();

            var sourceValue = _dbPropertyInfo.GetValue(dbEntitySource);
            _dtoPropertyInfo.SetValue(dtoEntityDestination, sourceValue);
        }
    }
}
