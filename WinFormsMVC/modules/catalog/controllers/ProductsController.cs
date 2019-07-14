using WinFormsMVC.models;
using WinformsMVC.modules.catalog.views.products;
using System.Windows.Forms;

namespace WinFormsMVC.modules.catalog.controllers
{
    [Route("catalog/products")]
    class ProductsController : Controller
    {
        public ProductsForm IndexAction()
        {
            ProductsForm form = Application.OpenForms["ProductsForm"] == null ? new ProductsForm() : (ProductsForm)Application.OpenForms["ProductsForm"];
            form.Show();
            return form;
        }

        public void CreateAction(ProductDataParameters productParameters)
        {
            Product product = new Product()
            {
                Id = 0,
                Article = productParameters.Article,
                Title = productParameters.Title,
                Price = productParameters.Price
            };
            Products.GetInstance().AddProduct(product);
        }

        public void EditAction(ProductIdParameter parameter)
        {
            Product product = Products.GetInstance().GetProduct(parameter.Id);
            ProductDataParameters productParameters = new ProductDataParameters()
            {
                Id = product.Id,
                Article = product.Article,
                Title = product.Title,
                Price = product.Price
            };

            ProductForm form = Application.OpenForms["ProductForm"] == null ? new ProductForm() : (ProductForm)Application.OpenForms["ProductForm"];
            form.productParameters = productParameters;
            form.ShowDialog();
        }

        public void UpdateAction(ProductDataParameters productParameters)
        {
            Product product = Products.GetInstance().GetProduct(productParameters.Id);        
            product.Article = productParameters.Article;
            product.Title = productParameters.Title;
            product.Price = productParameters.Price;
        }

        public bool DeleteAction(ProductIdParameter parameter)
        { 
            Products.GetInstance().RemoveProduct(parameter.Id);
            return true;
        }
    }
}
