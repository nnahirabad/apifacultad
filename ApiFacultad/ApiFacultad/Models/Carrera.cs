using System;
using System.Collections.Generic;

namespace ApiFacultad.Models;

public partial class Carrera
{
    public Guid Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
