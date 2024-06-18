using System;
using System.Collections.Generic;

namespace ApiFacultad.Models;

public partial class Role
{
    public Guid Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();

    public virtual ICollection<Docente> Docentes { get; set; } = new List<Docente>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
