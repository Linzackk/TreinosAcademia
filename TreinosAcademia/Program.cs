using Microsoft.EntityFrameworkCore;
using TreinosAcademia.Data;
using TreinosAcademia.Repositories;
using TreinosAcademia.Repositories.Interfaces;
using TreinosAcademia.Services;
using TreinosAcademia.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ITreinoRepository, TreinoRepository>();
builder.Services.AddScoped<ITreinoExercicioRepository, TreinoExercicioRepository>();
builder.Services.AddScoped<IExercicioRepository, ExercicioRepository>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ITreinoService, TreinoService>();
builder.Services.AddScoped<ITreinoExercicioService, TreinoExercicioService>();
builder.Services.AddScoped<IExercicioService, ExercicioService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
