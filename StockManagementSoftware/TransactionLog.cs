
using MySql.Data.MySqlClient;
using System;

namespace StockManagementSoftware
{
    class TransactionLog : StockItem
    {
        public DateTime Date { get; set; }
        public string Action { get; set; }

        public TransactionLog(DateTime date, string action, int stockCode, string name, int quantityInStock) : base (stockCode, name, quantityInStock)
        {
            Date = date;
            Action = action;
        }

        public void addNewItem()
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
            MySqlCommand cmd;

            cmd = new MySqlCommand("insert into stockitems.transactionlog(action,stockCode,stockName,quantityAdded) values(@action,@code,@name,@quan)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@action", Action);
            cmd.Parameters.AddWithValue("@code", StockCode);
            cmd.Parameters.AddWithValue("@name", Name);
            cmd.Parameters.AddWithValue("@quan", QuantityInStock);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        

    }

   
}
