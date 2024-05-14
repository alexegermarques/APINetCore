using Microsoft.AspNetCore.Mvc;

namespace ApiNetCore;

[ApiController]
[Route("/v1/api/stock")]
public class StockController(IStockService stockService) : ControllerBase
{
    private readonly IStockService _stockService = stockService;

    [HttpGet]
    public async Task<IActionResult> FindAll([FromQuery] QueryObjects query)
    {
        var stocks = await _stockService.FindAll(query);
        return Ok(StockMapper.MapperToDTOList(stocks));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> FindById([FromRoute] int id)
    {
        var stock = await _stockService.FindById(id);

        if (stock is null)
        {
            return NotFound();
        }

        return Ok(StockMapper.MapperToDTO(stock));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] StockDTO stock)
    {
        await _stockService.Add(StockMapper.MapperToEntity(stock));
        return CreatedAtAction(nameof(FindById), new { id = stock.Id }, stock);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _stockService.Delete(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] StockDTO stockDTO)
    {
        await _stockService.Update(id, StockMapper.MapperToEntity(stockDTO));
        return NoContent();
    }
}
