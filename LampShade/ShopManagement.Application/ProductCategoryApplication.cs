﻿using _0.Framework.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }
        public OperationResult  Create(CreateProductCategory command)
        {
            OperationResult result = new OperationResult();

            if (_productCategoryRepository.Exists(x=>x.Name==command.Name))
            {
                result.Failed("there already exists the name you entered...");
            }

            string slug = command.Slug.Slugify();
            ProductCategory entity = new ProductCategory(
                command.Name,
                command.Description,
                command.Picture,
                command.PictureTitle,
                command.PictureAlt,
                command.Keywords,
                command.MetaDescription,
                slug
            );

            
            _productCategoryRepository.Create(entity);
            _productCategoryRepository.SaveChanges();
            return result.Succeeded();
        }

        public OperationResult Edit(EditProductCategory command)
        {
            OperationResult result=new OperationResult();

            var entity = _productCategoryRepository.Get(command.Id);
            if (entity == null)
            {
                return result.Failed("Record Not found !");
            }

            if (_productCategoryRepository.Exists(x=>x.Name==command.Name && x.Id!=command.Id))
            {
                return result.Failed("Record with this name already exists !");
            }

            var slug=command.Slug.Slugify();    
            entity.Edit(command.Name, command.Description, command.Picture, command.PictureTitle, command.PictureAlt, command.Keywords,
                command.MetaDescription,slug);
            _productCategoryRepository.SaveChanges();
            return result.Succeeded();
        }

        public EditProductCategory GetDetails(int id)
        {
            EditProductCategory entity = _productCategoryRepository.GetDetails(id);
            return entity;
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            List<ProductCategoryViewModel> result = _productCategoryRepository.Search(searchModel);
            return result;
        }
    }
}
