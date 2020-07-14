using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyNLayerProject.Web.Dtos
{
    public class CategoryWithProductDto:CategoryDto
    {
        public List<ProductDto> Products { get; set; }
    }
}
