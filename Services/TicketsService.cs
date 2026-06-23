using System;
using System.Collections.ObjectModel;
using AppTickets.Models;

namespace AppTickets.Services
{
    public class TicketService
    {
        public ObservableCollection<Ticket> Tickets { get; set; } = new ObservableCollection<Ticket>();

        public TicketService()
        {
            Tickets.Add(new Ticket { Titulo = "Error en Base de Datos", Descripcion = "Fallo de conexión al cargar catastro", Prioridad = PrioridadTicket.Alta, Estado = EstadoTicket.Abierto });
            Tickets.Add(new Ticket { Titulo = "Actualizar Pantalla", Descripcion = "Cambiar los estilos visuales en Android", Prioridad = PrioridadTicket.Media, Estado = EstadoTicket.EnProceso });
        }

        public void AvanzarCicloVida(Ticket ticket)
        {
            if (ticket == null) return;

            ticket.Estado = ticket.Estado switch
            {
                EstadoTicket.Abierto => EstadoTicket.EnProceso,
                EstadoTicket.EnProceso => EstadoTicket.Resuelto,
                EstadoTicket.Resuelto => EstadoTicket.Cerrado,
                _ => ticket.Estado
            };

            if (ticket.Estado != EstadoTicket.Abierto)
            {
                ticket.FechaUltimoCambioEstado = DateTime.Now;
            }
        }
    }
}

