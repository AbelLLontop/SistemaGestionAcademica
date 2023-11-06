using Microsoft.EntityFrameworkCore;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options):base(options)
    {
    }
    public DbSet<Usuario> Usuarios{get;set;}
    public DbSet<Estudiante> Estudiantes{get;set;}
    public DbSet<Docente> Docentes{get;set;}
    public DbSet<Asignatura> Asignaturas{get;set;}
    public DbSet<Carrera> Carreras{get;set;}
    public DbSet<AsignaturaCarrera> AsignaturasCarrera{get;set;}
    public DbSet<AsignaturaDocente> AsignaturasDocente{get;set;}
    public DbSet<PreRequisitoAsignatura> PreRequisitosAsignatura{get;set;}
    public DbSet<Matricula> Matriculas{get;set;}
    public DbSet<Evaluacion> Evaluaciones{get;set;}
    public DbSet<DetalleEvaluacion> DetallesEvaluacion{get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asignatura>()
        .HasMany(a=>a.PreRequisitosAsignatura)
        .WithOne(p=>p.Asignatura)
        .HasForeignKey(p=>p.AsignaturaId);
    }

}