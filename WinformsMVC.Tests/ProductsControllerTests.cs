using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinFormsMVC;
using WinformsMVC.modules.catalog.views.products;
using WinFormsMVC.models;

namespace WinFormsMVC.Tests
{
    [TestClass]
    public class ProductsControllerTests
    {
        [TestMethod]
        public void IndexTest()
        {
            ProductsForm form = (ProductsForm)Router.Run("catalog/products/index");
            Assert.IsNotNull(form);
        }

        [TestMethod]
        public void CreateTest()
        {
            CreateProduct();
            Assert.IsNotNull(Products.GetInstance().products.Find(p => p.Article == "p1"));
        }

        [TestMethod]
        public void UpdateTest()
        {
            Product product = CreateProduct();
            ProductDataParameters productUpdateParameters = new ProductDataParameters
            {
                Id = product.Id,
                Article = "p1-updated",
                Title = "Product-updated",
                Price = 2
            };
            Router.Run("catalog/products/update", productUpdateParameters);
            
            Assert.AreEqual("Product-updated", Products.GetInstance().GetProduct(product.Id).Title);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Product product = CreateProduct();
            ProductIdParameter productIdParameter = new ProductIdParameter
            {
                Id = product.Id
            };
            Assert.IsTrue((bool)Router.Run("catalog/products/delete", productIdParameter));
        }

        private Product CreateProduct()
        {
            ProductDataParameters productParameters = new ProductDataParameters
            {
                Id = 0,
                Article = "p1",
                Title = "Product",
                Price = 1.5
            };
            Router.Run("catalog/products/create", productParameters);
            return Products.GetInstance().products.Find(p => p.Article == "p1");
        }
    }
}
