using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codenation.Challenge.Models {
  public class SubmissionConfiguration : IEntityTypeConfiguration<Submission> {
    public void Configure (EntityTypeBuilder<Submission> builder) {
      builder.ToTable ("submission");
      builder.HasKey (t => new { t.ChallengeId, t.UserId });

      builder.HasOne (s => s.User)
        .WithMany (c => c.Submissions)
        .HasForeignKey (s => s.UserId);

      builder.HasOne (s => s.Challenge)
        .WithMany (c => c.Submissions)
        .HasForeignKey (s => s.ChallengeId);

      builder.Property (t => t.UserId)
        .HasColumnName ("user_id")
        .HasColumnType ("int");

      builder.Property (t => t.ChallengeId)
        .HasColumnName ("challenge_id")
        .HasColumnType ("int");

      builder.Property (t => t.Score)
        .IsRequired ()
        .HasColumnName ("score")
        .HasColumnType ("float(9,2)");

      builder.Property (t => t.CreatedAt)
        .IsRequired ()
        .HasColumnName ("created_at")
        .HasColumnType ("timestamp");

    }
  }
}