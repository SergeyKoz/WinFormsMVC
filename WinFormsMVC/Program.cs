using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFormsMVC.models;

namespace WinFormsMVC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            User user = User.GetInstance();
            user.Age = 16;
            user.Name = "James Bond";            
            user.Phone = "38-050-014-03-45";
            user.Email = "jamesbond@gmail.com";
            user.Sex = "Male";

            //user.Login = "JamesBond";
            //user.Password = "JamesBond";
            user.Login = "1";
            user.Password = "1";
            user.Logged = false;

            var products = new List<Product>()
            {
                new Product { Id = 1, Article = "pr0001", Title = "Beer 5%", Price = 8.5 },
                new Product { Id = 2, Article = "pr0002", Title = "Flour 2kg", Price = 3.0 },
                new Product { Id = 3, Article = "pr0003", Title = "Bananas Ecuador", Price = 20.0 },
            };
            Products.GetInstance().products = products;

            Application.Run(new AppContext());
        }
    }
}
