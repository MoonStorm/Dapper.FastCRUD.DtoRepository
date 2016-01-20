namespace Dapper.FastCRUD.DtoRepository.Tests.Tests
{
    using System.Configuration;
    using System.Data.SQLite;
    using TechTalk.SpecFlow;

    [Binding]
    public class DatabaseSteps
    {
        private DatabaseTestContext _databaseTestContext;

        public DatabaseSteps(DatabaseTestContext databaseTestContext)
        {
            _databaseTestContext = databaseTestContext;
        }

        [BeforeScenario]
        public void Init()
        {
            _databaseTestContext.DatabaseConnection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["SqLite"].ConnectionString);
            _databaseTestContext.DatabaseConnection.Open();

            using (var command = _databaseTestContext.DatabaseConnection.CreateCommand())
            {
                command.CommandText =
                    $@"CREATE TABLE BuildingDbEntities (
	                        Id integer primary key AUTOINCREMENT,
                            Name nvarchar(100) NULL
                        )";

                command.ExecuteNonQuery();
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {    
            _databaseTestContext.DatabaseConnection?.Close();        
        }
    }
}
