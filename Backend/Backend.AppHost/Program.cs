var builder = DistributedApplication.CreateBuilder(args);
builder.AddKeycloak("keycloak", 8000).WithRealmImport("Realms/realm-export.json");
builder.Build().Run();
