using System.ComponentModel.DataAnnotations;

namespace Employees.Aplicacion.dtos
{
    public class UsuarioCreateDTO
    
    {
        [Required]
        public int NumeroEmpleado { get; set; }

        [Required, StringLength(100)]
        public string Nombres { get; set; } = null!;

        [Required, StringLength(100)]
        public string Apellidos { get; set; } = null!;

        [Required, EmailAddress]
        public string CorreoElectronico { get; set; } = null!;

        [Required, MinLength(8, ErrorMessage = "La contraseña debe tener mínimo 8 caracteres.")]
        public string ContrasenaPlana { get; set; } = null!; //registro

        [Required, RegularExpression("Administrador|Empleado")]
        public string Rol { get; set; } = null!;
    }

    public class UsuarioResponseDTO
    {
    private int _numeroEmpleado;
    public int NumeroEmpleado
    {
        get => _numeroEmpleado;
        set => _numeroEmpleado = value;
    }

        public string NumeroEmpleadoFormateado => _numeroEmpleado.ToString("D5");
    public string NombreCompleto { get; set; } = null!; 
        public string CorreoElectronico { get; set; } = null!;
        public string Rol { get; set; } = null!;
        public byte[]? FotoPerfil { get; set; }
    }


}