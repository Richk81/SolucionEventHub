using System;
using System.Collections.Generic;

namespace SistemaEventHub.Entity.Models;

public partial class Comentario
{
    public int IdComentario { get; set; }

    public int IdEvento { get; set; }

    public string? NombreAutor { get; set; }

    public string Texto { get; set; } = null!;

    public DateTime? FechaComentario { get; set; }

    public virtual Evento IdEventoNavigation { get; set; } = null!;
}
