using System.ComponentModel.DataAnnotations;

namespace ApiNetCore;

public record class CommentUpdateDTO
{
    [MinLength(5, ErrorMessage = "O título precisa de no minímo 5 caracteres")]
    [MaxLength(100, ErrorMessage = "Limite de caracteres excedido")]
    public string? Title { get; set; }
    public string? Content { get; set; }
}
