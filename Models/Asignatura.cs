using System.ComponentModel.DataAnnotations.Schema;

public class Asignatura
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string TipoAsignatura { get; set; }
    public int Creditos { get; set; }
    public int HorasTeoricas { get; set; }
    public int HorasPracticas { get; set; }
    [NotMapped]
    public List<AsignaturaCarrera> AsignaturasCarrera { get; } = new List<AsignaturaCarrera>();
    public List<AsignaturaDocente> AsignaturasDocente { get; } = new List<AsignaturaDocente>();
    public List<Evaluacion> Evaluaciones { get; } = new List<Evaluacion>();

    public List<PreRequisitoAsignatura> PreRequisitosAsignatura { get; } = new List<PreRequisitoAsignatura>();

}