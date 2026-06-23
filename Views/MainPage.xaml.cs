using AppTickets.ViewModels;

namespace AppTickets.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
            // Conectamos directamente tu pantalla con la lista de tickets
            BindingContext = new TicketsViewModel();
        }
    }
}

