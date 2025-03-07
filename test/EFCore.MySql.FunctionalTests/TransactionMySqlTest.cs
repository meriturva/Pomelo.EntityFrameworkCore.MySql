using System;
using System.Threading.Tasks;
using Pomelo.EntityFrameworkCore.MySql.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;
using Pomelo.EntityFrameworkCore.MySql.Tests;

namespace Pomelo.EntityFrameworkCore.MySql.FunctionalTests
{
    public class TransactionMySqlTest : TransactionTestBase<TransactionMySqlTest.TransactionMySqlFixture>
    {
        public TransactionMySqlTest(TransactionMySqlFixture fixture)
            : base(fixture)
        {
        }

        protected override bool SnapshotSupported => true;
        protected override bool AmbientTransactionsSupported => true;

        protected override DbContext CreateContextWithConnectionString()
        {
            var options = Fixture.AddOptions(
                    new DbContextOptionsBuilder()
                        .UseMySql(
                            TestStore.ConnectionString,
                            AppConfig.ServerVersion,
                            b => MySqlTestStore.AddOptions(b).ExecutionStrategy(c => new MySqlExecutionStrategy(c))))
                .UseInternalServiceProvider(Fixture.ServiceProvider);

            return new DbContext(options.Options);
        }

        public class TransactionMySqlFixture : TransactionFixtureBase
        {
            protected override ITestStoreFactory TestStoreFactory => MySqlTestStoreFactory.Instance;

            public override async Task ReseedAsync()
            {
                await using var context = CreateContext();
                context.Set<TransactionCustomer>().RemoveRange(context.Set<TransactionCustomer>());
                context.Set<TransactionOrder>().RemoveRange(context.Set<TransactionOrder>());
                await context.SaveChangesAsync();

                await base.SeedAsync(context);
            }

            public override DbContextOptionsBuilder AddOptions(DbContextOptionsBuilder builder)
            {
                new MySqlDbContextOptionsBuilder(
                        base.AddOptions(builder))
                    .ExecutionStrategy(c => new MySqlExecutionStrategy(c));
                return builder;
            }

            // public override DbContextOptionsBuilder AddOptions(DbContextOptionsBuilder builder)
            // {
            //     new MySqlDbContextOptionsBuilder(base.AddOptions(builder))
            //         .MaxBatchSize(1);
            //     return builder;
            // }
        }
    }
}
