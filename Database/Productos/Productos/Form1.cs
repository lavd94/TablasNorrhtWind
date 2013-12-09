using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Productos
{
    public partial class Form1 : Form
    {
        
        //string ProductName, QuantityPerUnit;
        //int ProductID, SupplierID, CategoryID, UnitsInStock, UnitsOnOrder, RecordLevel;
        //decimal UnitPrice;
        //bool Discontinued;
        NorthwindDataContext db = new NorthwindDataContext();
        SqlConnection cn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Northwind;Data Source=.");
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //SqlCommand cmd = new SqlCommand("selectP", cn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //SqlDataAdapter da = new SqlDataAdapter(cmd);            
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0];
            var query = from p in db.Products
                        select p;
            dataGridView1.DataSource = query;
                      


                  }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //SqlCommand cmd = new SqlCommand("InsertP", cn);
            //cmd.CommandType = CommandType.StoredProcedure;
            
            //cmd.Parameters.Add(new SqlParameter("@ProductName",textBox2.Text));
            //cmd.Parameters.Add(new SqlParameter("@SupplierID",textBox3.Text));
            //cmd.Parameters.Add(new SqlParameter("@CategoryID",textBox4.Text));
            //cmd.Parameters.Add(new SqlParameter("@QuantityPerUnit",textBox5.Text));
            //cmd.Parameters.Add(new SqlParameter("@UnitPrice",textBox6.Text));
            //cmd.Parameters.Add(new SqlParameter("@UnitsInStock",textBox7.Text));
            //cmd.Parameters.Add(new SqlParameter("@UnitsOnOrder",textBox8.Text));
            //cmd.Parameters.Add(new SqlParameter("@ReorderLevel",textBox9.Text));
            //cmd.Parameters.Add(new SqlParameter("@Discontinued", textBox10.Text));
            //cn.Open();
            //cmd.ExecuteNonQuery();
            //cn.Close();

            Product p = new Product();

            p.ProductName = textBox2.Text;
            p.SupplierID = int.Parse(textBox3.Text);
            p.CategoryID = int.Parse(textBox4.Text);
            p.QuantityPerUnit = textBox5.Text;
            p.UnitPrice = decimal.Parse(textBox6.Text);
            p.UnitsInStock = short.Parse(textBox7.Text);
            p.UnitsOnOrder = short.Parse(textBox8.Text);
            p.ReorderLevel = short.Parse(textBox9.Text);
            p.Discontinued = bool.Parse(textBox10.Text);
            db.Products.InsertOnSubmit(p);
            db.SubmitChanges();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            //SqlCommand cmd = new SqlCommand("DeleteP", cn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add(new SqlParameter("@ProductID", textBox1.Text));
            //cn.Open();
            //cmd.ExecuteNonQuery();
            //cn.Close();

            var query = from p in db.Products
                        where p.ProductID == int.Parse(textBox1.Text)
                        select p;
            foreach (Product p in query)
            {
                db.Products.DeleteOnSubmit(p);
            }
            db.SubmitChanges();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*
            SqlCommand cmd = new SqlCommand("UpdateP", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ProductID", textBox1.Text));
            cmd.Parameters.Add(new SqlParameter("@ProductName", textBox2.Text));
            cmd.Parameters.Add(new SqlParameter("@SupplierID", textBox3.Text));
            cmd.Parameters.Add(new SqlParameter("@CategoryID", textBox4.Text));
            cmd.Parameters.Add(new SqlParameter("@QuantityPerUnit", textBox5.Text));
            cmd.Parameters.Add(new SqlParameter("@UnitPrice", textBox6.Text));
            cmd.Parameters.Add(new SqlParameter("@UnitsInStock", textBox7.Text));
            cmd.Parameters.Add(new SqlParameter("@UnitsOnOrder", textBox8.Text));
            cmd.Parameters.Add(new SqlParameter("@ReorderLevel", textBox9.Text));
            cmd.Parameters.Add(new SqlParameter("@Discontinued", textBox10.Text));
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();*/
            var query = from p in db.Products
                        where p.ProductID == int.Parse(textBox1.Text)
                        select p;
            foreach (Product p in query)
            {
                p.ProductID = int.Parse(textBox1.Text);
                p.ProductName = textBox2.Text;
                p.SupplierID = int.Parse(textBox3.Text);
                p.CategoryID = int.Parse(textBox4.Text);
                p.QuantityPerUnit = textBox5.Text;
                p.UnitPrice = decimal.Parse(textBox6.Text);
                p.UnitsInStock =short.Parse(textBox7.Text);
                p.UnitsOnOrder = short.Parse(textBox8.Text);
                p.ReorderLevel = short.Parse(textBox9.Text);
                p.Discontinued = bool.Parse(textBox10.Text);
               
            }
            
            db.SubmitChanges();
        }
    }
}
