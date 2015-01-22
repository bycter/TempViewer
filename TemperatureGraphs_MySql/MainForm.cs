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

		string dateTarget = "";
		string tableTarget = "";

		/// <summary>
		/// Левая граница графика
		/// </summary>
		private DateTime XMin;
		private double YMin = 0;

		/// <summary>
		/// Правая граница графика
		/// </summary>
		private DateTime XMax;
		private double YMax = 0;

		/// <summary>
		/// Шаг графика
		/// </summary>
		private double Step = 1;

		Chart chart;

		public MainForm()
		{
			InitializeComponent();

			txbTableTarget.Text = "odintsova_street";
			txbDateTarget.Text = "2015-01-19";
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

			dateTarget = txbDateTarget.Text;
			tableTarget = txbTableTarget.Text;

			if (dateTarget == "" || tableTarget == "")
			{
				MessageBox.Show("Проверьте название таблицы или дату");
			}

			if ((tableCount = MysqlCount()) == -1)
			{
				MessageBox.Show("MysqlCount return -1");
			}

			//YMax = MaxMinValueY(1);
			//YMin = MaxMinValueY(0);
			if (YMax == -300 || YMin == -300)
			{
				MessageBox.Show("MaxMinValueY() return -300");
			}
			//label1.Text = Convert.ToString(YMax);
			date = new DateTime[tableCount];
			temperature = new float[tableCount];

			MysqlSelect(tableCount, date, temperature);

			// Создаём элемент управления
			CreateChart();

			label2.Text = date[100].Hour.ToString() + ":" + date[100].Minute.ToString();

			//// Добавляем вычисленные значения в графики
			chart.Series[0].Points.DataBindXY(date, temperature);
			//chart.Series[1].Points.DataBindXY(x, y2);
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

		public void MysqlSelect(int count, DateTime[] date, float[] temperature)
		{
			// return: 0 - OK; 1 - dateTarget or tableTarget is NULL; 2 - connection NOT open

			string query = "SELECT * FROM " + tableTarget + " WHERE DATE(ow_date) = '" + dateTarget + "';";

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
				//return 0;
			}
			else
			{
				//return 2;
			}
		}

	//Count statement
	public int MysqlCount()
	{
		string query = "SELECT Count(*) FROM " + tableTarget + " WHERE DATE(ow_date) = '" + dateTarget + "';";
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

		public double MaxMinValueY(int MinMax)
		{
			string MinMaxString = "MIN";
			double returnValue;

			if (MinMax == 1)
			{
				MinMaxString = "MAX";
			}

			string query = "SELECT " + MinMaxString + "(ow_val) FROM " + tableTarget + " WHERE DATE(ow_date) = '" + dateTarget + "';";

			label2.Text = query;
			//Open Connection
			if (this.OpenConnection() == true)
			{
				//Create Mysql Command
				MySqlCommand cmd = new MySqlCommand(query, connection);

				//ExecuteScalar will return one value
				returnValue = double.Parse(cmd.ExecuteScalar() + "");

				//close Connection
				this.CloseConnection();

				if (MinMax == 1)
				{
					return returnValue + 10;
				}
				else
				{
					return returnValue - 10;
				}
			}
			else
			{
				return -300;
			}
		}

		private void CreateChart()
		{
			// Создаём новый элемент управления Chart
			chart = new Chart();
			// Помещаем его на форму
			chart.Parent = this;
			// Задаём размеры элемента
			chart.SetBounds(10, 10, ClientSize.Width - 20,
							ClientSize.Height - 70);

			// Создаём новую область для построения графика
			ChartArea area = new ChartArea();
			// Даём ей имя (чтобы потом добавлять графики)
			area.Name = "myGraph";
			// Задаём левую и правую границы оси X
			//area.AxisX.Minimum = XMin;
			//area.AxisX.Maximum = XMax;
			//area.AxisY.Minimum = YMin;
			//area.AxisY.Maximum = YMax;

			// Определяем шаг сетки
			area.AxisX.MajorGrid.Interval = Step;
			// Добавляем область в диаграмму
			chart.ChartAreas.Add(area);

			// Создаём объект для первого графика
			Series series1 = new Series();
			// Ссылаемся на область для построения графика
			series1.ChartArea = "myGraph";
			// Задаём тип графика - сплайны
			series1.ChartType = SeriesChartType.Spline;
			// Указываем ширину линии графика
			series1.BorderWidth = 3;
			// Название графика для отображения в легенде
			series1.LegendText = "sin(x)";
			// Добавляем в список графиков диаграммы
			chart.Series.Add(series1);
			// Аналогичные действия для второго графика
			Series series2 = new Series();
			series2.ChartArea = "myGraph";
			series2.ChartType = SeriesChartType.Spline;
			series2.BorderWidth = 3;
			series2.LegendText = "cos(x)";
			chart.Series.Add(series2);


			//// Создаём легенду, которая будет показывать названия
			//Legend legend = new Legend();
			//chart.Legends.Add(legend);
		}

		private void ConvertDateToHourMinute()
		{
			foreach (DateTime i in date)
			{

			}
		}
	}
}
