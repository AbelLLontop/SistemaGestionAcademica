public class Matricula
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public int AsignaturaCarreraId { get; set; }
    public Usuario usuario { get; set; }=null!;
    public AsignaturaCarrera AsignaturaCarrera { get; set; }=null!;
    public string TipoMatricula { get; set; }
    public string Curricula { get; set; }
    public string Periodo { get; set; }
    public Evaluacion Evaluacion { get; set; }
}