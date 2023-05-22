using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ContatosQueEuOdeio.Models;

public partial class ContatosContext : DbContext
{
    public ContatosContext(DbContextOptions<ContatosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Contato> Contatos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contato>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Contatos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contato_Cliente");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
