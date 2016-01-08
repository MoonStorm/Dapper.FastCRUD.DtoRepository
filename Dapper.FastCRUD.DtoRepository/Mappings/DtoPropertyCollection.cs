namespace Dapper.FastCrud.DtoRepository.Mappings
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// Holds a list of properties.
    /// </summary>
    /// <typeparam name="T">The type exposing the collection of properties</typeparam>
    public class DtoPropertyCollection<T>
    {
        private List<PropertyDescriptor> _properties = new List<PropertyDescriptor>();
        private Dictionary<string, PropertyDescriptor> _propertyNameMap = new Dictionary<string, PropertyDescriptor>();
        private Type _type;

        /// <summary>
        /// Default constructor
        /// </summary>
        public DtoPropertyCollection()
        {
            _type = typeof(T);
        }

        /// <summary>
        /// Constructor that takes a list of parameter names as arguments.
        /// </summary>
        public DtoPropertyCollection(string propertyName, params string[] propertyNames)
            :this()
        {
            this.Add(propertyName);
            foreach (var propName in propertyNames)
            {
                this.Add(propName);
            }
        }

        public DtoPropertyCollection<T> Add<TPropertyValue>(Expression<Func<T, TPropertyValue>> property)
        {
            var memberInfo = ((MemberExpression)property.Body).Member;
            var propertyInfo = memberInfo as PropertyInfo;
            Requires.Argument(propertyInfo!=null, nameof(property), $"{memberInfo.Name} is not a property of {typeof(T)}");
            this.Add(propertyInfo.Name);
            return this;
        }

        private void Add(PropertyDescriptor propertyInfo)
        {
            _properties.Add(propertyInfo);
            _propertyNameMap[propertyInfo.Name] = propertyInfo;
        }

        private void Add(string propertyName)
        {
            var propertyInfo = TypeDescriptor
                .GetProperties(_type)
                .OfType<PropertyDescriptor>()
                .SingleOrDefault(propInfo => string.Equals(propInfo.Name, propertyName));

            this.Add(propertyInfo);
        }

        /// <summary>
        /// Gets the list of properties.
        /// </summary>
        internal IReadOnlyList<PropertyDescriptor> Properties => _properties;

        /// <summary>
        /// Gets the map name - property descriptor.
        /// </summary>
        internal IReadOnlyDictionary<string, PropertyDescriptor> PropertyMap => _propertyNameMap;
    }
}
