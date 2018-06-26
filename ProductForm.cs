using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProductMangement
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        ProductBLL p = new ProductBLL();
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            p.ProductName = txt_Name.Text;
            p.ProductPrice = Convert.ToInt16(txtPrice.Text);
            bool result = p.add(p);

            dataGridView_Product.DataSource = p.select();

            if (result)
            {
                MessageBox.Show("Products added Successfully");
            }
            else
            {
                MessageBox.Show("Oops.. There is some error");

            }
           


        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'productMangementDBDataSet.Tbl_Product' table. You can move, or remove it, as needed.
            this.tbl_ProductTableAdapter.Fill(this.productMangementDBDataSet.Tbl_Product);

        }

    }
}
