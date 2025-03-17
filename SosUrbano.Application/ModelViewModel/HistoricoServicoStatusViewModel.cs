namespace SOSurbano_webApi.ModelViewModel
{
    public class HistoricoServicoStatusViewModel
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public string VeiculoDescricao { get; set; }
        public int ChamadoId { get; set; }
        public string ChamadoDescricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int StatusServicoId { get; set; }
        public string StatusServicoDescricao { get; set; }
    }
}