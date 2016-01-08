namespace Dapper.FastCrud.DtoRepository.Translators
{
    /// <summary>
    /// Used to copy values between a DTO and a DB entity.
    /// </summary>
    /// <typeparam name="TDtoEntity">DTO entity</typeparam>
    /// <typeparam name="TDbEntity">DB entity</typeparam>
    public interface IEntityTranslator<in TDtoEntity, in TDbEntity>
    {
        /// <summary>
        /// Called to set up a DB entity from a DTO entity.
        /// </summary>
        /// <param name="dtoEntitySource">DTO entity source</param>
        /// <param name="dbEntityDestination">DB entity destination</param>
        void Copy(TDtoEntity dtoEntitySource, TDbEntity dbEntityDestination);

        /// <summary>
        /// Called to set up a DTO entity from a DB entity.
        /// </summary>
        /// <param name="dbEntitySource">DB entity source</param>
        /// <param name="dtoEntityDestination">DTO entity destination</param>
        void Copy(TDbEntity dbEntitySource, TDtoEntity dtoEntityDestination);

        /// <summary>
        /// Returns true if the instance supports DTO to DB translations.
        /// </summary>
        bool SupportsDtoToDbTranslation { get; }

        /// <summary>
        /// Returns true if the instance supports DB to DTO translations.
        /// </summary>
        bool SupportsDbToDtoTranslation { get; }
    }
}
