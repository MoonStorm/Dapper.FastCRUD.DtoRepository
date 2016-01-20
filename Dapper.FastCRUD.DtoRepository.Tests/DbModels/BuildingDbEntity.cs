namespace Dapper.FastCRUD.DtoRepository.Tests.DbModels
{
    public class BuildingDbEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public string AddressStreet { get; set; }
        public int AddressNumber { get; set; }
        public string AddressCity { get; set; }
    }
}
