namespace L06_WillianExAppl.Dtos.Cursos;

public class CursosGetDto
{
    public int IdCurso { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int Creditos { get; set; }
}