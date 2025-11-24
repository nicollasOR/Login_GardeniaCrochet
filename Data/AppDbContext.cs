using System;
using System.Collections.Generic;
using Login.Models;
using Microsoft.EntityFrameworkCore;

namespace Login.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente2> Cliente2 { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente2>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente2__E005FBFF230EAF6D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
