
using Microsoft.EntityFrameworkCore;

namespace ApiNetCore;

public class CommentServiceImpl(ApplicationDbContext dbContext) : ICommentService
{

    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task Add(Comment comment)
    {
        await _dbContext.Comments.AddAsync(comment);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var commentDelete = await _dbContext.Comments.FirstOrDefaultAsync(c => c.Id == id) ?? throw new BusinessException("Não existe comentário!");
        _dbContext.Comments.Remove(commentDelete);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Comment>> FindAll() => await _dbContext.Comments.ToListAsync();

    public async Task<Comment> FindById(int id)
    {
        var comment = await _dbContext.Comments.FirstOrDefaultAsync(c => c.Id == id) ?? throw new BusinessException("Nenhum Comentário com ID encontrado!");
        return comment;
    }

    public async Task Update(int id, Comment comment)
    {
        var commentUpdate = await _dbContext.Comments.FirstOrDefaultAsync(c => c.Id == id) ?? throw new BusinessException("Não existe dado com esse ID para atualizar.");

        commentUpdate.Title = comment.Title;
        commentUpdate.Content = comment.Content;
        
        _dbContext.Comments.Update(commentUpdate);
        await _dbContext.SaveChangesAsync();
    }
}
