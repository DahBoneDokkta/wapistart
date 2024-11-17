using Models;
using DbRepos;
using Services;
using Configuration;
using System.Runtime.InteropServices;
using DbContext;
using Microsoft.EntityFrameworkCore;
using Seido.Utilities.SeedGenerator;
using DbModels;

var builder = WebApplication.CreateBuilder(args);

// global cors policy
builder.Services.AddCors();

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Dependency Inject Custom logger
builder.Services.AddSingleton<ILoggerProvider, csInMemoryLoggerProvider>();
#endregion

#region Register csMainDbContext in DI container
// Registrera databaskontetexten och anslutningssträngen från appsettings.json
builder.Services.AddDbContext<csMainDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
#endregion

#region Dependency Inject

builder.Services.AddScoped<IAttractionRepo, csAttractionRepo>();
builder.Services.AddScoped<IAttractionService, csAttractionService>();

builder.Services.AddScoped<ICityRepo, csCityRepo>();
builder.Services.AddScoped<ICityService, csCityService>();

builder.Services.AddScoped<ICountryRepo, csCountryRepo>();
builder.Services.AddScoped<ICountryService, csCountryService>();

builder.Services.AddScoped<IUserRepo, csUserRepo>();
builder.Services.AddScoped<IUserService, csUserService>();

builder.Services.AddScoped<ICommentRepo, csCommentRepo>();
builder.Services.AddScoped<ICommentService, csCommentService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Simon's API V1");
    });
}

app.UseHttpsRedirection();

// global cors policy - the call to UseCors() must be done here
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials


app.MapControllers();
app.Run();

