using System;
using System.Collections.Generic;

namespace L06_WillianExAppl.Entities;

public partial class Profesores
{
    public int IdProfesor { get; set; }

    public int? IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Especialidad { get; set; }

    public string? Correo { get; set; }

    public virtual Usuarios? IdUsuarioNavigation { get; set; }
}
