using System;

namespace AppTickets.Models
{
    public class Ticket
    {
       
        private static int _contadorId = 0;

        
        public int Id { get; set; }
        
        public required string Titulo { get; set; }
        public required string Descripcion { get; set; }
        public PrioridadTicket Prioridad { get; set; }
        public required string ResponsableAsignado { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

         public Ticket()
        {
            
            _contadorId++; 
            this.Id = _contadorId; 
        }

        
        private EstadoTicket _estado;
        public EstadoTicket Estado
        {
            get => _estado;
            set
            {
                if (_estado != value)
                {
                    _estado = value;
                    if (_estado != EstadoTicket.Abierto)
                    {
                        FechaUltimoCambioEstado = DateTime.Now;
                    }
                }
            }
        }

        public DateTime? FechaUltimoCambioEstado { get; set; }
    }

    public enum PrioridadTicket
    {
        Baja,
        Media,
        Alta
    }

    public enum EstadoTicket
    {
        Abierto,
        EnProgreso,
        Cerrado
    }
}

