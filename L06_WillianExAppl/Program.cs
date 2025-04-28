using System.Text;
using L06_WillianExAppl.Data;
using L06_WillianExAppl.Interfaces;
using L06_WillianExAppl.Repositories;
using L06_WillianExAppl.Services;
using L06_WillianExAppl.Services.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Mapster;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add services to the container.
builder.Services.AddControllers();

// ------------------------- Configuracion BD -------------------------
// Obtener la cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// usar el dbcontext - ojo instalar npgsql.Entity...
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseNpgsql(connectionString));

// ------------------------- Configuracion de JWT -------------------------
var jwtSettings = builder.Configuration.GetSection("Jwt");
var secretKey = jwtSettings["SecretKey"];
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!))
        };
    });

// Agregar autorizacion JWT
builder.Services.AddAuthorization(options =>
{
    // Policy para usuarios administradores
    options.AddPolicy("Administrador", policy => 
        policy.RequireClaim("Administrador"));
    // Policy para usuarios estudiantes
    options.AddPolicy("Estudiante", policy => 
        policy.RequireClaim("Estudiante"));
    // Policy para usuarios profesores
    options.AddPolicy("Profesor", policy => 
        policy.RequireClaim("Profesor"));
});

// instalacion swagger 
builder.Services.AddEndpointsApiExplorer();
// codiguracion de swagger para poder pasar bearer en el header de la peticion
builder.Services.AddSwaggerGen(c =>
{
    // Configuración de JWT Bearer en Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Please enter your JWT token",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT"
    });
    
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// ------------------- Inyeccion de repositorios y servicios -------------------
// repositorios
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();

// inyectar servicios
builder.Services.AddScoped<IAsistenciasService, AsistenciasService>();
builder.Services.AddScoped<ICursosService, CursosService>();
builder.Services.AddScoped<IEstudiantesService, EstudiantesService>();
builder.Services.AddScoped<IEvaluacionesService, EvaluacionesService>();
builder.Services.AddScoped<IMateriasService, MateriasService>();
builder.Services.AddScoped<IMatriculasService, MatriculasService>();
builder.Services.AddScoped<IProfesoresService, ProfesoresService>();
builder.Services.AddScoped<IUsuariosService, UsuariosService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// ------------------------- app construida -------------------------
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    // uso de swagger
    app.UseSwagger();
    // extra de configuracion de swagger para poder pasar bearer en el header de la peticion
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
        c.RoutePrefix = string.Empty; // Esto hace que Swagger esté en "/"
        c.DefaultModelsExpandDepth(-1); // Ocultar modelos por defecto si no lo necesitas
    });
}

app.UseHttpsRedirection();

// agregar para que funcione
app.UseRouting();
app.UseAuthentication(); // agregado para jwt
app.UseAuthorization();
app.MapControllers(); // para swagger y APIRESTful


// ------------------------------ EJEMPLO DATOS PRUEBA ------------------------------
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}