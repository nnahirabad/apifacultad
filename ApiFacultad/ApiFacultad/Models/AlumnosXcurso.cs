using System;
using System.Collections.Generic;

namespace ApiFacultad.Models;

public partial class AlumnosXcurso
{
    public Guid Id { get; set; }

    public DateOnly? FechaAlta { get; set; }

    public Guid? IdCurso { get; set; }

    public Guid? IdDocente { get; set; }

    public virtual Curso? IdCursoNavigation { get; set; }

    public virtual Docente? IdDocenteNavigation { get; set; }
}
