﻿namespace Dapper.FastCrud.Dto.Mappings
{
    using Dapper.FastCrud.Dto.Converters;

    /// <summary>
    /// Defines a mapping between a set of db entities and a set of dto entities, helping with the direction used in the process.
    /// </summary>
    public class DtoToDbUnifyingMapping : UnifyingMapping
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public DtoToDbUnifyingMapping()
        {
        }

        /// <summary>
        /// Constructor that takes a mapping as a source.
        /// </summary>
        public DtoToDbUnifyingMapping(IMapping originalMapping)
            : base(originalMapping.DtoToDbConverter, originalMapping.DbToDtoConverter)
        {
        }

        /// <summary>
        /// Converter for the dto to db conversion and the registrar of properties of both sides used in the process.
        /// </summary>
        public override IEntityConverter DtoToDbConverter => this.SourceToDestinationConverter;

        /// <summary>
        /// Converter for the db to dto conversion and the registrar of properties of both sides used in the process.
        /// </summary>
        public override IEntityConverter DbToDtoConverter => this.DestinationToSourceConverter;
    }
}
