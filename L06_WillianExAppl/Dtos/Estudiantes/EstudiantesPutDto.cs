namespace L06_WillianExAppl.Dtos.Estudiantes;

public class EstudiantesPutDto
{
    public int? IdUsuario { get; set; }
    
    public string Nombre { get; set; } = null!;

    public int Edad { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }
}