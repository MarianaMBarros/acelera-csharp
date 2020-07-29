using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codenation.Challenge.Models
{
    public class AccelerationConfiguration : IEntityTypeConfiguration<Acceleration>
    {
        public void Configure(EntityTypeBuilder<Acceleration> builder)
        {
            builder.ToTable("acceleration");
            builder.HasOne(s => s.Challenge)
              .WithMany(c => c.Accelerations)
              .HasForeignKey(s => s.ChallengeId);

            builder.HasKey(o => o.Id);

            builder.Property(t => t.Id)
             .HasColumnName("id");

            builder.Property(t => t.Name)
        .HasColumnName("name")
        .IsRequired()
        .HasMaxLength(100)
        .HasColumnType("varchar(100)");

            builder.Property(t => t.Slug)
              .HasColumnName("slug")
              .IsRequired()
               .HasMaxLength(50)
              .HasColumnType("varchar(50)");

            builder.Property(t => t.ChallengeId)
              .HasColumnName("challenge_id")
              .HasColumnType("int");

            builder.Property(t => t.CreatedAt)
              .IsRequired()
              .HasColumnName("created_at")
              .HasColumnType("timestamp");

        }
    }
}