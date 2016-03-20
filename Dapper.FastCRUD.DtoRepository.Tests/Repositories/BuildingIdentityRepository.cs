namespace Dapper.FastCRUD.DtoRepository.Tests.Repositories
{
    using Dapper.FastCrud.Dto;
    using Dapper.FastCRUD.DtoRepository.Tests.DbModels;
    using Dapper.FastCRUD.DtoRepository.Tests.DtoModels;

    public class BuildingIdentityRepository<TBuildingDto>:StandardRepository<TBuildingDto, BuildingDbEntity>
        where TBuildingDto:BuildingIdentityDtoEntity
    {
        public BuildingIdentityRepository()
        {
            this.GetBuilder()
                .From(dbMappingBuilder => dbMappingBuilder
                                            .Property(dbEntity => dbEntity.Id)
                                            .TwoWayTo(dtoEntity => dtoEntity.Id)
                                            .And.Property(dbEntity => dbEntity.Name)
                                            .OneWayTo(dtoEntity => dtoEntity.Name));

            this.GetBuilder()
                .To(dtoMappingBuilder => dtoMappingBuilder
                                            .Property(dtoEntity => dtoEntity.Name)
                                            .OneWayTo(dbEntity => dbEntity.Name));

        }
    }

    public class BuildingIdentityRepository : BuildingIdentityRepository<BuildingIdentityDtoEntity>
    {
    }
}
