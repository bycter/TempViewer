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
//using System.r


namespace TempViewer
{
	public partial class MainForm : Form
	{
		private MySqlConnection connection;

		public string pathToConf = "d:\\connection.txt";
		
		public string server;
		private string database;
		private string uid;
		private string password;

		public DateTime[] date;
		public string[] dateString;
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
		private double Step, Offset;

		Chart chart;

		public MainForm()
		{
			InitializeComponent();

			txbTableTarget.Text = "odintsova_street";
			txbDateTarget.Text = "2015-01-19";
			txbStep.Text = "30";
			txbOffset.Text = "0";
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

			//label1.Text = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + "********" + ";";
			//label2.Text = "SELECT * FROM odintsova_street WHERE DATE(ow_date) = '2015-01-11';";
		}

		private void btnConnectDB_Click(object sender, EventArgs e)
		{
			if (OpenConnection())
			{
				MessageBox.Show("Connection open.");
			}
			if (!CloseConnection())
			{
				//label2.Text = "Connection NOT close.";
			}
			else
			{
				//label2.Text = "Connection close.";
			}
		}

		private void btnViewTable_Click(object sender, EventArgs e)
		{
			int tableCount = 0;
            Random rand = new Random();

			dateTarget = txbDateTarget.Text;
			tableTarget = txbTableTarget.Text;

			Step = Convert.ToDouble(txbStep.Text);
			Offset = Convert.ToDouble(txbOffset.Text);

			if (dateTarget == "" || tableTarget == "")
			{
				MessageBox.Show("Проверьте название таблицы или дату");
			}

			if ((tableCount = MysqlCount()) == -1)
			{
				MessageBox.Show("MysqlCount return -1");
			}
            tableCount = 240;
			//YMax = MaxMinValueY(1);
			//YMin = MaxMinValueY(0);
			if (YMax == -300 || YMin == -300)
			{
				MessageBox.Show("MaxMinValueY() return -300");
			}
			//label1.Text = Convert.ToString(YMax);
			date = new DateTime[tableCount];
			temperature = new float[tableCount];

			if (temperature[0] == 0)
			{
				MysqlSelect(tableCount, date, temperature);
				//label1.Text = "temp is 0";
			}

			ConvertDateToHourMinute();
			double[] test = new double[tableCount];
			for (int i = 0; i < test.Length; i++)
			{
				test[i] = i;
			}

			//for (int i = 0; i < temperature.Length; i++)
			//{
			//    temperature[i] = rand.Next(-10, 30);
			//}

			//label1.Text = dateString[0];
			// Создаём элемент управления
			CreateChart();

			//label1.Text = dateString[100];
			//label2.Text = date[100].Hour.ToString() + ":" + date[100].Minute.ToString();

			//// Добавляем вычисленные значения в графики
			chart.Series[0].Points.DataBindXY(test, temperature);
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


		private void CreateChart()
		{
			// Создаём новый элемент управления Chart
			if (chart != null)
			{
				chart.Dispose();
				//label2.Text = "chart is not null";
			}

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
			//area.AxisX.Minimum = 0;
			//area.AxisX.Maximum = XMax;
			//area.AxisY.Minimum = YMin;
			//area.AxisY.Maximum = YMax;

			// Определяем шаг сетки
			area.AxisX.MajorGrid.Interval = Step;
			area.AxisX.MajorTickMark.Interval = Step;
			//area.AxisX.Interval = Step;
			area.AxisX.IsStartedFromZero = true;
			area.AxisX.IntervalOffset = Offset;
			//label2.Text = Convert.ToString(area.AxisX.MajorGrid.IntervalType);
			// Добавляем область в диаграмму
			chart.ChartAreas.Add(area);

			// Создаём объект для первого графика
			Series series1 = new Series();
			// Ссылаемся на область для построения графика
			series1.ChartArea = "myGraph";
			// Задаём тип графика - сплайны
			//series1.ChartType = SeriesChartType.Bubble;
			series1.ChartType = SeriesChartType.Spline;
			// Указываем ширину линии графика
			series1.BorderWidth = 3;
			// Название графика для отображения в легенде
			series1.LegendText = "street";
			// Добавляем в список графиков диаграммы
			chart.Series.Add(series1);

			//// Создаём легенду, которая будет показывать названия
			//Legend legend = new Legend();
			//chart.Legends.Add(legend);
		}

		private void ConvertDateToHourMinute()
		{
			dateString = new string[date.Count()];
			string hour, minute;
			int k = 0;
			foreach (DateTime i in date)
			{
				hour = i.Hour.ToString();
				minute = i.Minute.ToString();

				if (i.Hour < 10)
				{
					hour = "0" + hour;
				}
				if (i.Minute < 10)
				{
					minute = "0" + minute;
				}
				dateString[k] = hour + ":" + minute;
				k++;
			}
		}

		private void btConnProperties_Click(object sender, EventArgs e)
		{
			ConnectionProperties connProp = new ConnectionProperties(server);
			connProp.ShowDialog();
            
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void выходToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			var MBox = MessageBox.Show("Вы действительно хотите выйти из программы?",
				"Выход из программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (MBox == DialogResult.No) e.Cancel = true;
			if (MBox == DialogResult.Yes) return;
		}

		private void настройкиПодключенияToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ConnectionProperties connProperties = new ConnectionProperties(pathToConf);
			connProperties.Show();
		}
	}
}
