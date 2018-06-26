using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMangement
{
    class ProductBLL
    {
        public ProductBLL()
        {
        }

        public string ProductName { get; set; }

        public int ProductPrice { get; set; }

        ProductDAL dataccess = new ProductDAL();
        public bool add(ProductBLL p)
        {
            return dataccess.add(p);

        }

        public DataTable select()
        {
            return dataccess.select();

        }
    }

}
