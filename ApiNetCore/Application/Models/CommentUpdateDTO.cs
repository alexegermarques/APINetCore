namespace ApiNetCore;

public record class CommentUpdateDTO
{
    public string? Title { get; set; }
    public string? Content { get; set; }
}
