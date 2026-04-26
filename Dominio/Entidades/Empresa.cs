using System;
using System.Collections.Generic;

namespace Employees.Dominio.Entidades { 

public partial class Empresa
{public int IdEmpresa { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Factura { get; set; }
}
}