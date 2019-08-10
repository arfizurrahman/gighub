using NUnit.Framework;
using System.Data.Entity.Migrations;

namespace GigHub.IntegrationTests
{
    [SetUpFixture]
    public class GlobalSetUp
    {
        [SetUp]
        public void SetUp()
        {
            var configuration = new GigHubApp.Migrations.Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();
        }
    }
}
