using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TempViewer.util;
using TempViewer;

namespace TempViewer
{
	public partial class ConnectionProperties : Form
	{
		private string pathToConf = null;
        private TextBox[] textBoxs = new TextBox[4];
        ConfigFileMethods configFile = ReadConfFileCreator.getReadConfFile();
		
        //public ConnectionProperties()
        //{
        //    InitializeComponent();
			
        //}
		
		public ConnectionProperties(string pathToConfigFile)
		{
			InitializeComponent();
			this.pathToConf = pathToConfigFile;

		}

		private void ConnectionProperties_Load(object sender, EventArgs e)
		{
            textBoxs[0] = txbAddress;
            textBoxs[1] = txbLogin;
            textBoxs[2] = txbPassword;
            textBoxs[3] = txbDatabase;

            fillingForm(textBoxs);
		}

		public void fillingForm(TextBox[] obj)
		{
            if (pathToConf == null)
            {
                MessageBox.Show("Не определен путь к файлу!");
                return;
            }

            
            configFile.setPathToConf(pathToConf);

            string[] confFile = configFile.getArrayStrings();

            if (confFile.Length != obj.Length)
            {
                MessageBox.Show("Количество строк в файле не равно количеству текстбоксов!");
                return;
            }

            int k = 0;
            foreach (TextBox i in obj)
            {
                i.Text = confFile[k];
                k++;
            }
        }
        private void btWriteToConf_Click(object sender, EventArgs e)
        {
            String[] data = new String[textBoxs.Length];
            int k = 0;
            foreach (TextBox i in textBoxs)
            {
                data[k] = i.Text;
                k++;
            }
            configFile.writeToConfigFile(data);
        }       
	}
}
