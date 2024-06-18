using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiFacultad.Models;

public partial class FacultadContext : DbContext
{
    public FacultadContext()
    {
    }

    public FacultadContext(DbContextOptions<FacultadContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<AlumnosXcurso> AlumnosXcursos { get; set; }

    public virtual DbSet<Carrera> Carreras { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Docente> Docentes { get; set; }

    public virtual DbSet<DocentesXcurso> DocentesXcursos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Database=facultad;Port=5432;User Id=postgres;Password=abc1234;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Alumno_pkey");

            entity.ToTable("Alumno");

            entity.HasIndex(e => e.IdRol, "fki_IdRol");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("IdRol");
        });

        modelBuilder.Entity<AlumnosXcurso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("AlumnosXCurso_pkey");

            entity.ToTable("AlumnosXCurso");

            entity.HasIndex(e => e.IdCurso, "fki_IdCurs");

            entity.HasIndex(e => e.IdDocente, "fki_IdDocente");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.AlumnosXcursos)
                .HasForeignKey(d => d.IdCurso)
                .HasConstraintName("IdCurs");

            entity.HasOne(d => d.IdDocenteNavigation).WithMany(p => p.AlumnosXcursos)
                .HasForeignKey(d => d.IdDocente)
                .HasConstraintName("IdDocente");
        });

        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Carrera_pkey");

            entity.ToTable("Carrera");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Curso_pkey");

            entity.ToTable("Curso");

            entity.HasIndex(e => e.IdCarrera, "fki_Idcarrera");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdCarreraNavigation).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.IdCarrera)
                .HasConstraintName("Idcarrera");
        });

        modelBuilder.Entity<Docente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Docente_pkey");

            entity.ToTable("Docente");

            entity.HasIndex(e => e.IdRol, "fki_idRol");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Docentes)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("idRol");
        });

        modelBuilder.Entity<DocentesXcurso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("DocentesXcurso_pkey");

            entity.ToTable("DocentesXcurso");

            entity.HasIndex(e => e.IdCurso, "fki_idCurso");

            entity.HasIndex(e => e.IdDocente, "fki_idDocente");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.DocentesXcursos)
                .HasForeignKey(d => d.IdCurso)
                .HasConstraintName("idCurso");

            entity.HasOne(d => d.IdDocenteNavigation).WithMany(p => p.DocentesXcursos)
                .HasForeignKey(d => d.IdDocente)
                .HasConstraintName("idDocente");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Role_pkey");

            entity.ToTable("Role");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Usuario_pkey");

            entity.ToTable("Usuario");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("idRol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
