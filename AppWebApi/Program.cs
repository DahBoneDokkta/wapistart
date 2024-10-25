using Models;
using DbRepos;
using Services;
using Configuration;
using System.Runtime.InteropServices;
using DbContext;
using Microsoft.EntityFrameworkCore;
using Seido.Utilities.SeedGenerator;

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
    options.UseSqlServer(builder.Configuration.GetConnectionString("Data Source=localhost,14333;Initial Catalog=wapistart;Persist Security Info=True;User ID=sa;Pwd=skYhgS@83#aQ;Encrypt=False;")));
#endregion

#region Dependency Inject
//builder.Services.AddSingleton<IAnimalsService,csAnimalsService2>();
// builder.Services.AddScoped<IAnimalRepo, csAnimalRepo>();
//builder.Services.AddScoped<IAnimalsService,csAnimalServiceDb>();
builder.Services.AddScoped<ICountryService, csCountryService>();
builder.Services.AddScoped<ICityService, csCityService>();
builder.Services.AddScoped<IAttractionService, csAttractionService>();
builder.Services.AddScoped<IUserService, csUserService>();
builder.Services.AddScoped<ICommentService, csCommentService>();
builder.Services.AddScoped<csSeedGenerator>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
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

