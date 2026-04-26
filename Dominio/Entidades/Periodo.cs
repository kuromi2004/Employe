namespace Employees.Dominio.Entidades
{
    public class Periodo
    {
        public int PeriodoId { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public string Estado { get; set; } = null!; // 'Abierto', 'En proceso', 'Cerrado'


        // Propiedades de navegación

        public virtual ICollection<RegistroJornada> RegistrosJornada { get; set; } = new List<RegistroJornada>();
    }
}
