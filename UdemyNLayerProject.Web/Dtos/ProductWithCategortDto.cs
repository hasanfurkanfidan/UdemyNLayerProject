﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Web.Dtos
{
    public class ProductWithCategortDto:ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}
