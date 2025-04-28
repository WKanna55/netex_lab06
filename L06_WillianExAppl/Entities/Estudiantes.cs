using System;
using System.Collections.Generic;

namespace L06_WillianExAppl.Entities;

public partial class Estudiantes
{
    public int IdEstudiante { get; set; }

    public int? IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public int Edad { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public virtual ICollection<Asistencias> Asistencias { get; set; } = new List<Asistencias>();

    public virtual ICollection<Evaluaciones> Evaluaciones { get; set; } = new List<Evaluaciones>();

    public virtual Usuarios? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Matriculas> Matriculas { get; set; } = new List<Matriculas>();
}
