using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codenation.Challenge.Models
{
    public class ChallengeConfiguration : IEntityTypeConfiguration<Challenge>
    {
        public void Configure(EntityTypeBuilder<Challenge> builder)
        {
            builder.ToTable("challenge");
            builder.HasKey(o => o.Id);

            builder.Property(t => t.Id)
             .HasColumnName("id");

            builder.Property(t => t.Name)
              .IsRequired()
              .HasColumnName("name")
              .HasMaxLength(100)
              .HasColumnType("varchar(100)");

            builder.Property(t => t.Slug)
              .IsRequired()
              .HasColumnName("slug")
              .HasMaxLength(50)
              .HasColumnType("varchar(50)");

            builder.Property(t => t.CreatedAt)
              .IsRequired()
              .HasColumnName("created_at")
              .HasColumnType("timestamp");

        }
    }
}