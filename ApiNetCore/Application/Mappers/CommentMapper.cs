namespace ApiNetCore;

public class CommentMapper
{
    private CommentMapper()
    {
    }

    public static List<CommentDTO> ToListCommentDTO(List<Comment> comments)
    {
        List<CommentDTO> commentDTOs = comments.Select(comment => new CommentDTO
        {
            Id = comment.Id,
            Title = comment.Title,
            Content = comment.Content,
            CreateOn = comment.CreateOn,
            StockId = comment.StockId
        }).ToList();
        return commentDTOs;
    }

    public static CommentDTO ToCommentDTO(Comment comment)
    {
        return new CommentDTO
        {
            Id = comment.Id,
            Title = comment.Title,
            Content = comment.Content,
            CreateOn = comment.CreateOn,
            StockId = comment.StockId
        };
    }

    public static Comment ToCommentEntity(CommentDTO commentDTO)
    {
        return new Comment
        {
            Id = commentDTO.Id,
            Title = commentDTO.Title,
            Content = commentDTO.Content,
            CreateOn = commentDTO.CreateOn,
            StockId = commentDTO.StockId
        };
    }

    public static Comment ToCommentUpdateEntity(CommentUpdateDTO commentUpdate)
    {
        return new Comment
        {
            Title = commentUpdate.Title,
            Content = commentUpdate.Content
        };
    }
}
