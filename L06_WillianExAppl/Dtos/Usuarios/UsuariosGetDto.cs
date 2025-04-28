namespace L06_WillianExAppl.Dtos.Usuarios;

public class UsuariosGetDto
{
    public int IdUsuario { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Rol { get; set; } = null!;
}