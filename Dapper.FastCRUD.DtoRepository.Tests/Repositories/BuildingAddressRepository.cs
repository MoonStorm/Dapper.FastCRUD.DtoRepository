namespace Dapper.FastCRUD.DtoRepository.Tests.Repositories
{
    using Dapper.FastCRUD.DtoRepository.Tests.DtoModels;

    public class BuildingAddressRepository<TBuildingAddress>: BuildingIdentityRepository<TBuildingAddress>
        where TBuildingAddress:BuildingAddressDtoEntity
    {
        public BuildingAddressRepository()
        {
            this.GetBuilder().From(
                dbMapping => dbMapping
                                 .Property(dbEntity => dbEntity.AddressCity).TwoWayTo(dtoEntity => dtoEntity.Address.City)
                                 .And.Property(dbEntity => dbEntity.AddressNumber).TwoWayTo(dtoEntity => dtoEntity.Address.Number)
                                 .And.Property(dbEntity => dbEntity.AddressStreet).TwoWayTo(dtoEntity => dtoEntity.Address.Street));
        }
    }
}
