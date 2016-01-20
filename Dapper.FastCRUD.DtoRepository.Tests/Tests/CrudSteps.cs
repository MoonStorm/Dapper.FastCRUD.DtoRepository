namespace Dapper.FastCRUD.DtoRepository.Tests.Tests
{
    using System;
    using Dapper.FastCrud.Dto;
    using Dapper.FastCRUD.DtoRepository.Tests.DbModels;
    using Dapper.FastCRUD.DtoRepository.Tests.DtoModels;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class CrudSteps
    {
        private DatabaseTestContext _databaseTestContext;

        public CrudSteps(DatabaseTestContext databaseTestContext)
        {
            _databaseTestContext = databaseTestContext;
        }

        [Given(@"I have set up the building address repository")]
        public void GivenIHaveSetUpTheBuildingAddressRepository()
        {
            var repository = new StandardRepository<BuildingAddressDtoEntity>();
            repository.Map.From<BuildingDbEntity>(
                mapping => mapping
                               .FromProperty(db => db.Id)
                               .TwoWayToProperty(dto => dto.BuildingId)
                               .And()
                               .FromProperty(db => db.AddressStreet)
                               .TwoWayToProperty(dto => dto.Address.Street)
                               .And()
                               .FromProperty(db => db.AddressNumber)
                               .TwoWayToProperty(dto => dto.Address.Number)
                               .And()
                               .FromProperty(db => db.AddressCity)
                               .TwoWayToProperty(dto => dto.Address.City));

            _databaseTestContext.BuildingAddressRepository = repository;
        }

        [Given(@"I have set up the building identity repository")]
        public void GivenIHaveSetUpTheBuildingIdentityRepository()
        {
            var repository = new StandardRepository<BuildingIdentityDtoEntity>();
            repository.Map.From<BuildingDbEntity>(mapping => mapping
                .FromProperty(db => db.Id)
                .TwoWayToProperty(dto => dto.Id)
                .And()
                .FromProperty(db => db.Id)
                .TwoWayToProperty(dto => dto.Id));

            _databaseTestContext.BuildingIdentityRepository = repository;
        }

        [Given(@"I have inserted (.*) full building DTOs")]
        public void GivenIHaveInsertedFullBuildingDTOs(int p0)
        {
        }

        [When(@"I retrieve all the building identity DTOs")]
        public void WhenIRetrieveAllTheBuildingIdentityDTOs()
        {
        }

        [Then(@"the retrieved building identity DTOs should match the inserted full building DTOs")]
        public void ThenTheRetrievedBuildingIdentityDTOsShouldMatchTheInsertedFullBuildingDTOs()
        {
        }
    }
}
