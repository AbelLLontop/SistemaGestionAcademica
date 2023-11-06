public class PreRequisitoAsignatura
{
    public int Id { get; set; }
    public int AsignaturaId { get; set; }
    public Asignatura Asignatura { get; set; }=null!;
    public int PreRequisitoId { get; set; }
}