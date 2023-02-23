namespace Domain.Entities;

public class Meeting
{
    public int Id { get; set; }
    public int CreatedUserId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string? Description { get; set; }
    public bool IsPublic { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
    public DateTime? DeletedTime { get; set; }

    public AppUser AppUser { get; set; }

    public ICollection<MeetingDocument> MeetingDocuments { get; set; }
    public ICollection<MeetingUser> MeetingUsers { get; set; }
   
}