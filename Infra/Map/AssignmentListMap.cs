using ClassLibrary3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassLibrary4.Map;

public class AssignmentListMap : IEntityTypeConfiguration<AssignmentList>
{
    public void Configure(EntityTypeBuilder<AssignmentList> builder)
    {
        builder.ToTable("AssignmentList");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnType("VARCHAR(255)")
            .HasMaxLength(255);

        builder.Property(x => x.UserId)
            .IsRequired();
    }
}