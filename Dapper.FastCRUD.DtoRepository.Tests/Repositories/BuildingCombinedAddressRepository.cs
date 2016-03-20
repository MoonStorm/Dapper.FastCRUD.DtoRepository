namespace Dapper.FastCRUD.DtoRepository.Tests.Repositories
{
    using Dapper.FastCRUD.DtoRepository.Tests.DtoModels;
    public class BuildingCombinedAddressRepository : BuildingIdentityRepository<BuildingCombinedAddressDtoEntity>
    {
        public BuildingCombinedAddressRepository()
        {
            this.GetBuilder().From(dbMapping => dbMapping
                .Properties(dbEntity => dbEntity.AddressCity, dbEntity => dbEntity.AddressStreet, dbEntity => dbEntity.AddressNumber)
                .To(dtoEntity => dtoEntity.Address)
                .UsingCallback((dbEntity, dtoEntity, contextStore)=>dtoEntity.Address = $"City {dbEntity.AddressCity}, Street {dbEntity.AddressStreet}, Number {dbEntity.AddressNumber}"));
        }
    }
}
