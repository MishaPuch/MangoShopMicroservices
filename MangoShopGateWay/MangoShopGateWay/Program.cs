using MangoShopGateWay.Agregators;
using MangoShopGateWay.ModelDto.AggregationModel;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json", optional : false, reloadOnChange : true);
builder.Services.AddOcelot(builder.Configuration)
    .AddCacheManager(x => x.WithDictionaryHandle())
    .AddSingletonDefinedAggregator<ProductsWarehousesAggregator>()
    .AddSingletonDefinedAggregator<ProductBasketAggregator>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors();

app.UseOcelot();

app.Run();
