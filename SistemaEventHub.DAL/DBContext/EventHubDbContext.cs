using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SistemaEventHub.Entity.Models;

namespace SistemaEventHub.DAL.DBContext;

public partial class EventHubDbContext : DbContext
{
    public EventHubDbContext()
    {
    }

    public EventHubDbContext(DbContextOptions<EventHubDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asistente> Asistentes { get; set; }

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<EventosAsistente> EventosAsistentes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asistente>(entity =>
        {
            entity.HasKey(e => e.IdAsistente).HasName("PK__Asistent__E8FC40DA27B4DC54");

            entity.HasIndex(e => e.Email, "UQ__Asistent__A9D105348F2F24CD").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.IdComentario).HasName("PK__Comentar__DDBEFBF91E35E945");

            entity.Property(e => e.FechaComentario)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreAutor).HasMaxLength(100);
            entity.Property(e => e.Texto).HasMaxLength(500);

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdEvento)
                .HasConstraintName("FK__Comentari__IdEve__440B1D61");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.IdEvento).HasName("PK__Eventos__034EFC04ADBB9B94");

            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Organizador).HasMaxLength(100);
            entity.Property(e => e.Ubicacion).HasMaxLength(100);
        });

        modelBuilder.Entity<EventosAsistente>(entity =>
        {
            entity.HasKey(e => new { e.IdEvento, e.IdAsistente }).HasName("PK__EventosA__BDC1380951EF771E");

            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdAsistenteNavigation).WithMany(p => p.EventosAsistentes)
                .HasForeignKey(d => d.IdAsistente)
                .HasConstraintName("FK__EventosAs__IdAsi__403A8C7D");

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.EventosAsistentes)
                .HasForeignKey(d => d.IdEvento)
                .HasConstraintName("FK__EventosAs__IdEve__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
