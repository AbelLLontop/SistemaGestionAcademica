using System.ComponentModel.DataAnnotations.Schema;

public class Evaluacion
{
    public int Id { get; set; }

    public int AsignaturaId { get; set; }
    public Asignatura Asignatura { get; set; } = null!;
    public float PromedioFinal { get; set; }
    public List<DetalleEvaluacion> DetallesEvaluacion { get; } = new List<DetalleEvaluacion>();
    public int MatriculaId { get; set; }
    public Matricula Matricula { get; set; } = null!;
}