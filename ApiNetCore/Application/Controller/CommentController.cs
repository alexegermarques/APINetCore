using Microsoft.AspNetCore.Mvc;

namespace ApiNetCore;

[ApiController]
[Route("/v1/api/comments")]
public class CommentController(ICommentService commentService) : ControllerBase
{
    private readonly ICommentService commentService = commentService;
}
