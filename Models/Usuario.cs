using System.Text.Json.Serialization;

public class Usuario
{
    public int Id { get; set; }
    [JsonIgnore]
    public string Password { get; set; }
    public string Email { get; set; }
    public string TipoUsuario { get; set; }
    [JsonIgnore]
    public Docente? Docente { get; set; }
    [JsonIgnore]
    public Estudiante? Estudiante { get; set; }

}
