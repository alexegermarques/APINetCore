namespace ApiNetCore;

public record class CommentDTO
{
    public required int Id { get; init; }
    public required string? Title { get; init; }
    public required string? Content { get; init; }
    public DateTime CreateOn { get; init; } = DateTime.Now;
    public required int StockId { get; init; }
}
