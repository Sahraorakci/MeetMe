namespace Application.Dto;

public class MeetingListDto
{
    public int Id { get; set; }
    public int CreatedUserId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string? Description { get; set; }
}