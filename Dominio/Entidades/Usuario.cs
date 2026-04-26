using Employees.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Employees.Dominio.Entidades
{

    public partial class Usuario

    {

        public int NumeroEmpleado { get; set; } 

        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string CorreoElectronico { get; set; } = null!;

        public byte[] Contrasena { get; set; } = null!; 

        public string Rol { get; set; } = null!;

        public byte[]? FotoPerfil { get; set; }
    public int IdEmpresa { get; set; }

    public virtual Usuario IdEmpNavigation { get; set; } = null!;

    public virtual Empresa IdEmpresaNavigation { get; set; } = null!;

    public virtual ICollection<RegistroJornada> RegistrosJornada { get; set; } = new List<RegistroJornada>();

    public virtual ICollection<Vacacion> VacacionesSolicitadas { get; set; } = new List<Vacacion>();

    public virtual ICollection<Vacacion> VacacionesAprobadas { get; set; } = new List<Vacacion>();

} 
    }
