namespace SosUrbano.Application.DTOs
{
    public record RequestNovoChamadoDTO
    {
        public string UsuarioId { get; set; } = string.Empty;
        public string StatusChamado { get; set; } = string.Empty;
        public DateTime DataChamado { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Status { get; set; }
    }
}
