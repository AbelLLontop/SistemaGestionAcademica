using System.Text.Json.Serialization;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public string Telefono { get; set; }
    public string Direccion { get; set; }
    public string Dni { get; set; }
    public string Genero { get; set; }
    public string GradoEstudio { get; set; } = null!;
    public DateTime FechaNacimiento { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string TipoUsuario { get; set; }


    [JsonIgnore]
    public List<AsignaturaDocente> AsignaturasDocente { get; } = new List<AsignaturaDocente>();
    [JsonIgnore]
    public List<Matricula> Matriculas { get; } = new List<Matricula>();

    [JsonIgnore]
    public List<Inscripcion> Inscripciones { get; } = new List<Inscripcion>();

}
