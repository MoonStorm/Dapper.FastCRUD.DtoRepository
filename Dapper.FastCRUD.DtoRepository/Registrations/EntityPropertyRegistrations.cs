namespace Dapper.FastCrud.DtoRepository.Registrations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    /// <summary>
    /// Contains the definition of all the properties on a specific entity that are involved in a mapping.
    /// </summary>
    public class EntityPropertyRegistrations
    {
        private readonly List<PropertyDescriptor> _properties = new List<PropertyDescriptor>();
        private readonly Dictionary<string, PropertyDescriptor> _propertyNameMap = new Dictionary<string, PropertyDescriptor>();
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
        /// Gets the list of properties.
        /// </summary>
        public IEnumerable<PropertyDescriptor> GetProperties()
        {
            return _properties;
        }

        /// <summary>
        /// Get a property descriptor by name.
        /// </summary>
        public PropertyDescriptor GetProperty(string propertyName)
        {
            return _propertyNameMap[propertyName];
        }

        /// <summary>
        /// Adds a new property to the collection by name.
        /// </summary>
        public void Add(string propertyName)
        {
            var propertyInfo = TypeDescriptor
                .GetProperties(_type)
                .OfType<PropertyDescriptor>()
                .Single(propInfo => string.Equals(propInfo.Name, propertyName));

            this.Add(propertyInfo);
        }

        private void Add(PropertyDescriptor propertyInfo)
        {
            _properties.Add(propertyInfo);
            _propertyNameMap[propertyInfo.Name] = propertyInfo;
        }
    }
}