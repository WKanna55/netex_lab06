using System;
using System.Collections.Generic;

namespace L06_WillianExAppl.Entities;

public partial class Asistencias
{
    public int IdAsistencia { get; set; }

    public int? IdEstudiante { get; set; }

    public int? IdCurso { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? Estado { get; set; }

    public virtual Cursos? IdCursoNavigation { get; set; }

    public virtual Estudiantes? IdEstudianteNavigation { get; set; }
}
