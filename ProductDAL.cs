using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProductMangement
{
    class ProductDAL
    {


        static string connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public bool add(ProductBLL p)
        {


            try
            {

                // Create connection object
                SqlConnection con = new SqlConnection(connString);

                bool isSuccess = false;

                //Open connection
                con.Open();


                //Create query
                string sql = "Insert into Tbl_Product values (@Product_Name, @Product_Price)";

                //Create command object
                SqlCommand cmd = new SqlCommand(sql, con);

                //Adding Parameters

                cmd.Parameters.AddWithValue("@Product_Name", p.ProductName);
                cmd.Parameters.AddWithValue("@Product_Price", p.ProductPrice);


                //get results from database
                int results = cmd.ExecuteNonQuery();


                //close the connection
                con.Close();

                //check results and return success and failure
                if (results > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

                return isSuccess;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable select()
        {


            // Create connection object
            SqlConnection con = new SqlConnection(connString);

            //Open connection
            con.Open();


            //Create query
            string sql = "Select * from Tbl_Product";

            //Create command object
            SqlCommand cmd = new SqlCommand(sql, con);


            //Create a dataset object
            DataTable dt = new DataTable();

            //Create a Sqladapter object

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);

            return dt;


        }
    }
}
