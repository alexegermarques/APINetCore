
namespace ApiNetCore;

public class StockServiceImpl(ApplicationDbContext dbContext) : IStockService
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public void Add(Stock stock)
    {
        _dbContext.Stocks.Add(stock);
        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var stock = _dbContext.Stocks.FirstOrDefault(s => s.Id == id) ?? throw new BusinessException("Nenhum dados encontrado com esse ID.");
        _dbContext.Stocks.Remove(stock);
        _dbContext.SaveChanges();
    }

    public List<Stock> FindAll() => [.. _dbContext.Stocks];

    public Stock FindById(int id)
    {
        var stock = _dbContext.Stocks.FirstOrDefault(s => s.Id == id) ?? throw new BusinessException("Nenhum dados encontrado com esse ID.");
        return stock;
    }

    public void Update(int id, Stock stockUpdate)
    {
        var stock = _dbContext.Stocks.FirstOrDefault(s => s.Id == id) ?? throw new BusinessException("Nenhum dados encontrado com esse ID.");

        stock.CompanyName = stockUpdate.CompanyName;
        stock.Industry = stockUpdate.Industry;
        stock.Symbol = stockUpdate.Symbol;
        stock.Purchase = stockUpdate.Purchase;
        stock.LastDiv = stockUpdate.LastDiv;
        stock.MarketCap = stockUpdate.MarketCap;

        _dbContext.Update(stock);
        _dbContext.SaveChanges();
    }
}
