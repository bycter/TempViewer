using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Windows.Forms.DataVisualization.Charting;


namespace TemperatureGraphs_MySql
{
	public partial class MainForm : Form
	{
		private MySqlConnection connection;
		private string server;
		private string database;
		private string uid;
		private string password;

		public DateTime[] date;
		public float[] temperature;
		//int tableCount = 0;

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{

			string connectionString;
			server = "10.8.0.10";
			uid = "smarthouse";
			password = "U4PD2cKIAs";
			database = "smarthouse";

			connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
			// connectionString = "SERVER=10.8.0.10;DATABASE=smarthouse;UID=smarthouse;PASSWORD=U4PD2cKIAs";
			connection = new MySqlConnection(connectionString);

			label1.Text = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + "********" + ";";
			label2.Text = "SELECT * FROM odintsova_street WHERE DATE(ow_date) = '2015-01-11';";
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
			int tableCount = 0;

			if ((tableCount = MysqlCount()) == -1)
			{
				MessageBox.Show("MysqlCount return -1");
			}

			label2.Text = Convert.ToString("DataCount: " + tableCount);

			date = new DateTime[tableCount + 1];
			temperature = new float[tableCount + 1];

			MysqlSelect(tableCount, date, temperature);

			dataGridView1.RowCount = tableCount;
			dataGridView1.ColumnCount = 2;

			for (int i = 0; i < tableCount; i++)
			{
				dataGridView1.Rows[i].Cells[0].Value = Convert.ToString(date[i]);
				dataGridView1.Rows[i].Cells[1].Value = Convert.ToString(temperature[i]);
			}
		}

        //open connection to database
		public bool OpenConnection()
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
		public bool CloseConnection()
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

        //Select statement
        public DateTime[] MysqlSelectDate()
        {
			string query = "SELECT * FROM odintsova_street WHERE DATE(ow_date) = '2015-01-11';";

			DateTime[] date = new DateTime[MysqlCount()];

			//Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

				//Read the data and store them in the list
				for (int i = 0; dataReader.Read(); i++)
				{
					date[i] = Convert.ToDateTime(dataReader["ow_date"]);
				}

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
				return date;
            }
            else
            {
				return date;
            }
        }

		public float[] MysqlSelectTemperature()
        {
			string query = "SELECT * FROM odintsova_street WHERE DATE(ow_date) = '2015-01-11';";

			float[] temperature = new float[MysqlCount()];

			//Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

				//Read the data and store them in the list
				for (int i = 0; dataReader.Read(); i++)
				{
					temperature[i] = Convert.ToSingle(dataReader["ow_val"]);
				}

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
				return temperature;
            }
            else
            {
				return temperature;
            }
        }

		public bool MysqlSelect(int count, DateTime[] date, float[] temperature)
		{
			string query = "SELECT * FROM odintsova_street WHERE DATE(ow_date) = '2015-01-11';";
			bool state = true;

			//Open connection
			if (this.OpenConnection() == true)
			{
				//Create Command
				MySqlCommand cmd = new MySqlCommand(query, connection);
				//Create a data reader and Execute the command
				MySqlDataReader dataReader = cmd.ExecuteReader();

				//Read the data and store them in the list
				for (int i = 0; dataReader.Read(); i++)
				{
					date[i] = Convert.ToDateTime(dataReader["ow_date"]);
					temperature[i] = Convert.ToSingle(dataReader["ow_val"]);
				}

				//close Data Reader
				dataReader.Close();

				//close Connection
				this.CloseConnection();

				//return list to be displayed
				return state;
			}
			else
			{
				state = false;
				return state;
			}
		}

        //Count statement
        public int MysqlCount()
        {
			string query = "SELECT Count(*) FROM odintsova_street WHERE DATE(ow_date) = '2015-01-11';";
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
	}
}
