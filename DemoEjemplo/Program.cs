using DB;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RegContext>(options => 
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConexionPostgreSQL"));
});

//Repository
builder.Services.AddScoped<CursoRepository>();
builder.Services.AddScoped<EstudianteRepository>();
builder.Services.AddScoped<InscripcionRepository>();

//Service
builder.Services.AddScoped<CursoService>();
builder.Services.AddScoped<EstudianteService>();
builder.Services.AddScoped<InscripcionService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<RegContext>();
    context.Database.Migrate();
}

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
