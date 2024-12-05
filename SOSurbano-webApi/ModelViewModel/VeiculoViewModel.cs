namespace SOSurbano_webApi.ModelViewModel
{
    public class VeiculoViewModel
    {
        public int Id { get; set; }
        public string? Placa { get; set; }
        public int StatusServicoId { get; set; }
        public string StatusServicoNome { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
