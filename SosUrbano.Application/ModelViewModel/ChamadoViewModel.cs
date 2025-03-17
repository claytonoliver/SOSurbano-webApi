namespace SOSurbano_webApi.ModelViewModel
{
    public class ChamadoViewModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string UsuarioNome { get; set; }
        public int StatusChamadoId { get; set; }
        public string StatusDescricao { get; set; }
        public DateTime DataChamado { get; set; }
        public string Descricao { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
