﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Data.Seed
{
   public class ProductSeed:IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;
        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Pilot kalem",
                    Price = 12.50m,
                    Stock = 100,
                    CategoryId = _ids[0]
                },
                  new Product
                  {
                      Id = 2,
                      Name = "Kurşun kalem",
                      Price = 40.50m,
                      Stock = 200,
                      CategoryId = _ids[0]
                  },
                    new Product
                    {
                        Id = 3,
                        Name = "Tükenmez kalem",
                        Price = 500m,
                        Stock = 300,
                        CategoryId = _ids[0]
                    }
                    ,
                    new Product
                    {
                        Id = 4,
                        Name = "Küçük boy defter",
                        Price = 12.50m,
                        Stock = 300,
                        CategoryId = _ids[1]
                    }
                     ,
                    new Product
                    {
                        Id = 5,
                        Name = "Orta boy defter",
                        Price = 15m,
                        Stock = 150,
                        CategoryId = _ids[1]
                    },
                    new Product
                    {
                        Id = 6,
                        Name = "Büyük boy defter",
                        Price = 17m,
                        Stock = 100,
                        CategoryId = _ids[1]
                    }
                );
        }
    }
}
