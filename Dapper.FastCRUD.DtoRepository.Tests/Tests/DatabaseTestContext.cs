namespace Dapper.FastCRUD.DtoRepository.Tests.Tests
{
    using System;
    using System.Data;
    using NUnit.Framework;
    using System.Collections.Generic;
    using Dapper.FastCrud.Dto;
    using Dapper.FastCRUD.DtoRepository.Tests.DbModels;
    using Dapper.FastCRUD.DtoRepository.Tests.DtoModels;

    public class DatabaseTestContext
    {
        public DatabaseTestContext()
        {
        }

        public IDbConnection DatabaseConnection { get; set; }
        public List<object> InsertedEntities { get; set; }
        public List<object> QueriedEntities { get; set; }
        public List<object> UpdatedEntities { get; set; }
        public Repository<BuildingIdentityDtoEntity> BuildingIdentityRepository { get; set; }
        public Repository<BuildingAddressDtoEntity> BuildingAddressRepository { get; set; }
    }
}
