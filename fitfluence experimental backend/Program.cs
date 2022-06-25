using fitfluence_experimental_backend.Configurations;
using fitfluence_experimental_backend.Contracts;
using fitfluence_experimental_backend.Data;
using fitfluence_experimental_backend.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DbConnectionString");
builder.Services.AddDbContext<FitfluenceDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Allowing all cors, not a good practise. But only for this demo project.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", b => b.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});

//  logging configuration
builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

// Add automapper for dependency inversion
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

// Bind the interface to the repository
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>)); // <> represents the <T> which is a generic 
builder.Services.AddScoped<IMuscleGroupsRepository, MuscleGroupsRepository>(); // We don't do that here because the entity is known (MuscleGroup)
builder.Services.AddScoped<IExercisesRepository, ExercisesRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
