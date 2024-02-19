using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
            var operation=new OperationResult();
            if (_productRepository.Exists(x => x.Name == command.Name))
            {
                return operation.Failed(ApplicationMessages.DuplicatedRrcord);
            }

            var product = new Product(command.Name, command.Code, command.ShortDescription, command.ShortDescription,
                command.Picture, command.PictureAlt, command.PictureTitle, command.UnitPrice, command.CategoryId,
                command.Slug, command.Keywords, command.MetaDescription);

            _productRepository.Create(product);
            _productRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Edit(EditProduct command)
        {
            throw new NotImplementedException();
        }

        public void IsStock(int id)
        {
            throw new NotImplementedException();
        }

        public void NotInStock(int id)
        {
            throw new NotImplementedException();
        }

        public EditProduct GetDetails(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
