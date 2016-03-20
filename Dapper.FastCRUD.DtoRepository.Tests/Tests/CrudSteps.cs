namespace Dapper.FastCRUD.DtoRepository.Tests.Tests
{
    using System;
    using Dapper.FastCrud.Dto;
    using Dapper.FastCRUD.DtoRepository.Tests.DbModels;
    using Dapper.FastCRUD.DtoRepository.Tests.DtoModels;
    using Dapper.FastCRUD.DtoRepository.Tests.Repositories;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class CrudSteps
    {
        private DatabaseTestContext _databaseTestContext;

        public CrudSteps(DatabaseTestContext databaseTestContext)
        {
            _databaseTestContext = databaseTestContext;
        }

        [Given(@"I have set up the building identity repository")]
        public void GivenIHaveSetUpTheBuildingIdentityRepository()
        {
            _databaseTestContext.BuildingIdentityRepository = new BuildingIdentityRepository();
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
