using Discount.API.Services;
using Disount.Application.Handlers.Queries;
using Disount.Application.Mappers;
using Disount.Core.Repositories;
using Disount.Infrastructure.Extentions;
using Disount.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(typeof(DiscountProfile).Assembly);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    Assembly.GetExecutingAssembly(),
    Assembly.GetAssembly(typeof(GetDiscountQueryHandler))
    ));

builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();

builder.Services.AddGrpc();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.MigrateDatabase<Program>();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<DiscountService>();

    //endpoints.MapGet("/protos/discount.proto", async context =>
    endpoints.MapGet("/", async context =>
    {
        //await context.Response.WriteAsync(File.ReadAllText("Protos/discount.proto"));
        await context.Response.WriteAsync(File.ReadAllText("Communication with gRPC endpoints must be made through  a gRPC client"));
    });
});

//app.UseAuthorization();

//app.MapControllers();

app.Run();
