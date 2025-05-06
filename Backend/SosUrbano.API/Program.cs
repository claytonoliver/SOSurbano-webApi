using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using SosUrbano.Application.Services.Interfaces;
using SosUrbano.Application.Services;
using SosUrbano.Domain.Entities;
using SosUrbano.Infrastructure.Data.Context;
using SosUrbano.Infrastructure.Data;

namespace SOSurbano_webApi
{
    public partial class Program
    {
        protected Program()
        {
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configuração de Serviços
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDb"));

            builder.Services.AddSingleton<IMongoClient>(sp =>
            {
                var settings = builder.Configuration.GetSection("MongoDb").Get<MongoDbSettings>();
                return new MongoClient(settings.ConnectionString);
            });

            builder.Services.AddScoped(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
                return sp.GetRequiredService<IMongoClient>().GetDatabase(settings.DataBaseName);
            });

            builder.Services.AddSingleton<MongoDbContext>();

            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            builder.Services.AddScoped<IVeiculoService, VeiculoService>();
            builder.Services.AddScoped<ITipoDeOcorrenciaService, TipoDeOcorrenciaService>();
            builder.Services.AddScoped<IStatusChamadoService, StatusChamadoService>();
            builder.Services.AddScoped<IChamadoService, ChamadoService>();

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
                        ClockSkew = TimeSpan.Zero
                    };
                });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.MapGet("/", () => "API SOSurbano rodando com sucesso!");
            app.Run();

        }
    }
}