namespace SOSurbano_webApi.ModelViewModel
{
    public class HistoricoOcorrenciaViewModel
    {
        public int IdOcorrencia { get; set; }
        public int TipoOcorrenciaId { get; set; }
        public string TipoOcorrenciaDescricao { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Descricao { get; set; }
    }
}
