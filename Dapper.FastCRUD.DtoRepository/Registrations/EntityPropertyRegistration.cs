namespace Dapper.FastCrud.Dto.Registrations
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Dapper.FastCrud.DtoRepository;

    /// <summary>
    /// Holds a flatten hierarchy of properties.
    /// </summary>
    public class EntityPropertyRegistration
    {
        private readonly Type _entityType;
        private readonly IReadOnlyList<PropertyInfo> _propertyInfos;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public EntityPropertyRegistration(Type entityType, IReadOnlyList<PropertyInfo> propertyInfos)
        {
            Requires.NotNull(entityType, nameof(entityType));
            Requires.NotNullOrEmptyOrNullElements(propertyInfos, nameof(propertyInfos));
            Requires.Argument(propertyInfos[0].DeclaringType == entityType, nameof(propertyInfos), $"The list of properties isn't rooted into the type '{entityType}'");

            _entityType = entityType;
            _propertyInfos = propertyInfos;
        }

        /// <summary>
        /// Type of the entity the property is linked to.
        /// </summary>
        public Type EntityType => _entityType;

        /// <summary>
        /// Gets the root property bound to the entity type.
        /// </summary>
        public string EntityPropertyName => _propertyInfos[0].Name;

        /// <summary>
        /// Gets the value.
        /// </summary>
        public object GetValue(object entity)
        {
            var targetObject = entity;
            foreach (var propInfo in _propertyInfos)
            {
                targetObject = propInfo.GetValue(targetObject);
            }

            return targetObject;
        }

        /// <summary>
        /// Set the value.
        /// </summary>
        public void SetValue(object entity, object value)
        {
            var targetObject = entity;
            for (var propIndex = 0; propIndex < _propertyInfos.Count - 1; propIndex++)
            {
                var propInfo = _propertyInfos[propIndex];
                var nextTargetObject = propInfo.GetValue(targetObject);
                if (nextTargetObject == null)
                {
                    nextTargetObject = Activator.CreateInstance(propInfo.PropertyType);
                    propInfo.SetValue(targetObject, nextTargetObject);
                }

                targetObject = nextTargetObject;
            }

            _propertyInfos[_propertyInfos.Count - 1].SetValue(targetObject, value);
        }

    }
}
