﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(int id, Product product);
        Task DeleteAsync(int id);
        Task<bool> AddToStock(int id, int quantity);
        Task<bool> DecrementStock(int id, int quantity);
    }
}
