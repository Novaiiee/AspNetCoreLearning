using AspNetCoreLearning.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreLearning.Database
{
    public interface IRepository<T>
    {
        public Task<T> CreateAsync(T entity);
        public Task<List<T>> FindAsync();
        public Task<T> FindByIdAsync(Guid id);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(Guid id); 
    }
}
