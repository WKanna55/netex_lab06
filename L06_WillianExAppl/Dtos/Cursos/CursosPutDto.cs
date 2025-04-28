namespace L06_WillianExAppl.Dtos.Cursos;

public class CursosPutDto
{
    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int Creditos { get; set; }
}