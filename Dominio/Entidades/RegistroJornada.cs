using Employees.Dominio.Entidades;

namespace Employees.Dominio.Entidades
{
    public class RegistroJornada
    {


        public int RegistroId { get; set; }

        public DateTime Fecha { get; set; }

        public decimal HorasTrabajadas { get; set; } // Decimal(4,2)

        public string Tipo { get; set; } = null!; // 'Cobrable', 'No cobrable'

        public string Estado { get; set; } = null!; // 'Completo', 'Incompleto'

        public int NumeroEmpleado { get; set; }

        public int PeriodoId { get; set; }




        public virtual Usuario Usuario { get; set; } = null!;

        public virtual Periodo Periodo { get; set; } = null!;

    }
}
