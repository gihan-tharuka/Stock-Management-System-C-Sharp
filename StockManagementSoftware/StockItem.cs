
using MySql.Data.MySqlClient;

namespace StockManagementSoftware
{
    class StockItem
    {
        public int StockCode { get; set; }
        public string Name { get; set; }
        public int QuantityInStock { get; set; }

        public StockItem()
        { 

        }

        public StockItem(int stockCode, string name, int quantityInStock)
        {
            StockCode = stockCode;
            Name = name;
            QuantityInStock = quantityInStock;
        }

        public void addNewItem()
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
            MySqlCommand cmd;

            cmd = new MySqlCommand("insert into stockitems.stockitems(itemcode,itemname,quantity) values(@code,@name,@quan)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@code", StockCode);
            cmd.Parameters.AddWithValue("@name", Name);
            cmd.Parameters.AddWithValue("@quan", QuantityInStock);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        
        
    }
}

