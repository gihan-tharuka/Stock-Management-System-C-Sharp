using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;


namespace StockManagementSoftware
{
    public partial class Login : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
       

        public Login()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtUserName.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                connection.Open();

                string username = txtUserName.Text;
                string password = txtPassword.Text;

                string query = "SELECT * FROM stockitems.Login WHERE userName = @username AND password = @password";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    MessageBox.Show("Login Successful !", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide();
                }
                else
                {
                    
                    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    {
                        throw new Exception("User Name or Password cannot be empty.");
                    }
                    else
                    {
                        MessageBox.Show("Login failed. Invalid username or password.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }

                reader.Close();
            }
            
            
            catch (Exception ex)
            {
                Console.WriteLine();
                MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
            

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
