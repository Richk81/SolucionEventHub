using System;
using System.Collections.Generic;

namespace SistemaEventHub.Entity.Models;

public partial class Evento
{
    public int IdEvento { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateOnly Fecha { get; set; }

    public string? Ubicacion { get; set; }

    public string? Organizador { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<EventosAsistente> EventosAsistentes { get; set; } = new List<EventosAsistente>();
}
