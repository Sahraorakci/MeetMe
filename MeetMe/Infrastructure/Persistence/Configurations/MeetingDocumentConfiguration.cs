using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class MeetingDocumentConfiguration : IEntityTypeConfiguration<MeetingDocument>
{
    public void Configure(EntityTypeBuilder<MeetingDocument> builder)
    {
        builder.HasOne<Meeting>(x=>x.Meeting)
            .WithMany(x => x.MeetingDocuments)
            .HasForeignKey(x => x.MeetingId)
            .OnDelete(DeleteBehavior.NoAction).IsRequired();
        
        builder.HasOne<AppUser>(x=>x.AppUser)
            .WithMany(x => x.MeetingDocuments)
            .HasForeignKey(x => x.CreatedUserId)
            .OnDelete(DeleteBehavior.NoAction).IsRequired();
    }
}