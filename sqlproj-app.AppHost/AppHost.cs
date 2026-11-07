var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql")
    .WithLifetime(ContainerLifetime.Persistent)
    .WithDbGate();

var db = sql.AddDatabase("database");

// if(builder.ExecutionContext.IsRunMode)
// {
//     var blogLibMigrationService = builder.AddProject<Projects.BlogLib_MigrationService>("BlogLib-MigrationService")
//         .WithReference(db)
//         .WaitFor(db);
// }
// else
// {
//     var blogLibMigrationService = builder.AddSqlProject("catalog-schema")
//         .WithDacpac("../Data-Tier/bin/Debug/net10.0/Data-Tier.dacpac")
//         .WithReference(db);
// }

var blogLibMigrationService = builder.AddSqlProject("catalog-schema")
    .WithDacpac("../Data-Tier/bin/Debug/net10.0/Data-Tier.dacpac")
    .WithReference(db);

var blogApi = builder.AddProject<Projects.BlogApi>("BlogApi")
    .WithReference(db)
    .WaitFor(db)
    .WaitForCompletion(blogLibMigrationService);


builder.Build().Run();
