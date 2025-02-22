var builder = DistributedApplication.CreateBuilder(args);
var redis = builder.AddRedis("redis");
builder.AddProject<Projects.API>("api");
builder.AddProject<Projects.Basket_API>("basket-api")
    .WithReference(redis);

builder.AddProject<Projects.Ordering_Api>("ordering-api");

builder.AddProject<Projects.Identity_API>("identity-api");

builder.Build().Run();
