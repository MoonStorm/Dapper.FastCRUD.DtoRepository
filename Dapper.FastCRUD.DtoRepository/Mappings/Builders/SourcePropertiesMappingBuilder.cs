namespace Dapper.FastCrud.Dto.Mappings.Builders
{
    using System;
    using System.Linq.Expressions;
    using Dapper.FastCrud.DtoRepository;
    using Dapper.FastCrud.DtoRepository.Registrations;

    /// <summary>
    /// Partial builder for a source and a set of properties
    /// </summary>
    public class SourcePropertiesMappingBuilder<TSource, TDestination>
    {
        private readonly UnifyingMapping _unifyingMapping;
        private readonly TypedEntityPropertyRegistrations<TSource> _sourcePropertyDescriptors;

        public SourcePropertiesMappingBuilder(UnifyingMapping unifyingMapping, TypedEntityPropertyRegistrations<TSource> sourcePropertyDescriptors)
        {
            Requires.NotNull(unifyingMapping, nameof(unifyingMapping));
            Requires.NotNull(sourcePropertyDescriptors, nameof(sourcePropertyDescriptors));            
            Requires.Range(sourcePropertyDescriptors.Count > 0, $"Please provide all the properties used in the conversion of '{typeof(TSource)}' to '{typeof(TDestination)}'.");
            
            _unifyingMapping = unifyingMapping;
            _sourcePropertyDescriptors = sourcePropertyDescriptors;
        }

        public DestinationPropertiesMappingBuilder<TSource, TDestination> ToProperties(params Expression<Func<TDestination, object>>[] propertyNames)
        {
            //_propertyName = ((MemberExpression)propertyDefinition.Body).Member.Name;
            return new DestinationPropertiesMappingBuilder<TSource, TDestination>(_unifyingMapping, _sourcePropertyDescriptors, propertyNames);
        }
    }
}
