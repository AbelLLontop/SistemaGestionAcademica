﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionAcademica.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231105212020_InitialCreate3")]
    partial class InitialCreate3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Asignatura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Creditos")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("HorasPracticas")
                        .HasColumnType("int");

                    b.Property<int>("HorasTeoricas")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TipoAsignatura")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Asignaturas");
                });

            modelBuilder.Entity("AsignaturaCarrera", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AsignaturaId")
                        .HasColumnType("int");

                    b.Property<int>("CarreraId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AsignaturaId");

                    b.HasIndex("CarreraId");

                    b.ToTable("AsignaturasCarrera");
                });

            modelBuilder.Entity("AsignaturaDocente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AsignaturaId")
                        .HasColumnType("int");

                    b.Property<int>("DocenteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AsignaturaId");

                    b.HasIndex("DocenteId");

                    b.ToTable("AsignaturasDocente");
                });

            modelBuilder.Entity("Carrera", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Carreras");
                });

            modelBuilder.Entity("DetalleEvaluacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EvaluacionId")
                        .HasColumnType("int");

                    b.Property<float>("EvaluacionUnidad")
                        .HasColumnType("float");

                    b.Property<float>("EvidenciaAprendizaje")
                        .HasColumnType("float");

                    b.Property<float>("ExamenSustitutorio")
                        .HasColumnType("float");

                    b.Property<float>("Producto")
                        .HasColumnType("float");

                    b.Property<string>("Unidad")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EvaluacionId");

                    b.ToTable("DetallesEvaluacion");
                });

            modelBuilder.Entity("Docente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Docentes");
                });

            modelBuilder.Entity("Estudiante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CarreraId")
                        .HasColumnType("int");

                    b.Property<string>("CodigoEstudiante")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarreraId")
                        .IsUnique();

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Estudiantes");
                });

            modelBuilder.Entity("Evaluacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AsignaturaId")
                        .HasColumnType("int");

                    b.Property<int>("MatriculaId")
                        .HasColumnType("int");

                    b.Property<float>("PromedioFinal")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AsignaturaId");

                    b.HasIndex("MatriculaId")
                        .IsUnique();

                    b.ToTable("Evaluaciones");
                });

            modelBuilder.Entity("Matricula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AsignaturaCarreraId")
                        .HasColumnType("int");

                    b.Property<string>("Curricula")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EstudianteId")
                        .HasColumnType("int");

                    b.Property<string>("Periodo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TipoMatricula")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AsignaturaCarreraId");

                    b.HasIndex("EstudianteId");

                    b.ToTable("Matriculas");
                });

            modelBuilder.Entity("PreRequisitoAsignatura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AsignaturaId")
                        .HasColumnType("int");

                    b.Property<int>("PreRequisitoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AsignaturaId");

                    b.ToTable("PreRequisitosAsignatura");
                });

            modelBuilder.Entity("Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TipoUsuario")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("genero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("AsignaturaCarrera", b =>
                {
                    b.HasOne("Asignatura", "Asignatura")
                        .WithMany()
                        .HasForeignKey("AsignaturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Carrera", "Carrera")
                        .WithMany("AsignaturasCarrera")
                        .HasForeignKey("CarreraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asignatura");

                    b.Navigation("Carrera");
                });

            modelBuilder.Entity("AsignaturaDocente", b =>
                {
                    b.HasOne("Asignatura", "Asignatura")
                        .WithMany("AsignaturasDocente")
                        .HasForeignKey("AsignaturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Docente", "Docente")
                        .WithMany("AsignaturasDocente")
                        .HasForeignKey("DocenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asignatura");

                    b.Navigation("Docente");
                });

            modelBuilder.Entity("DetalleEvaluacion", b =>
                {
                    b.HasOne("Evaluacion", "Evaluacion")
                        .WithMany("DetallesEvaluacion")
                        .HasForeignKey("EvaluacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evaluacion");
                });

            modelBuilder.Entity("Docente", b =>
                {
                    b.HasOne("Usuario", "Usuario")
                        .WithOne("Docente")
                        .HasForeignKey("Docente", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Estudiante", b =>
                {
                    b.HasOne("Carrera", "Carrera")
                        .WithOne("Estudiante")
                        .HasForeignKey("Estudiante", "CarreraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Usuario", "Usuario")
                        .WithOne("Estudiante")
                        .HasForeignKey("Estudiante", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrera");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Evaluacion", b =>
                {
                    b.HasOne("Asignatura", "Asignatura")
                        .WithMany("Evaluaciones")
                        .HasForeignKey("AsignaturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Matricula", "Matricula")
                        .WithOne("Evaluacion")
                        .HasForeignKey("Evaluacion", "MatriculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asignatura");

                    b.Navigation("Matricula");
                });

            modelBuilder.Entity("Matricula", b =>
                {
                    b.HasOne("AsignaturaCarrera", "AsignaturaCarrera")
                        .WithMany("Matriculas")
                        .HasForeignKey("AsignaturaCarreraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Estudiante", "Estudiante")
                        .WithMany("Matriculas")
                        .HasForeignKey("EstudianteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AsignaturaCarrera");

                    b.Navigation("Estudiante");
                });

            modelBuilder.Entity("PreRequisitoAsignatura", b =>
                {
                    b.HasOne("Asignatura", "Asignatura")
                        .WithMany("PreRequisitosAsignatura")
                        .HasForeignKey("AsignaturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asignatura");
                });

            modelBuilder.Entity("Asignatura", b =>
                {
                    b.Navigation("AsignaturasDocente");

                    b.Navigation("Evaluaciones");

                    b.Navigation("PreRequisitosAsignatura");
                });

            modelBuilder.Entity("AsignaturaCarrera", b =>
                {
                    b.Navigation("Matriculas");
                });

            modelBuilder.Entity("Carrera", b =>
                {
                    b.Navigation("AsignaturasCarrera");

                    b.Navigation("Estudiante")
                        .IsRequired();
                });

            modelBuilder.Entity("Docente", b =>
                {
                    b.Navigation("AsignaturasDocente");
                });

            modelBuilder.Entity("Estudiante", b =>
                {
                    b.Navigation("Matriculas");
                });

            modelBuilder.Entity("Evaluacion", b =>
                {
                    b.Navigation("DetallesEvaluacion");
                });

            modelBuilder.Entity("Matricula", b =>
                {
                    b.Navigation("Evaluacion")
                        .IsRequired();
                });

            modelBuilder.Entity("Usuario", b =>
                {
                    b.Navigation("Docente");

                    b.Navigation("Estudiante");
                });
#pragma warning restore 612, 618
        }
    }
}
