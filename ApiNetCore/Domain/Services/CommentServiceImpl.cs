
namespace ApiNetCore;

public class CommentServiceImpl(ApplicationDbContext dbContext) : ICommentService
{

    private readonly ApplicationDbContext _dbContext = dbContext;

    public Task Add(Comment comment)
    {
        throw new NotImplementedException();
    }

    public Task<List<Comment>> FindAll()
    {
        throw new NotImplementedException();
    }

    public Task<Comment> FindById(int id)
    {
        throw new NotImplementedException();
    }
}
