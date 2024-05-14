namespace ApiNetCore;

public class StockMapper
{
    private StockMapper()
    {
    }

    public static Stock MapperToEntity(StockDTO stockDTO) => new()
    {
        Id = stockDTO.Id,
        Symbol = stockDTO.Symbol,
        CompanyName = stockDTO.CompanyName,
        Purchase = stockDTO.Purchase,
        LastDiv = stockDTO.LastDiv,
        Industry = stockDTO.Industry,
        MarketCap = stockDTO.MarketCap
    };

    public static StockDTO MapperToDTO(Stock stock) => new()
    {
        Id = stock.Id,
        Symbol = stock.Symbol,
        CompanyName = stock.CompanyName,
        Purchase = stock.Purchase,
        LastDiv = stock.LastDiv,
        Industry = stock.Industry,
        MarketCap = stock.MarketCap,
        Comments = stock.Comments.Select(CommentMapper.ToCommentDTO).ToList()
    };

    public static List<StockDTO> MapperToDTOList(List<Stock> stocks)
    {
        List<StockDTO> stockDTOList = stocks.Select(s => new StockDTO
        {
            Id = s.Id,
            Symbol = s.Symbol,
            CompanyName = s.CompanyName,
            Purchase = s.Purchase,
            LastDiv = s.LastDiv,
            Industry = s.Industry,
            MarketCap = s.MarketCap,
            Comments = s.Comments.Select(CommentMapper.ToCommentDTO).ToList()
        }).ToList();

        return stockDTOList;
    }
}
