using ClassLibrary3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassLibrary4.Map;

public class AssignmentMap : IEntityTypeConfiguration<Assignment>
{
    public void Configure(EntityTypeBuilder<Assignment> builder)
    {
        builder.ToTable("Assignments");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasColumnType("VARCHAR(255)")
            .HasMaxLength(255);

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.Property(x => x.Conclued)
            .IsRequired()
            .HasDefaultValue(false)
            .HasColumnType("TINYINT");

        builder.Property(x => x.DeadLine)
            .HasColumnType("DATETIME");
        
        builder.Property(x => x.ConcluedAt)
            .HasColumnType("DATETIME");


    }
}