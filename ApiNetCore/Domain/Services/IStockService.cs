﻿namespace ApiNetCore;

public interface IStockService
{
    Task Add(Stock stock);
    Task<List<Stock>> FindAll(QueryObjects query);
    Task<Stock> FindById(int id);
    Task Delete(int id);
    Task Update(int id, Stock stockUpdate);
    Task<bool> StockExists(int id);
}
