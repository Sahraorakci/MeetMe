namespace Domain.Entities;

public class MeetingUser
{
    public int Id { get; set; }
    public int MeetingId { get; set; }
    public int UserId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
    public DateTime? DeletedTime { get; set; }

    public Meeting Meeting { get; set; }
    public AppUser AppUser { get; set; }
    
}