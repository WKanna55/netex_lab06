namespace L06_WillianExAppl.Dtos.Evaluaciones;

public class EvaluacionesPostDto
{
    public int? IdEstudiante { get; set; }

    public int? IdCurso { get; set; }

    public decimal? Calificacion { get; set; }

    public DateOnly? Fecha { get; set; }
}