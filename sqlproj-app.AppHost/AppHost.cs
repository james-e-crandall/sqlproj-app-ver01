var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql")
    .WithLifetime(ContainerLifetime.Persistent);

var db = sql.AddDatabase("database");

if(builder.ExecutionContext.IsRunMode)
{
    var blogLibMigrationService = builder.AddProject<Projects.BlogLib_MigrationService>("BlogLib-MigrationService")
        .WithReference(db)
        .WaitFor(db);
}
else
{
    var blogLibMigrationService = builder.AddSqlProject("catalog-schema")
        .WithDacpac("../Database/bin/Debug/net10.0/Database.dacpac")
        .WithReference(db);
}




builder.Build().Run();
