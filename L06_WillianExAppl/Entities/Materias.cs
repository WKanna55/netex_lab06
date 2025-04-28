using System;
using System.Collections.Generic;

namespace L06_WillianExAppl.Entities;

public partial class Materias
{
    public int IdMateria { get; set; }

    public int? IdCurso { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual Cursos? IdCursoNavigation { get; set; }
}
