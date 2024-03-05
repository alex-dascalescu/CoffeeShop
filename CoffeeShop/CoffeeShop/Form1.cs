using System.Security.Cryptography;

namespace CoffeeShop
{
    public partial class Percentage : Form
    {
        public Percentage()
        {
            InitializeComponent();
        }

        int startPos = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {

            startPos += 1;
            MyProgress.Value += 1;
            procent.Text = startPos + "%";
            if (MyProgress.Value == 100)
            {
                MyProgress.Value = 0;
                timer1.Stop();
                Login log = new Login();
                log.Show();
                this.Hide();
            }

        }

        private void Percentage_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}