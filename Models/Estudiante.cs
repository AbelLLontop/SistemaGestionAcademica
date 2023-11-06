public class Estudiante
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
    public string CodigoEstudiante { get; set; }
    public Usuario Usuario { get; set; } = null!;

    public int UsuarioId { get; set; }
    public Carrera Carrera { get; set; } = null!;
    public int CarreraId { get; set; }
    public List<Matricula> Matriculas { get; } = new List<Matricula>();

}