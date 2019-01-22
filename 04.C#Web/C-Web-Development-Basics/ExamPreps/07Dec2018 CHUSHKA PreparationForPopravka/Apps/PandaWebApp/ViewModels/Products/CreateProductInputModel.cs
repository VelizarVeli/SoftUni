﻿using ChushkaWebApp.Models;

namespace ChushkaWebApp.ViewModels.Products
{
    public class CreateProductInputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }
    }
}
