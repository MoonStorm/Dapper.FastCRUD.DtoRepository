namespace Dapper.FastCRUD.DtoRepository.Tests.DtoRepositories
{
    using System;
    using Dapper.FastCrud.Dto;
    using Dapper.FastCrud.Dto.Mappings;
    using Dapper.FastCRUD.DtoRepository.Tests.DtoModels;
    using Dapper.FastCRUD.DtoRepository.Tests.TestEnvironment;

    public static class DtoRepositoryFactory
    {
        private static Lazy<Repository<BuildingIdentityDtoEntity>> _buildingIdentityDtoRepository;
        static DtoRepositoryFactory()
        {
            
        }

        private static Repository<BuildingIdentityDtoEntity> CreateBuildingIdentityDtoRepository()
        {
            var repository = new StandardRepository<BuildingIdentityDtoEntity>();
            repository.Map.From<BuildingDbEntity>(mapping => 
                mapping
                    .FromProperties(db => db.BuildingId, db=> db.BuildingName)
                    .ToProperties(dto => dto.Id, dto=> dto.Name)
                    .WithContext(0)
                    .UsingCallback((source, context, destination)=> {}));
            //repository.Map.Map<BuildingIdentityDtoEntity>().To<BuildingIdentityDtoEntity>()
        }
    }
}
