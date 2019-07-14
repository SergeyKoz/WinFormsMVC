using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsMVC;
using WinFormsMVC.models;

namespace WinformsMVC.modules.catalog.views.products
{
    public partial class ProductForm : Form
    {
        public ProductDataParameters productParameters;
        public ProductForm()
        {
            InitializeComponent();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            if (productParameters != null)
            {
                this.idText.Text = productParameters.Id.ToString();
                this.articleText.Text = productParameters.Article;
                this.titleText.Text = productParameters.Title;
                this.priceText.Text = productParameters.Price.ToString();
                this.button1.Hide();
                this.button2.Show();
            }
            else
            {
                this.idText.Text = "";
                this.articleText.Text = "";
                this.titleText.Text = "";
                this.priceText.Text = "";
                this.button1.Show();
                this.button2.Hide();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ProductDataParameters productParameters = new ProductDataParameters
            {
                Id = 0,
                Article = this.articleText.Text,
                Title = this.titleText.Text,
                Price = Convert.ToDouble(this.priceText.Text)
            };
            Router.Run("catalog/products/create", productParameters);
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ProductDataParameters productParameters = new ProductDataParameters
            {
                Id = Convert.ToInt32(this.idText.Text),
                Article = this.articleText.Text,
                Title = this.titleText.Text,
                Price = Convert.ToDouble(this.priceText.Text)
            };
            Router.Run("catalog/products/update", productParameters);
            this.Close();
        }
    }
}
