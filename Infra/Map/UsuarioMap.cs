using ClassLibrary3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassLibrary4.Map;

public class UsuarioMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Usuario");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnType("VARCHAR(30)")
            .HasMaxLength(30);

        builder.Property(x => x.Password)
            .IsRequired()
            .HasColumnType("VARCHAR(20)")
            .HasMaxLength(20);

        builder.HasMany(u => u.AssignmentsLists)
            .WithOne(u => u.User)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.Assignments)
            .WithOne(u => u.User)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}