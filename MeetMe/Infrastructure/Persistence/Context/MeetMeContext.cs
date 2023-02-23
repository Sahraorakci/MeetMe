using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence.Context;

public class MeetMeContext : DbContext
{
    public MeetMeContext(DbContextOptions<MeetMeContext> options) : base(options)
    {
    }


    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Meeting> Meetings { get; set; }
    public DbSet<MeetingUser> MeetingUsers { get; set; }
    public DbSet<MeetingDocument> MeetingDocuments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AppUserConfiguration());
        modelBuilder.ApplyConfiguration(new MeetingConfiguration());
        modelBuilder.ApplyConfiguration(new MeetingDocumentConfiguration());
        modelBuilder.ApplyConfiguration(new MeetingUserConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}