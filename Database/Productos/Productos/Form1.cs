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
        SqlConnection cn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Northwind;Data Source=.");
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            


            SqlCommand cmd = new SqlCommand("selectP", cn);
            cmd.CommandType = CommandType.StoredProcedure;



            SqlDataAdapter da = new SqlDataAdapter(cmd);
            
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

                  }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            int i = dataGridView1.CurrentRow.Index;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("InsertP", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add(new SqlParameter("@ProductName",textBox2.Text));
            cmd.Parameters.Add(new SqlParameter("@SupplierID",textBox3.Text));
            cmd.Parameters.Add(new SqlParameter("@CategoryID",textBox4.Text));
            cmd.Parameters.Add(new SqlParameter("@QuantityPerUnit",textBox5.Text));
            cmd.Parameters.Add(new SqlParameter("@UnitPrice",textBox6.Text));
            cmd.Parameters.Add(new SqlParameter("@UnitsInStock",textBox7.Text));
            cmd.Parameters.Add(new SqlParameter("@UnitsOnOrder",textBox8.Text));
            cmd.Parameters.Add(new SqlParameter("@ReorderLevel",textBox9.Text));
            cmd.Parameters.Add(new SqlParameter("@Discontinued", textBox10.Text));
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DeleteP", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ProductID", textBox1.Text));
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
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
            cn.Close();
        }
    }
}
