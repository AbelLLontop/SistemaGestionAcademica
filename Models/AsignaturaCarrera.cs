public class AsignaturaCarrera
{
    public int Id { get; set; }
    public int CarreraId { get; set; }
    public int AsignaturaId { get; set; }
    public Carrera Carrera { get; set; }=null;
    public Asignatura Asignatura { get; set; }=null;
    public List<Matricula> Matriculas { get; } = new List<Matricula>();
}