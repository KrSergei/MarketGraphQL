using MarketGraphQL.Abstraction;
using MarketGraphQL.Mapper;
using MarketGraphQL.Models;
using MarketGraphQL.Query;
using MarketGraphQL.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.GetConnectionString("db");

builder.Services.AddMemoryCache();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IStorageService, StorageService>();
builder.Services.AddSingleton<ICategoryService, CategoryService>();
builder.Services.AddSingleton<AppDbContext>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<SimpleQuery>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
