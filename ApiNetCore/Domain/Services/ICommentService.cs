namespace ApiNetCore;

public interface ICommentService
{
    Task Add(Comment comment);
    Task<List<Comment>> FindAll();
    Task<Comment> FindById(int id);
}
