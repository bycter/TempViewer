using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using MySql.Data.MySqlClient;


namespace TemperatureGraphs_MySql
{
	public partial class MainForm : Form
	{
		private MySqlConnection connection;
		private string server;
		private string database;
		private string uid;
		private string password;

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			string connectionString;
			server = "192.168.3.10";
			uid = "smarthouse";
			password = "U4PD2cKIAs";
			database = "smarthouse";

			connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
			// connectionString = "SERVER=10.8.0.10;DATABASE=smarthouse;UID=smarthouse;PASSWORD=U4PD2cKIAs";
			connection = new MySqlConnection(connectionString);

			label1.Text = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + "********" + ";";
		}

		private void btnConnectDB_Click(object sender, EventArgs e)
		{
			if (OpenConnection())
			{
				MessageBox.Show("Connection open.");
			}
			if (!CloseConnection())
			{
				label2.Text = "Connection NOT close.";
			}
			else
			{
				label2.Text = "Connection close.";
			}
		}

		private void btnViewTable_Click(object sender, EventArgs e)
		{
            List<string>[] list1 = new List<string>[3];
            list1[0] = new List<string>();
            list1[1] = new List<string>();
            list1[2] = new List<string>();
            int tableCount;

            //label2.Text = Convert.ToString(MysqlCount());
            list1 = MysqlSelect();
            tableCount = list1[0].Count;

            dataGridView1.RowCount = tableCount;
            dataGridView1.ColumnCount = 3;

            for (int i = 0; i < tableCount; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = Convert.ToString(list1[0][i]);
                dataGridView1.Rows[i].Cells[1].Value = Convert.ToString(list1[1][i]);
                dataGridView1.Rows[i].Cells[2].Value = Convert.ToString(list1[2][i]);
            }
		}

        private void btnInsert_Click(object sender, EventArgs e)
        {
            MysqlInsert();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MysqlUpdate();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MysqlDelete();
        }

		//open connection to database
		private bool OpenConnection()
		{
			try
			{
				connection.Open();
				return true;
			}
			catch (MySqlException ex)
			{
				string errorMessage;

				//When handling errors, you can your application's response based 
				//on the error number.
				//The two most common error numbers when connecting are as follows:
				//1042: Cannot connect to server.
				//0: Invalid user name and/or password.

				errorMessage = "Error: " + ex.Number + ". ";
				switch (ex.Number)
				{
					case 0:
						errorMessage += "Invalid username/password/database, please try again";
						break;

					case 1042:
						errorMessage += "Message: Can't get hostname for your address. Contact administrator";
						break;

					default:
						errorMessage += "Something wrong...";
						break;
				}
				MessageBox.Show(errorMessage);
				return false;
			}
		}

		//Close connection
		private bool CloseConnection()
		{
			try
			{
				connection.Close();
				return true;
			}
			catch (MySqlException ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
		}

        //Типы методов для выполнения запросов к базе Mysql:
        //1. ExecuteNonQuery: используется для выполнения команды,
            //которые не вернут какие-либо данные, например Insert, update or delete.
        //2. ExecuteReader: используется для выполнения комманды,
            //которая будет возвращать 0 или более записей, например Select.
        //3. ExecuteScalar: используется для выполнения команды,
            //которая будет возвращать только 1 значение, например Select Count(*).


        //Insert statement
        public void MysqlInsert()
        {
            string query = "INSERT INTO tableInfo (name, age) VALUES('John Smith', '33')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void MysqlUpdate()
        {
            string query = "UPDATE tableInfo SET name='Joe', age='22' WHERE name='John Smith'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void MysqlDelete()
        {
            string query = "DELETE FROM tableInfo WHERE name='John Smith'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Select statement
        public List<string>[] MysqlSelect()
        {
            string query = "SELECT * FROM tableInfo";

            //Create a list to store the result
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["name"] + "");
                    list[2].Add(dataReader["age"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        //Count statement
        public int MysqlCount()
        {
            string query = "SELECT Count(*) FROM tableInfo";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

		////Backup
		//public void Backup()
		//{
		//}

		////Restore
		//public void Restore()
		//{
		//}
	}
}
