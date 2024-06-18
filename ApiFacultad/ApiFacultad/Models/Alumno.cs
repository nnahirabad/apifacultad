using System;
using System.Collections.Generic;

namespace ApiFacultad.Models;

public partial class Alumno
{
    public Guid Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public Guid? IdRol { get; set; }

    public virtual Role? IdRolNavigation { get; set; }
}
