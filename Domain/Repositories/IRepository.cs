﻿namespace DigitalMarket_API.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<T> Delete(int id);
        Task<T> GetOne(int id);
        Task<List<T>> GetAll();
    }
}
