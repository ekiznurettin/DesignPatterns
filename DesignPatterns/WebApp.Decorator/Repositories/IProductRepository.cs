﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Decorator.Models;

namespace WebApp.Decorator.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetById(int id);
        Task<List<Product>> GetAll();
        Task<List<Product>> GetAll(string UserId);
        Task<Product> Save(Product product);
        Task Update(Product product);
        Task Remove(Product product);
    }
}
