public class Docente
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public string Telefono { get; set; }
    public string Direccion { get; set; }
    public string Ciudad { get; set; }
    public string Pais { get; set; }
    public string Dni { get; set; }
    public string genero { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string Especialidad { get; set; } = null!;
    public Usuario Usuario { get; set; } = null!;
    public int UsuarioId { get; set; }
    public List<AsignaturaDocente> AsignaturasDocente { get; } = new List<AsignaturaDocente>();
}