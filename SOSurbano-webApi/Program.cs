using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SosUrbano.Domain.Entities;
using SosUrbano.Infraestructure.Data;
using SOSurbano_webApi.Data.Context;
using SOSurbano_webApi.Services;
using SOSurbano_webApi.Services.Interfaces;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




//builder.Services.AddScoped<IRoleRepository, RoleRepository>();
//builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
//builder.Services.AddScoped<IVeiculoRepository, VeiculoRepository>();
//builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
//builder.Services.AddScoped<ITipoDeOcorrenciaRepository, TipoDeOcorrenciaRepository>();
//builder.Services.AddScoped<IStatusServiceRepository, StatusServicoRepository>();
//builder.Services.AddScoped<IStatusChamadoRepository, StatusChamadoRepository>();
//builder.Services.AddScoped<IHistoricoServicoStatusRepository, HistoricoServicoStatusRepository>();
//builder.Services.AddScoped<IHistoricoOcorrenciaRepository, HistoricoOcorrenciaRepository>();
//builder.Services.AddScoped<IChamadoRepository, ChamadoRepository>();
//builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.Configure<JwtSettingsModel>(builder.Configuration.GetSection("JwtSettings"));
#region DbConnection
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDb"));
builder.Services.AddSingleton<MongoDbContext>();
#endregion




builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IGeneroService, GeneroService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IVeiculoService, VeiculoService>();
builder.Services.AddScoped<ITipoDeOcorrenciaService, TipoDeOcorrenciaService>();
builder.Services.AddScoped<IStatusServicoService, StatusServicoService>();
builder.Services.AddScoped<IStatusChamadoService, StatusChamadoService>();
builder.Services.AddScoped<IHistoricoServicoStatusService, HistoricoServicoStatusService>();
builder.Services.AddScoped<IHistoricoOcorrenciaService, HistoricoOcorrenciaService>();
builder.Services.AddScoped<IChamadoService, ChamadoService>();


// Configuração do JWT

var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettingsModel>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
            ValidateIssuer = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtSettings.Audience,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });



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
