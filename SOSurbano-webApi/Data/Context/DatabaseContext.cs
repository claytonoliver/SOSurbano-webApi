using Microsoft.EntityFrameworkCore;
using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<ChamadoModel> Chamados { get; set; }
        public virtual DbSet<GeneroModel> Genero { get; set; }
        public virtual DbSet<HistoricoOcorrenciaModel> HistoricoOcorrencia { get; set; }
        public virtual DbSet<HistoricoServicoStatusModel> HistoricoServico { get; set; }
        public virtual DbSet<RoleModel> Roles { get; set; }
        public virtual DbSet<StatusChamadoModel> StatusChamado { get; set; }
        public virtual DbSet<StatusServicoModel> StatusServico { get; set; }
        public virtual DbSet<TipoDeOcorrenciaModel> TipoOcorrencia { get; set; }
        public virtual DbSet<UsuarioModel> Usuarios { get; set; }
        public virtual DbSet<VeiculoModel> Veiculos { get; set; }
    }
}
