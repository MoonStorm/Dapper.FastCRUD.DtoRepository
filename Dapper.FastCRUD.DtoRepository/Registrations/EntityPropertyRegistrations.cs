namespace Dapper.FastCrud.Dto.Registrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Dapper.FastCrud.DtoRepository;

    /// <summary>
    /// Contains the definition of all the properties on a specific entity that are involved in a mapping.
    /// </summary>
    public class EntityPropertyRegistrations
    {
        private List<EntityPropertyRegistration> _propertyRegistrations;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public EntityPropertyRegistrations()
        {            
            _propertyRegistrations = new List<EntityPropertyRegistration>();
        }

        /// <summary>
        /// Registers a new set of properties.
        /// </summary>
        public void AddRange<TEntity>(params Expression<Func<TEntity, object>>[] properties)
        {
            Requires.NotNull(properties, nameof(properties));

            foreach (var property in properties)
            {
                this.Add(new TypedEntityPropertyRegistration<TEntity>(property));
            }
        }

        /// <summary>
        /// Registers a new property.
        /// </summary>
        public TypedEntityPropertyRegistration<TEntity> Add<TEntity>(Expression<Func<TEntity, object>> property)
        {
            Requires.NotNull(property, nameof(property));

            var propertyRegistration = new TypedEntityPropertyRegistration<TEntity>(property);
            this.Add(propertyRegistration);

            return propertyRegistration;
        }

        /// <summary>
        /// Registers a new property.
        /// </summary>
        public void Add(EntityPropertyRegistration propertyRegistration)
        {
            Requires.NotNull(propertyRegistration, nameof(propertyRegistration));

            _propertyRegistrations.Add(propertyRegistration);
        }
    }
}