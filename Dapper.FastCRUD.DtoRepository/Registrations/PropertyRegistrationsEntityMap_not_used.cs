namespace Dapper.FastCrud.DtoRepository.Registrations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    /// <summary>
    /// Contains the definition of all the properties on multiple entities that are involved in a mapping.
    /// </summary>
    public class PropertyRegistrationsEntityMap:Dictionary<Type, IEnumerable<PropertyDescriptor>>
    {
        /// <summary>
        /// Registers an entity type and its set of property registrations.
        /// </summary>
        public void Add<TEntityType>(TypedEntityPropertyRegistrations<TEntityType> entityPropertyRegistrations)
        {
            this.Add(typeof(TEntityType), entityPropertyRegistrations);
        }
    }
}
