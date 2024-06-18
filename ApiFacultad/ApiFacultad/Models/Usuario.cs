using System;
using System.Collections.Generic;

namespace ApiFacultad.Models;

public partial class Usuario
{
    public Guid Id { get; set; }

    public string? Email { get; set; }

    public string? Contrasena { get; set; }

    public Guid? IdRol { get; set; }

    public virtual Role? IdRolNavigation { get; set; }
}
