using Microsoft.EntityFrameworkCore;

namespace ApiNetCore;

public class StockServiceImpl(ApplicationDbContext dbContext) : IStockService
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task Add(Stock stock)
    {
        await _dbContext.Stocks.AddAsync(stock);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var stock = await _dbContext.Stocks.FirstOrDefaultAsync(s => s.Id == id) ?? throw new BusinessException("Nenhum dados encontrado com esse ID.");
        _dbContext.Stocks.Remove(stock);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Stock>> FindAll(QueryObjects query)
    {
        var stocks = _dbContext.Stocks.Include(c => c.Comments).AsQueryable();

        if (!string.IsNullOrEmpty(query.Symbol))
        {
            stocks = stocks.Where(s => s.CompanyName.Contains(query.Symbol));
        }

        if (!string.IsNullOrEmpty(query.CompanyName))
        {
            stocks = stocks.Where(s => s.CompanyName.Contains(query.CompanyName));
        }

        return await stocks.ToListAsync();
    }

    public async Task<Stock> FindById(int id)
    {
        var stock = await _dbContext.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(s => s.Id == id) ?? throw new BusinessException("Nenhum dados encontrado com esse ID.");
        return stock;
    }

    public Task<bool> StockExists(int id) => _dbContext.Stocks.AnyAsync(s => s.Id == id);

    public async Task Update(int id, Stock stockUpdate)
    {
        var stock = await _dbContext.Stocks.FirstOrDefaultAsync(s => s.Id == id) ?? throw new BusinessException("Nenhum dados encontrado com esse ID.");

        stock.CompanyName = stockUpdate.CompanyName;
        stock.Industry = stockUpdate.Industry;
        stock.Symbol = stockUpdate.Symbol;
        stock.Purchase = stockUpdate.Purchase;
        stock.LastDiv = stockUpdate.LastDiv;
        stock.MarketCap = stockUpdate.MarketCap;

        _dbContext.Update(stock);
        await _dbContext.SaveChangesAsync();
    }
}
