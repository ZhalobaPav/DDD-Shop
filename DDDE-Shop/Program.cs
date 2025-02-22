using API.Extensions;
using API.Infrastructure;
using Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.AddBasicServiceDefaults();

// Add services to the container.

builder.Services.ConfigureInfrastructure(builder.Configuration);
builder.Services.AddServiceDependencies();
builder.Services.AddApplicationDependencies();
builder.Services.AddWebServices();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
    });
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseOpenApi();
}
app.UseSwaggerUi(settings =>
{
    settings.Path = "/api";
    settings.DocumentPath = "/api/specification.json";
});

using (var scope = app.Services.CreateScope())
{
    var scopedProvider = scope.ServiceProvider;
    try
    {
        var catalogContext = scopedProvider.GetRequiredService<CatalogContext>();
        await CatalogContextSeed.SeedAsync(catalogContext, app.Logger);
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "An error occurred seeding the DB.");
    }
}
app.UseCors("CorsPolicy");
app.UseStaticFiles();
app.UseHttpsRedirection();
app.Map("/", () => Results.Redirect("/api"));
app.MapEndpoints();
app.Run();
