using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codenation.Challenge.Models
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.HasKey(o => o.Id);

            builder.Property(t => t.Id)
             .HasColumnName("id");

            builder.Property(t => t.FullName)
                .IsRequired()
              .HasColumnName("full_name")
              .HasMaxLength(100)
              .HasColumnType("varchar(100)");

            builder.Property(t => t.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(t => t.Nickname)
                .IsRequired()
              .HasColumnName("nickname")
              .HasMaxLength(50)
              .HasColumnType("varchar(50)");

            builder.Property(t => t.Password)
                .IsRequired()
              .HasColumnName("password")
              .HasMaxLength(255)
              .HasColumnType("varchar(255)");

            builder.Property(t => t.CreatedAt)
              .IsRequired()
              .HasColumnName("created_at")
              .HasColumnType("timestamp");

        }
    }
}