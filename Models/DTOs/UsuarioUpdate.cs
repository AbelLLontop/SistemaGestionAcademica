public class UsuarioUpdate
{
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public string Telefono { get; set; }
    public string Direccion { get; set; }
    public string Dni { get; set; }
    public string Genero { get; set; }
    public string GradoEstudio { get; set; } = null!;
    public DateTime FechaNacimiento { get; set; }
    public string Email { get; set; }
    public string TipoUsuario { get; set; }
}
