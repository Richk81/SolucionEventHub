using System;
using System.Collections.Generic;

namespace SistemaEventHub.Entity.Models;

public partial class EventosAsistente
{
    public int IdEvento { get; set; }

    public int IdAsistente { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Asistente IdAsistenteNavigation { get; set; } = null!;

    public virtual Evento IdEventoNavigation { get; set; } = null!;
}
