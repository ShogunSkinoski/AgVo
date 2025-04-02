var builder = DistributedApplication.CreateBuilder(args);
var keycloak = builder.AddKeycloak("keycloak", 8000)
    .WithRealmImport("Realms/realm-export.json")
    .WithDataVolume()
    .WithExternalHttpEndpoints();

builder.AddProject<Projects.Web_Api>("web-api")
    .WithExternalHttpEndpoints()
    .WithReference(keycloak);

builder.Build().Run();
