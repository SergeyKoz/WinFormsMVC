using System.Collections.Generic;

namespace WinFormsMVC.models
{
    public class Products
    {
        private static Products instance;
                
        private Products()
        {
            products = new List<Product>();
        }

        public static Products GetInstance()
        {
            if (instance == null)
            {
                instance = new Products();
            }
            return instance;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public Product GetProduct(int id)
        {
            return products.Find(p => p.Id == id);
        }

        public void RemoveProduct(int id)
        {
            products.RemoveAll(p => p.Id == id);
        }

        public List<Product> products;

        public int Index { get; set; }
    }

    public class ProductIdParameter : ActionParameter
    {
        public int Id { get; set; }
    }

    public class ProductDataParameters : ActionParameter
    {
        public int Id { get; set; }

        public string Article { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }
    }

    public class Product
    {
        private int id;

        public int Id
        {
            set
            {
                if (value == 0)
                {
                    id = ++Products.GetInstance().Index;
                }
                else
                {
                    if (value > Products.GetInstance().Index)
                    {
                        Products.GetInstance().Index = value;
                    }
                    id = value;
                }
            }
            get { return id; }
        }

        public string Article { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }
    }
}
