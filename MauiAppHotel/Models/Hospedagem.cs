namespace MauiAppHotel.Models
{
    public class Hospedagem
    {
        public Quarto QuartoSelecionado { get; set; }
        public int QuantidadeAdultos { get; set; }
        public int QuantidadeCriancas { get; set; }
        public DateTime? DataCheckIn { get; set; }
        public DateTime? DataCheckOut { get; set; }

        // Propriedade calculada para saber o total de dias da estadia
        public int Estadia
        {
            get
            {
                if (DataCheckIn.HasValue && DataCheckOut.HasValue)
                {
                    return DataCheckOut.Value.Subtract(DataCheckIn.Value).Days;
                }
                return 0;
            }
        }

        // Propriedade calculada para o valor total da hospedagem
        public double ValorTotal
        {
            get
            {
                double valor_adultos = QuantidadeAdultos * QuartoSelecionado.ValorDiariaAdulto;
                double valor_criancas = QuantidadeCriancas * QuartoSelecionado.ValorDiariaCrianca;

                double total = (valor_adultos + valor_criancas) * Estadia;
                return total;
            }
        }
    }
}