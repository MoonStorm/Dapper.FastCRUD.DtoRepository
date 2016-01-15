namespace Dapper.FastCrud.DtoRepository.Registrations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    /// <summary>
    /// Contains the definition of all the properties on a specific entity that are involved in a mapping.
    /// </summary>
    public interface IEntityPropertyRegistrations:IEnumerable<PropertyDescriptor>
    {
        /// <summary>
        /// Gets the entity type.
        /// </summary>
        Type EntityType { get; }
    }
}