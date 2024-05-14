using System.ComponentModel.DataAnnotations;

namespace ApiNetCore;

public record class CommentDTO
{
    public required int Id { get; init; }
    
    [MinLength(5, ErrorMessage = "O título precisa de no minímo 5 caracteres")]
    [MaxLength(100, ErrorMessage = "Limite de caracteres excedido")]
    public required string? Title { get; init; }
    public required string? Content { get; init; }
    public DateTime CreateOn { get; init; } = DateTime.Now;
    public required int StockId { get; init; }
}
