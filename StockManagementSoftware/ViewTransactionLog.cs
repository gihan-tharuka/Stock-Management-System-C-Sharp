using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace StockManagementSoftware
{
    public partial class ViewTransactionLog : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlDataAdapter adapt;
        public ViewTransactionLog()
        {
            InitializeComponent();
            Display();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       public void Display()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new MySqlDataAdapter("select * from stockitems.transactionlog", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void ViewTransactionLog_Load(object sender, EventArgs e)
        {

        }
    }
}
