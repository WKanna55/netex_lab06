using System;
using System.Collections.Generic;

namespace L06_WillianExAppl.Entities;

public partial class Usuarios
{
    public int IdUsuario { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public virtual Estudiantes? Estudiantes { get; set; }

    public virtual Profesores? Profesores { get; set; }
}
