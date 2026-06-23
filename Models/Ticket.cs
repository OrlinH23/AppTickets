using System;

namespace AppTickets.Models
{
    public enum PrioridadTicket { Alta, Media, Baja }
    public enum EstadoTicket { Abierto, EnProceso, Resuelto, Cerrado }

    public class Ticket
    {
        private static int _contadorId = 0;

        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public PrioridadTicket Prioridad { get; set; }
        public EstadoTicket Estado { get; set; }
        public string? ResponsableAsignado { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaUltimoCambioEstado { get; set; }

        public Ticket()
        {
            _contadorId++;
            Id = _contadorId;
        }
    }
}