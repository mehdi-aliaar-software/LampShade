using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;

namespace ShopManagement.Application.Contracts.Product
{
    public interface IProductApplication
    {
        OperationResult Create(CreateProduct command);
        OperationResult Edit(EditProduct command);

        void IsStock(int id);
        void NotInStock(int id);
        EditProduct GetDetails(int id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
    }
}
