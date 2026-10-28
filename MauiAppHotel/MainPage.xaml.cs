using MauiAppHotel.Models;

namespace MauiAppHotel
{
    public partial class MainPage : ContentPage
    {
        public List<Quarto> lista_quartos = new List<Quarto>
        {
            new Quarto
            {
                Descricao = "Suíte Luxo",
                ValorDiariaAdulto = 110.0,
                ValorDiariaCrianca = 55.0
            },
            new Quarto
            {
                Descricao = "Suíte Single",
                ValorDiariaAdulto = 80.0,
                ValorDiariaCrianca = 40.0
            },
            new Quarto
            {
                Descricao = "Suíte Super Luxo",
                ValorDiariaAdulto = 150.0,
                ValorDiariaCrianca = 75.0
            }
        };

        public MainPage()
        {
            InitializeComponent();

            // Atribui a lista de quartos ao Picker
            pck_quarto.ItemsSource = lista_quartos;

            // Define as datas mínimas e máximas de forma segura
            dtpck_checkin.MinimumDate = DateTime.Now;
            dtpck_checkin.MaximumDate = DateTime.Now.AddMonths(6);

            dtpck_checkout.MinimumDate = DateTime.Now.AddDays(1);
            dtpck_checkout.MaximumDate = DateTime.Now.AddMonths(7);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Hospedagem h = new Hospedagem
                {
                    QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
                    QuantidadeAdultos = Convert.ToInt32(stp_adultos.Value),
                    QuantidadeCriancas = Convert.ToInt32(stp_criancas.Value),
                    DataCheckIn = dtpck_checkin.Date,
                    DataCheckOut = dtpck_checkout.Date
                };

                // Exibe uma mensagem com o valor total calculado
                await DisplayAlert("Reserva",
                    $"O valor total da estadia é: R$ {h.ValorTotal:F2}\nTotal de dias: {h.Estadia}",
                    "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }
    }
}