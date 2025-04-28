namespace L06_WillianExAppl.Dtos.Profesores;

public class ProfesoresPostDto
{
    public int? IdUsuario { get; set; }
    
    public string Nombre { get; set; } = null!;

    public string? Especialidad { get; set; }

    public string? Correo { get; set; }
}