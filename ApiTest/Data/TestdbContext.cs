using System;
using System.Collections.Generic;
using ApiTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Data;

public partial class TestdbContext : DbContext
{
    public TestdbContext()
    {
    }

    public TestdbContext(DbContextOptions<TestdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Item> Items { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Items");

            entity.ToTable("Item");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ItemDescription)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("itemDescription");
            entity.Property(e => e.ItemState).HasColumnName("itemState");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
