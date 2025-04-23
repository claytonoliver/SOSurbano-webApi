using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using SosUrbano.Application.Services;
using SosUrbano.Application.Services.Interfaces;
using SosUrbano.Domain.Entities;
using SosUrbano.Infrastructure.Data;
using SosUrbano.Infrastructure.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Configuração de Serviços
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDb"));

// Criando e registrando o cliente do MongoDB
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = builder.Configuration.GetSection("MongoDb").Get<MongoDbSettings>();
    return new MongoClient(settings.ConnectionString);
});

// Registrando o banco de dados
builder.Services.AddScoped<IMongoDatabase>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    return sp.GetRequiredService<IMongoClient>().GetDatabase(settings.DataBaseName);
});

// Registrando o contexto do MongoDB
builder.Services.AddSingleton<MongoDbContext>();


//Registro de Dependências (Services e Repositories)
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IVeiculoService, VeiculoService>();
builder.Services.AddScoped<ITipoDeOcorrenciaService, TipoDeOcorrenciaService>();
builder.Services.AddScoped<IStatusChamadoService, StatusChamadoService>();
builder.Services.AddScoped<IChamadoService, ChamadoService>();

// Registro da Configuração do JWT
builder.Services.Configure<JwtSettingsModel>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<JwtSettingsModel>>().Value);

var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettingsModel>()
                   ?? throw new Exception("JWT Settings not found");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(jwtSettings.Secret)),
            ValidateIssuer = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtSettings.Audience,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero //Evita aceitar tokens expirados com margem de erro
        };
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
//app.Urls.Add("http://*:8080");

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "API SOSurbano rodando com sucesso!");


app.Run();
