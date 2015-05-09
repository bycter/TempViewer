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
		//private static string pathToConf;
        private ConfigFileMethods cfm;

        public ConnectionProperties(string pathToConfigFile)
        {
            InitializeComponent();

            cfm = ConfigFileMethodsCreator.getConfigFileMethods(pathToConfigFile);
            if (cfm == null)
            {
                Messages.errorMessage("Объект класса ConfigFileMethods не создан", "ConnectionProperties.Init");
                this.Close();
            }
        }

        
        private TextBox[] textBoxs = new TextBox[4];
        
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
            string[] confFileLines = null;

            if (cfm.isExist())
            {
                try
                {
                    confFileLines = cfm.getArrayStrings();
                }
                catch (Exception ex)
                {
                    Messages.errorMessage(ex.Message);
                    return;
                }

                if (confFileLines == null)
                {
                    Messages.errorMessage("confFileLines == null", "ConnectionProperties.fillingForm");
                    //this.Close();
                    return;
                }

                if (confFileLines.Length == 0 || confFileLines.Length < obj.Length)
                {
                    Messages.errorMessage("Файл пустой либо указаны не все параметры", "ConnectionProperties.fillingForm");
                    //this.Close();
                    return;
                }

                int k = 0;
                foreach (TextBox i in obj)
                {
                    i.Text = confFileLines[k];
                    k++;
                }
            }
            else
            {
                Messages.errorMessage("fillingForm: cfm.isExist() = false");
            }
        }
        private void btWriteToConf_Click(object sender, EventArgs e)
        {
            String[] data = new String[textBoxs.Length];
            int k = 0;
            foreach (TextBox i in textBoxs)
            {
                if (i.Text == "")
                {
                    Messages.stopMessage("Одно или несколько полей не заполнены!");
                    return;
                }

                data[k] = i.Text;
                k++;
            }
            try
            {
                cfm.writeToConfigFile(data);
            }
            catch (Exception ex)
            {
                Messages.errorMessage(ex.Message);
                return;
            }
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
	}
}
