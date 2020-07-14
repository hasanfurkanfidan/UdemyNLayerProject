using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Repositories;

namespace UdemyNLayerProject.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private  AppDbContext appDbContext { get => _context as AppDbContext; }
        public ProductRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await appDbContext.Products.Include(P => P.Category).SingleOrDefaultAsync(p => p.Id == productId);
        }
    }
}
