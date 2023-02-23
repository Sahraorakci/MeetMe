using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class MeetingConfiguration : IEntityTypeConfiguration<Meeting>
{
    public void Configure(EntityTypeBuilder<Meeting> builder)
    {
        builder.HasOne<AppUser>(x => x.AppUser)
            .WithMany(x => x.Meetings)
            .HasForeignKey(x => x.CreatedUserId)
            .OnDelete(DeleteBehavior.NoAction).IsRequired();
    }
}