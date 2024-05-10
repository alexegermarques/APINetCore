using Microsoft.AspNetCore.Mvc;

namespace ApiNetCore;

[ApiController]
[Route("/v1/api/stock")]
public class StockController(IStockService stockService) : ControllerBase
{
    private readonly IStockService _stockService = stockService;

    [HttpGet]
    public IActionResult FindAll()
    {
        var stocks = _stockService.FindAll();
        return Ok(StockMapper.MapperToDTOList(stocks));
    }

    [HttpGet("{id}")]
    public IActionResult FindById([FromRoute] int id)
    {
        var stock = _stockService.FindById(id);

        if (stock is null)
        {
            return NotFound();
        }

        return Ok(StockMapper.MapperToDTO(stock));
    }

    [HttpPost]
    public IActionResult Create([FromBody] StockDTO stock)
    {
        _stockService.Add(StockMapper.MapperToEntity(stock));
        return CreatedAtAction(nameof(FindById), new { id = stock.Id }, stock);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        _stockService.Delete(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] StockDTO stockDTO)
    {
        _stockService.Update(id, StockMapper.MapperToEntity(stockDTO));

        return NoContent();
    }
}
