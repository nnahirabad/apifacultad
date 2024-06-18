using System;
using System.Collections.Generic;

namespace ApiFacultad.Models;

public partial class Docente
{
    public Guid Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public Guid? IdRol { get; set; }

    public virtual ICollection<AlumnosXcurso> AlumnosXcursos { get; set; } = new List<AlumnosXcurso>();

    public virtual ICollection<DocentesXcurso> DocentesXcursos { get; set; } = new List<DocentesXcurso>();

    public virtual Role? IdRolNavigation { get; set; }
}
