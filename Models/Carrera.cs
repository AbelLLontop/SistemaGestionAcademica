using System.ComponentModel.DataAnnotations.Schema;

public class Carrera
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public Estudiante Estudiante { get; set; }
    public List<AsignaturaCarrera> AsignaturasCarrera { get; } = new List<AsignaturaCarrera>();
}