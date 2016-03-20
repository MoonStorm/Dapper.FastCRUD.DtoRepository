namespace Dapper.FastCRUD.DtoRepository.Tests.Tests
{
    using System.Data;
    using System.Collections.Generic;
    using Dapper.FastCRUD.DtoRepository.Tests.Repositories;

    public class DatabaseTestContext
    {
        public DatabaseTestContext()
        {
        }

        public IDbConnection DatabaseConnection { get; set; }
        public List<object> InsertedEntities { get; set; }
        public List<object> QueriedEntities { get; set; }
        public List<object> UpdatedEntities { get; set; }
        public BuildingIdentityRepository BuildingIdentityRepository { get; set; }
        //public Repository<BuildingAddressDtoEntity> BuildingAddressRepository { get; set; }
    }
}
