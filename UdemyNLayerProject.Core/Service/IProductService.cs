using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Core.Service
{
   public interface IProductService:IService<Product>
    {
        //bool ControlInnerBarcod(Product product);
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
