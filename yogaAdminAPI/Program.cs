using System.Data;
using System.Data.SqlClient;
using yogaAdminLib.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using yogaAdminAPI.Interfaces;
using yogaAdminAPI.Services;
using System.Reflection;
using yogaAdminAPI.Profiles;


IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();
var builder = WebApplication.CreateBuilder(args);

var Services = builder.Services;

//註冊DB
var yogaAdminConnStr = configuration.GetValue<string>("ConnectionStrings:yogaAdminDB");
Services.AddDbContext<yogaAdminDataContext>(options => options.UseNpgsql(yogaAdminConnStr));


//Services DI
Services.AddScoped<ITeacherService, TeacherService>();

//auto mapper 

List<Assembly> ass = new List<Assembly>();

ass.Add(Assembly.GetAssembly(typeof(TeacherProfile))); //瑜珈老師相關CRUD

Services.AddAutoMapper(ass);

builder.Services.AddControllers()
                .AddJsonOptions(Options =>
                {
                    Options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    // Options.JsonSerializerOptions.IgnoreNullValues = true;
                });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
      c.SwaggerDoc("v1", new OpenApiInfo { Title = "yogaAdmin API", Version = "v1.0.0" });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
     app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "yogaAdmin v1");
        c.DefaultModelsExpandDepth(-1);
        c.DocExpansion(DocExpansion.None);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
