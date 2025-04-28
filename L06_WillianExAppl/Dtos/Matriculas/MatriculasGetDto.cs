namespace L06_WillianExAppl.Dtos.Matriculas;

public class MatriculasGetDto
{
    public int IdMatricula { get; set; }

    public int? IdEstudiante { get; set; }

    public int? IdCurso { get; set; }

    public string? Semestre { get; set; }
}