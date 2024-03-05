using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            populate();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dscal\Desktop\CoffeeShop\CoffeeShop\Db\CoffeeShopDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            con.Open();
            String query = "select  * from UserTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            UsersDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CNPtb.Text == "" || UnameTb.Text == "" || PhoneTb.Text == "" || PassTb.Text == "")
            {
                MessageBox.Show("Missing information!");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into UserTbl values ('" + PhoneTb.Text + "', '" + UnameTb.Text + "' ,'" + PassTb.Text + "' , " + CNPtb.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User saved!");

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

        private void reset()
        {
            UnameTb.Text = "";
            CNPtb.Text = "";
            PhoneTb.Text = "";
            PassTb.Text = "";
        }
        private void ResetBtn_Click(object sender, EventArgs e)
        {
            reset();
        }

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
                    string query = "delete from UserTbl where Uid=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User deleted!");

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

        int key = 0;

        private void UsersDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UnameTb.Text = UsersDGV.SelectedRows[0].Cells[1].Value.ToString();
            PassTb.Text = UsersDGV.SelectedRows[0].Cells[2].Value.ToString();
            CNPtb.Text = UsersDGV.SelectedRows[0].Cells[3].Value.ToString();
            PhoneTb.Text = UsersDGV.SelectedRows[0].Cells[4].Value.ToString();

            if (UnameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(UsersDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (PhoneTb.Text == "" || UnameTb.Text == "" || PassTb.Text == "" || CNPtb.Text == "")
            {
                MessageBox.Show("Missing information!");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update UserTbl set Uphone='" + PhoneTb.Text + "', Uname='" + UnameTb.Text + "',Upass='" + PassTb.Text + "' ,Ucnp=" + CNPtb.Text + "where Uid=" + key + "; ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User updated!");

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
    }
}
