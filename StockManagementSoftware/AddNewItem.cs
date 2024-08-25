using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace StockManagementSoftware
{
    public partial class AddNewItem : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");


        public AddNewItem()
        {
            InitializeComponent();

        }

    

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                int theCode = Convert.ToInt32(txtCode.Text);
                string theName = txtName.Text;
                int theQuantity = Convert.ToInt32(txtQuantity.Text);

                
                
                // Checks if Username Exists
                MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM stockitems.stockitems WHERE itemcode = @ItemCode", con);
                cmd1.Parameters.AddWithValue("@ItemCode", txtCode.Text);
                con.Open();
                bool itemExists = false;
                using (var dr1 = cmd1.ExecuteReader())
            
                if (itemExists = dr1.HasRows)
                {

                    MessageBox.Show("Stock Item already exixsts !", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
                con.Close();
                if (!(itemExists))
                {
                    StockItem stockItem = new StockItem(theCode, theName, theQuantity);
                    stockItem.addNewItem();


                    TransactionLog transactionLog = new TransactionLog(DateTime.Now, "Item Added", theCode, theName, theQuantity);
                    transactionLog.addNewItem();



                    MessageBox.Show("Record Successfully Added", "INSERT", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    
                    ClearData();

                   
                }
            }
            

            catch (FormatException )
            {
                MessageBox.Show("Invalid input format or empty fields. Please enter valid integers for Code and Quantity.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            




        }

     

        
        private void ClearData()
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtQuantity.Text = "";

        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtQuantity.Text = "";
        }

        private void AddNewItem_Load(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
    
}
