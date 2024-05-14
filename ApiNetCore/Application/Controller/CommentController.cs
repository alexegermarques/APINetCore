using Microsoft.AspNetCore.Mvc;

namespace ApiNetCore;

[ApiController]
[Route("/v1/api/comments")]
public class CommentController(ICommentService commentService, IStockService stockService) : ControllerBase
{
    private readonly ICommentService _commentService = commentService;
    private readonly IStockService _stockService = stockService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var comments = await _commentService.FindAll();
        return Ok(CommentMapper.ToListCommentDTO(comments));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var comment = await _commentService.FindById(id);

        if (comment is null)
        {
            return NotFound();
        }

        return Ok(CommentMapper.ToCommentDTO(comment));
    }

    [HttpPost]
    public async Task<IActionResult> CreateComment([FromBody] CommentDTO commentDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        if (!await _stockService.StockExists(commentDTO.StockId))
        {
            return BadRequest();
        }
        
        await _commentService.Add(CommentMapper.ToCommentEntity(commentDTO));
        return CreatedAtAction(nameof(GetById), new {id = commentDTO.Id}, commentDTO);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateComment([FromRoute] int id, [FromBody] CommentUpdateDTO updateDTO)
    {   
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var comment = await _commentService.FindById(id);

        if (comment is null)
        {
            return NotFound();
        }

        await _commentService.Update(id, CommentMapper.ToCommentUpdateEntity(updateDTO));

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteComment([FromRoute] int id)
    {
        var comment = await _commentService.FindById(id);

        if (comment is null)
        {
            return NotFound();
        }

        await _commentService.Delete(id);

        return NoContent();
    }
}
