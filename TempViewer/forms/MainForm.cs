using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TempViewer.util;
using TempViewer.util.Creator;


namespace TempViewer
{
	public partial class MainForm : Form
	{
		public string configMySQLConn = "d:\\connection.conf";
        //public string configMySQLConn = "z:\\temper\\connection.conf";
        public string configChart = "d:\\chart.conf";

        
        MySQLMethods mysqlMethods;
        ConnectionProperties connProperties;
		
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
			lbLog1.Text = configMySQLConn;
		}

		private void btnViewTable_Click(object sender, EventArgs e)
		{
            //int tableCount = 0;
            //Random rand = new Random();

            //dateTarget = txbDateTarget.Text;
            //tableTarget = txbTableTarget.Text;

            //Step = Convert.ToDouble(txbStep.Text);
            //Offset = Convert.ToDouble(txbOffset.Text);

            //if (dateTarget == "" || tableTarget == "")
            //{
            //    MessageBox.Show("Проверьте название таблицы или дату");
            //}

            //if ((tableCount = MysqlCount()) == -1)
            //{
            //    MessageBox.Show("MysqlCount return -1");
            //}
            //tableCount = 240;
            ////YMax = MaxMinValueY(1);
            ////YMin = MaxMinValueY(0);
            //if (YMax == -300 || YMin == -300)
            //{
            //    MessageBox.Show("MaxMinValueY() return -300");
            //}
            ////label1.Text = Convert.ToString(YMax);
            //date = new DateTime[tableCount];
            //temperature = new float[tableCount];

            //if (temperature[0] == 0)
            //{
            //    MysqlSelect(tableCount, date, temperature);
            //    //label1.Text = "temp is 0";
            //}

            ////ConvertDateToHourMinute();
            //double[] test = new double[tableCount];
            //for (int i = 0; i < test.Length; i++)
            //{
            //    test[i] = i;
            //}

            ////for (int i = 0; i < temperature.Length; i++)
            ////{
            ////    temperature[i] = rand.Next(-10, 30);
            ////}

            ////label1.Text = dateString[0];
            //// Создаём элемент управления
            //CreateChart();

            ////label1.Text = dateString[100];
            ////label2.Text = date[100].Hour.ToString() + ":" + date[100].Minute.ToString();

            ////// Добавляем вычисленные значения в графики
            //chart.Series[0].Points.DataBindXY(test, temperature);
            ////chart.Series[1].Points.DataBindXY(x, y2);
		}

        //private void CreateChart()
        //{
        //    // Создаём новый элемент управления Chart
        //    if (chart != null)
        //    {
        //        chart.Dispose();
        //        //label2.Text = "chart is not null";
        //    }

        //    chart = new Chart();
        //    // Помещаем его на форму
        //    chart.Parent = this;
        //    // Задаём размеры элемента
        //    chart.SetBounds(10, 10, ClientSize.Width - 20,
        //                    ClientSize.Height - 70);

        //    // Создаём новую область для построения графика
        //    ChartArea area = new ChartArea();
        //    // Даём ей имя (чтобы потом добавлять графики)
        //    area.Name = "myGraph";
        //    // Задаём левую и правую границы оси X
        //    //area.AxisX.Minimum = 0;
        //    //area.AxisX.Maximum = XMax;
        //    //area.AxisY.Minimum = YMin;
        //    //area.AxisY.Maximum = YMax;

        //    // Определяем шаг сетки
        //    area.AxisX.MajorGrid.Interval = Step;
        //    area.AxisX.MajorTickMark.Interval = Step;
        //    //area.AxisX.Interval = Step;
        //    area.AxisX.IsStartedFromZero = true;
        //    area.AxisX.IntervalOffset = Offset;
        //    //label2.Text = Convert.ToString(area.AxisX.MajorGrid.IntervalType);
        //    // Добавляем область в диаграмму
        //    chart.ChartAreas.Add(area);

        //    // Создаём объект для первого графика
        //    Series series1 = new Series();
        //    // Ссылаемся на область для построения графика
        //    series1.ChartArea = "myGraph";
        //    // Задаём тип графика - сплайны
        //    //series1.ChartType = SeriesChartType.Bubble;
        //    series1.ChartType = SeriesChartType.Spline;
        //    // Указываем ширину линии графика
        //    series1.BorderWidth = 3;
        //    // Название графика для отображения в легенде
        //    series1.LegendText = "street";
        //    // Добавляем в список графиков диаграммы
        //    chart.Series.Add(series1);

        //    //// Создаём легенду, которая будет показывать названия
        //    //Legend legend = new Legend();
        //    //chart.Legends.Add(legend);
        //}

		private void btConnProperties_Click(object sender, EventArgs e)
		{
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
			connProperties = new ConnectionProperties(configMySQLConn);
			connProperties.ShowDialog();
        }

        private void btConn_Click(object sender, EventArgs e)
        {
            mysqlMethods = MySQLMethodsCreator.getMySQLMethods(configMySQLConn);

            if (mysqlMethods.OpenConnection())
            {
                lbLog1.Text = "Conn Open OK";
            }
            else
            {
                lbLog1.Text = "Conn Open NOT";
            }

            if (mysqlMethods.CloseConnection())
            {
                lbLog2.Text = "Conn Close OK";
            }

        }

        private void btTest_Click(object sender, EventArgs e)
        {
            ConfigFileMethods cfm = ConfigFileMethodsCreator.getConfigFileMethods(configMySQLConn);

            try
            {
                lbTest2.Text = Convert.ToString(cfm.getArrayStringsLength());
            }
            catch (Exception ex)
            {
                Messages.errorMessage(ex.Message);
                //return;
            }
            
        }
	}
}
