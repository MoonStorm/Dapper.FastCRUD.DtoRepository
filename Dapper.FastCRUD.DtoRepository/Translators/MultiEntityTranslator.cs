namespace Dapper.FastCrud.DtoRepository.Translators
{
    using System.Collections.Generic;

    public class MultiEntityTranslator<TDtoEntity, TDbEntity> : IEntityTranslator<TDtoEntity, TDbEntity>
    {
        private List<IEntityTranslator<TDtoEntity, TDbEntity>> _dtoToDbTranslators;
        private List<IEntityTranslator<TDtoEntity, TDbEntity>> _dbToDtoTranslators;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MultiEntityTranslator()
        {
            _dbToDtoTranslators = new List<IEntityTranslator<TDtoEntity, TDbEntity>>();
            _dtoToDbTranslators = new List<IEntityTranslator<TDtoEntity, TDbEntity>>();
        }

        /// <summary>
        /// Registers a new translator.
        /// </summary>
        public void RegisterTranslator(IEntityTranslator<TDtoEntity, TDbEntity> translator)
        {
            Requires.NotNull(translator, nameof(translator));

            if (translator.SupportsDbToDtoTranslation)
            {
                _dbToDtoTranslators.Add(translator);
            }

            if (translator.SupportsDtoToDbTranslation)
            {
                _dtoToDbTranslators.Add(translator);
            }
        }

        /// <summary>
        /// Called to set up a DB entity from a DTO entity.
        /// </summary>
        /// <param name="dtoEntitySource">DTO entity source</param>
        /// <param name="dbEntityDestination">DB entity destination</param>
        public void Copy(TDtoEntity dtoEntitySource, TDbEntity dbEntityDestination)
        {
            foreach (var translator in _dtoToDbTranslators)
            {
                translator.Copy(dtoEntitySource, dbEntityDestination);
            }
        }

        /// <summary>
        /// Called to set up a DTO entity from a DB entity.
        /// </summary>
        /// <param name="dbEntitySource">DB entity source</param>
        /// <param name="dtoEntityDestination">DTO entity destination</param>
        public void Copy(TDbEntity dbEntitySource, TDtoEntity dtoEntityDestination)
        {
            foreach (var translator in _dbToDtoTranslators)
            {
                translator.Copy(dbEntitySource, dtoEntityDestination);
            }
        }

        /// <summary>
        /// Returns true if the instance supports DTO to DB translations.
        /// </summary>
        public bool SupportsDtoToDbTranslation => _dtoToDbTranslators.Count > 0;

        /// <summary>
        /// Returns true if the instance supports DB to DTO translations.
        /// </summary>
        public bool SupportsDbToDtoTranslation => _dbToDtoTranslators.Count > 0;
    }
}
