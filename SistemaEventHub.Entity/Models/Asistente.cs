using System;
using System.Collections.Generic;

namespace SistemaEventHub.Entity.Models;

public partial class Asistente
{
    public int IdAsistente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefono { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<EventosAsistente> EventosAsistentes { get; set; } = new List<EventosAsistente>();
}
