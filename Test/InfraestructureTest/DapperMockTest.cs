using Infraestructure.Entity;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;
using System.Data;

namespace Test.InfraestructureTest
{
    public class DapperMockTest : Infraestructure.Business.SqlImplementation.DB.Dapper
    {
        private OrmLiteConnectionFactory dbFactory;
        public DapperMockTest(string connectionString) : base(connectionString)
        {
            dbFactory = new OrmLiteConnectionFactory(connectionString, SqliteOrmLiteDialectProvider.Instance);
        }

        public override IDbConnection GetConnection()
        {
            IDbConnection dbConnection = dbFactory.OpenDbConnection();
            dbConnection.CreateTableIfNotExists(typeof(PropertyEntity));
            return dbConnection;
        }

    }
}
