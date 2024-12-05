using Microsoft.EntityFrameworkCore;
using SOSurbano_webApi.Data.Context;
using SOSurbano_webApi.Services.Interfaces;
using SOSurbano_webApi.Services;
using SOSurbano_webApi.Data.Repository.Interfaces;
using SOSurbano_webApi.Data.Repository;
using Fiap.Api.Alunos.Services;
using Fiap.Web.Alunos.Services;
using SOSurbano_webApi.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region INICIALIZANDO O BANCO DE DADOS
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DatabaseContext>(
    opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)
);
#endregion
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IVeiculoRepository, VeiculoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ITipoDeOcorrenciaRepository, TipoDeOcorrenciaRepository>();
builder.Services.AddScoped<IStatusServiceRepository, StatusServicoRepository>();
builder.Services.AddScoped<IStatusChamadoRepository, StatusChamadoRepository>();
builder.Services.AddScoped<IHistoricoServicoStatusRepository, HistoricoServicoStatusRepository>();
builder.Services.AddScoped<IHistoricoOcorrenciaRepository, HistoricoOcorrenciaRepository>();
builder.Services.AddScoped<IChamadoRepository, ChamadoRepository>();
//builder.Services.AddScoped<IAuthService, AuthService>();






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
