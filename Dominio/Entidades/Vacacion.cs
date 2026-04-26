using Employees.Dominio.Entidades;

namespace Employees.Dominio.Entidades
{
    public class Vacacion
    {
        public int VacacionId { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public string EstadoAprobacion { get; set; } = "Pendiente"; // 'Pendiente', 'Aprobada', 'Rechazada'

        public int SolicitanteId { get; set; }

        public int? AprobadorId { get; set; } // nullable


        // Propiedades de navegación

        public virtual Usuario Solicitante { get; set; } = null!;

        public virtual Usuario? Aprobador { get; set; }
    }
}
