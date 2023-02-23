using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class MeetingUserConfiguration:IEntityTypeConfiguration<MeetingUser>
{
    public void Configure(EntityTypeBuilder<MeetingUser> builder)
    {

        builder.HasOne<Meeting>(x=>x.Meeting)
            .WithMany(x => x.MeetingUsers)
            .HasForeignKey(x => x.MeetingId)
            .OnDelete(DeleteBehavior.NoAction).IsRequired();
        
        builder.HasOne<AppUser>(x=>x.AppUser)
            .WithMany(x => x.MeetingUsers)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction).IsRequired();
    }
}