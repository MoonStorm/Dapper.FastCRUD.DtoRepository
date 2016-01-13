namespace Dapper.FastCrud.DtoRepository.Registrations
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Contains the definition of all the properties on multiple entities that are involved in a mapping.
    /// </summary>
    public class MultiEntityPropertyRegistrations
    {
        private Dictionary<Type, EntityPropertyRegistrations> _entityPropertyRegistrations = new Dictionary<Type, EntityPropertyRegistrations>();

        /// <summary>
        /// Registers an entity type and its set of property registrations.
        /// </summary>
        public void Add<TEntityType>(TypedEntityPropertyRegistrations<TEntityType> entityPropertyRegistrations)
        {
            this.Add(typeof(TEntityType), entityPropertyRegistrations);
        }

        /// <summary>
        /// Registers an entity type and its set of property registrations.
        /// </summary>
        public void Add(Type entityType, EntityPropertyRegistrations entityPropertyRegistrations)
        {
            Requires.NotNull(entityType, nameof(entityType));
            Requires.NotNull(entityPropertyRegistrations, nameof(entityPropertyRegistrations));

            _entityPropertyRegistrations[entityType] = entityPropertyRegistrations;
        }
    }
}
