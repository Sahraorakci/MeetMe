namespace Domain.Entities;

public class AppUser
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Mail { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Password { get; set; }
    public string? ProfilePhotoPath { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
    public DateTime? DeletedTime { get; set; }


    public ICollection<Meeting> Meetings { get; set; }
    public ICollection<MeetingUser> MeetingUsers { get; set; }
    public ICollection<MeetingDocument> MeetingDocuments { get; set; }
}