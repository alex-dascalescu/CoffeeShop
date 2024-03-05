using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CoffeeShop
{
    public partial class Coffee : Form
    {
        public Coffee()
        {
            InitializeComponent();
            populate();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dscal\Desktop\CoffeeShop\CoffeeShop\Db\CoffeeShopDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            con.Open();
            String query = "select  * from CoffeeTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CoffeeDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void filter()
        {
            con.Open();
            String query = "select  * from CoffeeTable where Ccat='" + CatSearch.SelectedItem.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CoffeeDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CategoriesTb.SelectedIndex == -1 || PTypeTb.Text == "" || QuantityTb.Text == "" || PriceTb.Text == "")
            {
                MessageBox.Show("Missing information!");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into CoffeeTable values ('" + CategoriesTb.SelectedItem.ToString() + "', '" + PTypeTb.Text + "' , " + QuantityTb.Text + "," + PriceTb.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product saved!");

                    con.Close();
                    populate();
                    reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void CatSearch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            filter();
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            populate();
            CatSearch.SelectedIndex = -1;

        }

        private void reset()
        {
            PTypeTb.Text = "";
            CategoriesTb.SelectedIndex = -1;
            QuantityTb.Text = "";
            PriceTb.Text = "";

        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            reset();
        }
        int key = 0;



        private void DeleteBtn_Click(object sender, EventArgs e)
        {

            if (key == 0)
            {
                MessageBox.Show("Missing information!");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "delete from CoffeeTable where Cid=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product deleted!");

                    con.Close();
                    populate();
                    reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (CategoriesTb.SelectedIndex == -1 || PTypeTb.Text == "" || QuantityTb.Text == "" || PriceTb.Text == "")
            {
                MessageBox.Show("Missing information!");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update CoffeeTable set Cpt='" + PTypeTb.Text + "',Cqty=" + QuantityTb.Text + ",Ccat=" + CategoriesTb.SelectedIndex.ToString() + ",Cprice=" + PriceTb.Text + "where Cid=" + key + "; ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product updated!");

                    con.Close();
                    populate();
                    reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void CatSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CoffeeDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PTypeTb.Text = CoffeeDGV.SelectedRows[0].Cells[1].Value.ToString();
            QuantityTb.Text = CoffeeDGV.SelectedRows[0].Cells[2].Value.ToString();
            CategoriesTb.SelectedItem = CoffeeDGV.SelectedRows[0].Cells[3].Value.ToString();
            PriceTb.Text = CoffeeDGV.SelectedRows[0].Cells[4].Value.ToString();

            if (PTypeTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(CoffeeDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
