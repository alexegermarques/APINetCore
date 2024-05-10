namespace ApiNetCore;

public record class StockDTO
{
    public required int Id { get; init; }
    public required string Symbol { get; init; } = string.Empty;
    public required string CompanyName { get; init; } = string.Empty;
    public required decimal Purchase { get; init; }
    public required decimal LastDiv { get; init; }
    public required string Industry { get; init; } = string.Empty;
    public required long MarketCap { get; init; }
}
