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

            var slug=command.Slug.Slugify();
            var product = new Product(command.Name, command.Code, command.ShortDescription, command.ShortDescription,
                command.Picture, command.PictureAlt, command.PictureTitle, command.UnitPrice, command.CategoryId,
                slug, command.Keywords, command.MetaDescription);

            _productRepository.Create(product);
            _productRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();

            var product = _productRepository.Get(command.Id);
            if (product == null)
            {
                return operation.Failed(ApplicationMessages.RecordNotFound);
            }

            if (_productRepository.Exists(x=>x.Name==command.Name && x.Id!=command.Id))
            {
                return operation.Failed(ApplicationMessages.DuplicatedRrcord);
            }

            var slug = command.Slug.Slugify();
            product.Edit(command.Name, command.Code, command.ShortDescription, command.ShortDescription,
                command.Picture, command.PictureAlt, command.PictureTitle, command.UnitPrice, command.CategoryId,
                slug, command.Keywords, command.MetaDescription);

            _productRepository.SaveChanges();   
            return operation.Succeeded();
        }

        public OperationResult IsStock(int id)
        {
            var operation = new OperationResult();

            var product = _productRepository.Get(id);
            if (product == null)
            {
                return operation.Failed(ApplicationMessages.RecordNotFound);
            }

            product.InStock();

            _productRepository.SaveChanges();
            return operation.Succeeded();
        }
        public OperationResult NotInStock(int id)
        {
            var operation = new OperationResult();

            var product = _productRepository.Get(id);
            if (product == null)
            {
                return operation.Failed(ApplicationMessages.RecordNotFound);
            }

            product.NotInStock();

            _productRepository.SaveChanges();
            return operation.Succeeded();
        }

        public EditProduct GetDetails(int id)
        {
            return _productRepository.GetDetails(id);
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _productRepository.Search(searchModel);
        }
    }
}
