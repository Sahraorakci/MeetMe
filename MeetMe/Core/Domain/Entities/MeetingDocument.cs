namespace Domain.Entities;

public class MeetingDocument
{
    public int Id { get; set; }
    public int MeetingId { get; set; }
    public int CreatedUserId { get; set; }
    public string? DocumentPath { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
    public DateTime? DeletedTime { get; set; }

    public Meeting Meeting { get; set; }
    public AppUser AppUser { get; set; }
 
    
}