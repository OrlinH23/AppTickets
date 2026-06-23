using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AppTickets.Models;
using AppTickets.Services;

namespace AppTickets.ViewModels
{
    public class TicketsViewModel : INotifyPropertyChanged
    {
        private readonly TicketService _ticketService;

        public ObservableCollection<Ticket> ListaTickets => _ticketService.Tickets;

        public ICommand AvanzarEstadoCommand { get; }

        public TicketsViewModel()
        {
            _ticketService = new TicketService();
            AvanzarEstadoCommand = new Command<Ticket>(AvanzarEstado);
        }

        private void AvanzarEstado(Ticket ticket)
        {
            if (ticket == null) return;

            _ticketService.AvanzarCicloVida(ticket);

            var index = ListaTickets.IndexOf(ticket);
            if (index != -1)
            {
                ListaTickets[index] = ticket;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
