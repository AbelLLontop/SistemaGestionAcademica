public class AsignaturaDocente
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }=null!;
    public int AsignaturaId { get; set; }
    public Asignatura Asignatura { get; set; }=null!;
    
}