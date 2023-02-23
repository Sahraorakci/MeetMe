namespace Application.Dto;

public class CheckUserResponseDto
{
    public int Id { get; set; }
    public string? Mail { get; set; }
    public string? Password { get; set; }
    public bool IsExist { get; set; }

}