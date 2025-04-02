var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddAuthorization();

builder.Services.AddAuthentication()
    .AddKeycloakJwtBearer("keycloak", realm: "AgVo-auth", options =>
    {
        options.RequireHttpsMetadata = false;
        options.Audience = "account";
    });
var app = builder.Build();

app.MapDefaultEndpoints();

app.MapGet("/", () => "Hello World!").RequireAuthorization();

app.UseAuthentication();

app.UseAuthorization();

app.Run();
