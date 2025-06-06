﻿using System;
using System.Collections.Generic;

namespace L06_WillianExAppl.Entities;

public partial class Matriculas
{
    public int IdMatricula { get; set; }

    public int? IdEstudiante { get; set; }

    public int? IdCurso { get; set; }

    public string? Semestre { get; set; }

    public virtual Cursos? IdCursoNavigation { get; set; }

    public virtual Estudiantes? IdEstudianteNavigation { get; set; }
}
