namespace Dapper.FastCrud.DtoRepository.Registrations
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// Contains the definition of all the properties on a specific entity that are involved in a mapping.
    /// </summary>
    public class TypedEntityPropertyRegistrations<T> : EntityPropertyRegistrations
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public TypedEntityPropertyRegistrations():base(typeof(T))
        {
        }

        /// <summary>
        /// Constructor that takes a list of parameter names as arguments.
        /// </summary>
        public TypedEntityPropertyRegistrations(string propertyName, params string[] propertyNames)
            :base(typeof(T),propertyName, propertyNames)
        {
            this.Add(propertyName);
            foreach (var propName in propertyNames)
            {
                this.Add(propName);
            }
        }

        /// <summary>
        /// Adds a new property to the collection based on a lambda expression.
        /// </summary>
        public PropertyDescriptor Add<TPropertyValue>(Expression<Func<T, TPropertyValue>> property)
        {
            var memberInfo = ((MemberExpression)property.Body).Member;
            var propertyInfo = memberInfo as PropertyInfo;
            Requires.Argument(propertyInfo!=null, nameof(property), $"{memberInfo.Name} is not a property of {typeof(T)}");
            return this.Add(propertyInfo.Name);
        }
    }
}
