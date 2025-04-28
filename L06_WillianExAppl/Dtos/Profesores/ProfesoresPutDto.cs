namespace L06_WillianExAppl.Dtos.Profesores;

public class ProfesoresPutDto
{
    public int? IdUsuario { get; set; }
    
    public string Nombre { get; set; } = null!;

    public string? Especialidad { get; set; }

    public string? Correo { get; set; }
}