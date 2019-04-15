using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace LiqwidsDB.Test
{
    [TestClass]
    public class LiqwidsDBTest
    {
        private string connectionstring = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build().GetConnectionString("wateruseConnection");

        [TestMethod]
        public void ConnectionTest()
        {
            using (LiqwidsDBContext context = new LiqwidsDBContext(new DbContextOptionsBuilder<LiqwidsDBContext>().UseNpgsql(this.connectionstring).Options))
            {
                try
                {
                    if (!(context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists()) throw new Exception("db does ont exist");
                }
                catch (Exception ex)
                {
                    Assert.IsTrue(false, ex.Message);
                }
            }
        }
        [TestMethod]
        public void QueryTest()
        {
            using (LiqwidsDBContext context = new LiqwidsDBContext(new DbContextOptionsBuilder<LiqwidsDBContext>().UseNpgsql(this.connectionstring).Options))
            {
                try
                {
                    var testQuery = context.Liqwids.ToList();
                    Assert.IsNotNull(testQuery, testQuery.Count.ToString());
                }
                catch (Exception ex)
                {
                    Assert.IsTrue(false, ex.Message);
                }
                finally
                {
                }

            }
        }
    }
}
