using System;
using System.Collections.Generic;

namespace ApiFacultad.Models;

public partial class Curso
{
    public Guid Id { get; set; }

    public string? Nombre { get; set; }

    public DateOnly? FechaCreacion { get; set; }

    public string? Horarios { get; set; }

    public Guid? IdCarrera { get; set; }

    public virtual ICollection<AlumnosXcurso> AlumnosXcursos { get; set; } = new List<AlumnosXcurso>();

    public virtual ICollection<DocentesXcurso> DocentesXcursos { get; set; } = new List<DocentesXcurso>();

    public virtual Carrera? IdCarreraNavigation { get; set; }
}
