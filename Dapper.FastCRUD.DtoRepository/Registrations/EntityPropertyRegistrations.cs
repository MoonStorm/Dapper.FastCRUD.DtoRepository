namespace Dapper.FastCrud.DtoRepository.Registrations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    /// <summary>
    /// Contains the definition of all the properties on a specific entity that are involved in a mapping.
    /// </summary>
    public class EntityPropertyRegistrations:List<PropertyDescriptor>
    {
        private readonly Type _type;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public EntityPropertyRegistrations(Type type)
        {
            Requires.NotNull(type, nameof(type));

            _type = type;
        }

        /// <summary>
        /// Constructor that takes a list of parameter names as arguments.
        /// </summary>
        public EntityPropertyRegistrations(Type type, string propertyName, params string[] propertyNames)
            :this(type)
        {
            this.Add(propertyName);
            foreach (var propName in propertyNames)
            {
                this.Add(propName);
            }
        }

        /// <summary>
        /// Gets the entity type.
        /// </summary>
        public Type EntityType => _type;

        /// <summary>
        /// Adds a new property to the collection by name.
        /// </summary>
        public PropertyDescriptor Add(string propertyName)
        {
            var propertyInfo = TypeDescriptor
                .GetProperties(_type)
                .OfType<PropertyDescriptor>()
                .Single(propInfo => string.Equals(propInfo.Name, propertyName));

            this.Add(propertyInfo);
            return propertyInfo;
        }
    }
}