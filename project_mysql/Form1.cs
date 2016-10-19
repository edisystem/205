using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_mysql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

string serverName = "mysql.site.ru"; // Адрес сервера (для локальной базы пишите "localhost")
            string userName = "admin"; // Имя пользователя
            string dbName = "myTestDb"; //Имя базы данных
            string port = "3306"; // Порт для подключения
            string password = "password123"; // Пароль для подключения
            string connStr = "server=" + serverName +
                ";user=" + userName +
                ";database=" + dbName +
                ";port=" + port +
                ";password=" + password + ";";
            /*           MySqlConnection conn = new MySqlConnection(connStr);
                       conn.Open();
                       string sql = "SELECT * FROM table1"; // Строка запроса
                       MySqlScript script = new MySqlScript(conn, sql);
                       int count = script.Execute();
                       richTextBox1.Text += ("Executed " + count + " statement(s).");
                       richTextBox1.Text += ("Delimiter: " + script.Delimiter);
                       */
            
string sql = "SELECT * FROM table1"; // Строка запроса
            MySqlConnection connection = new MySqlConnection(connStr);
            MySqlCommand sqlCom = new MySqlCommand(sql, connection);
            connection.Open();
            sqlCom.ExecuteNonQuery();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlCom);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            var myData = dt.Select();
            for (int i = 0; i < myData.Length; i++)
            {
                for (int j = 0; j < myData[i].ItemArray.Length; j++)
                    richTextBox1.Text += myData[i].ItemArray[j] + " ";
                richTextBox1.Text += "\n";
            }
            connection.Close();
        }
    }
}
