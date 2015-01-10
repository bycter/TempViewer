using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
			server = "10.8.0.10";
			uid = "smarthouse";
			password = "U4PD2cKIAs";
			database = "smarthouse";

			connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
			// connectionString = "SERVER=10.8.0.10;DATABASE=smarthouse;UID=smarthouse;PASSWORD=U4PD2cKIAs";
			connection = new MySqlConnection(connectionString);

			label1.Text = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + "********" + ";";
		}

		private void btConnectDB_Click(object sender, EventArgs e)
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

		private void btViewTable_Click(object sender, EventArgs e)
		{

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

		

		////Insert statement
		//public void Insert()
		//{
		//}

		////Update statement
		//public void Update()
		//{
		//}

		////Delete statement
		//public void Delete()
		//{
		//}

		////Select statement
		//public List<string>[] Select()
		//{
		//}

		////Count statement
		//public int Count()
		//{
		//}

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
