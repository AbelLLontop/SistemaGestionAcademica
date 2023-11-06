public class DetalleEvaluacion
{
    public int Id { get; set; }
    public int EvaluacionId { get; set; }
    public Evaluacion Evaluacion { get; set; }=null!;
    public string Unidad { get; set; }
    public float EvaluacionUnidad { get; set; }
    public float ExamenSustitutorio { get; set; }
    public float EvidenciaAprendizaje { get; set; }
    public float Producto { get; set; }
    
}