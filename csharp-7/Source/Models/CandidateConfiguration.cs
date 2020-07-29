using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codenation.Challenge.Models {
  public class CandidateConfiguration : IEntityTypeConfiguration<Candidate> {
    public void Configure (EntityTypeBuilder<Candidate> builder) {
      builder.ToTable ("candidate");
      builder.HasKey (t => new { t.UserId, t.AccelerationId, t.CompanyId });

      builder.HasOne (s => s.User)
        .WithMany (c => c.Candidates)
        .HasForeignKey (s => s.UserId);

      builder.HasOne (s => s.Acceleration)
        .WithMany (c => c.Candidates)
        .HasForeignKey (s => s.AccelerationId);

      builder.HasOne (s => s.Company)
        .WithMany (c => c.Candidates)
        .HasForeignKey (s => s.CompanyId);

      builder.Property (t => t.UserId)
        .HasColumnName ("user_id")
        .HasColumnType ("int");

      builder.Property (t => t.AccelerationId)
        .HasColumnName ("acceleration_id")
        .HasColumnType ("int");

      builder.Property (t => t.CompanyId)
        .HasColumnName ("company_id")
        .HasColumnType ("int");

      builder.Property (t => t.Status)
        .HasColumnName ("status")
        .IsRequired ()
        .HasColumnType ("int");

      builder.Property (t => t.CreatedAt)
        .IsRequired ()
        .HasColumnName ("created_at")
        .IsRequired ()
        .HasColumnType ("timestamp");

    }
  }
}