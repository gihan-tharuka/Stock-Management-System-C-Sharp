using System;
using System.Windows.Forms;

namespace StockManagementSoftware
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewItem addNewItem = new AddNewItem();
            addNewItem.Show();
            this.Hide();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ViewTransactionLog viewTransactionLog = new ViewTransactionLog();
            viewTransactionLog.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
