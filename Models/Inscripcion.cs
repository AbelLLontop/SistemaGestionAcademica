public class Inscripcion
{
    public int Id { get; set; }
    public Usuario Usuario { get; set; } = null!;
    public int UsuarioId { get; set; }
    public Carrera Carrera { get; set; } = null!;
    public int CarreraId { get; set; }

    public string Estado { get; set; } = null!;


}