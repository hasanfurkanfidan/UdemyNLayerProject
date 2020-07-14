using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.API.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="{0} alanı gereklidir.")]
        public string Name { get; set; }
        [Range(1,maximum:int.MaxValue,ErrorMessage ="{0} birden büyük gereklidir")]
        
        public int Stock { get; set; }
        [Range(0, maximum: double.MaxValue, ErrorMessage = "{0} 0 den büyük olmalı büyük gereklidir")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
      



    }
}
