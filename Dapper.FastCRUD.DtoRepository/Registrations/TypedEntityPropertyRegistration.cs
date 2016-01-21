namespace Dapper.FastCrud.Dto.Registrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// Holds a flatten hierarchy of properties.
    /// </summary>
    public class TypedEntityPropertyRegistration<TEntity>: EntityPropertyRegistration
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public TypedEntityPropertyRegistration(Expression<Func<TEntity, object>> property)
            :base(typeof(TEntity), FlattenExpression(property))
        {           
        }

        private static IReadOnlyList<PropertyInfo> FlattenExpression(Expression<Func<TEntity, object>> propertyExpression)
        {
            var flattenExpression = new List<PropertyInfo>();

            var memberExpression = (MemberExpression)propertyExpression.Body;
            var propertyInfo = memberExpression.Member as PropertyInfo;
            while(propertyInfo!=null)
            {
                flattenExpression.Add(propertyInfo);
                if (propertyInfo.DeclaringType == typeof(TEntity))
                {
                    propertyInfo = null;
                }
                else
                {
                    memberExpression = (MemberExpression)memberExpression.Expression;
                    propertyInfo = memberExpression.Member as PropertyInfo;
                }
            }

            flattenExpression.Reverse();

            return flattenExpression.AsReadOnly();
        }
    }
}
