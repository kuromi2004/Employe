using System.ComponentModel.DataAnnotations;

public class EmpresaDto
{
    [Required]
public int IDEmpresa {get; set;}
[Required] public string Nombre {get; set; }

public bool  Factura {get; set; }
}