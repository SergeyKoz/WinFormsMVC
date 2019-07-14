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
    public partial class ProductsForm : Form
    {
        //public products
        public ProductsForm()
        {
            InitializeComponent();
        }

        private void LogOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Router.Run("user/logout");
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {        
            dataGridView1.DataSource = GetBindingSource();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Delete.Index)
            {
                int id = ((Product)((DataGridView)sender).CurrentRow.DataBoundItem).Id;
                ProductIdParameter parameter = new ProductIdParameter { Id = id };
                object f = Router.Run("catalog/products/delete", parameter);
                if ((bool)f)
                {  
                    dataGridView1.DataSource = GetBindingSource();
                }
            }

            if (e.ColumnIndex == Edit.Index)
            {
                int id = ((Product)((DataGridView)sender).CurrentRow.DataBoundItem).Id;
                object f = Router.Run("catalog/products/edit", new ProductIdParameter { Id = id });
                dataGridView1.DataSource = GetBindingSource();
            }
        }

        private void AddProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductForm form = Application.OpenForms["ProductForm"] == null ? new ProductForm() : (ProductForm)Application.OpenForms["ProductForm"];
            form.ShowDialog();
            dataGridView1.DataSource = GetBindingSource();
        }

        private BindingSource GetBindingSource()
        {
            List<Product> products = Products.GetInstance().products;
            var bindingList = new BindingList<Product>(products);
            return new BindingSource(bindingList, null);
        }

        private void ProductsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
