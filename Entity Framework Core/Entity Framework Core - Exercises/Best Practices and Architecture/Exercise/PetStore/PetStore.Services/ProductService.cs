using AutoMapper;
using PetStore.Data;
using PetStore.Models;
using PetStore.Services.Products.InputModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Services
{
    public class ProductService
    {
        private readonly PetStoreDbContext context;
        private readonly IMapper mapper;

        public ProductService(PetStoreDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddProduct(AddProductInputServiceModel model)
        {
            var product = this.mapper.Map<Product>(model);

            this.context.Products.Add(product);
            this.context.SaveChanges();
        }
    }
}
