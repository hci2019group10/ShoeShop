﻿using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Service
{
    public interface IProductService
    {
        public List<Product> getAllProduct();
        public List<Product> getAllProductByGender(string gender);
        public Product getProductById(int id);
        public List<Product> searchProduct(string keyWork);
        public List<Product> getListProductByGenderAndCategory(string gender, string category);
        public List<Product> sort(string gender, string category, int minPrice, int maxPrice, string color, int size);
    }
}
