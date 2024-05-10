namespace ApiNetCore;

public interface IStockService
{
    void Add(Stock stock);
    List<Stock> FindAll();
    Stock FindById(int id);
    void Delete(int id);
    void Update(int id, Stock stockUpdate);
}
