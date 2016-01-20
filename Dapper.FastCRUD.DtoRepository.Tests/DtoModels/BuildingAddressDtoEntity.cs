namespace Dapper.FastCRUD.DtoRepository.Tests.DtoModels
{
    public class BuildingAddressDtoEntity
    {
        public int BuildingId { get; set; }
        public BuildingAddress Address { get; set; }

        public class BuildingAddress
        {
            public string Street { get; set; }
            public int Number { get; set; }
            public string City { get; set; }
        }
    }
}
