using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;


namespace TempViewer.util
{
	class ConfigFileMethods
	{
		private string pathToConf;

        private int linesLength;
        private string[] lines = null;
        //StreamReader stRead = null;
        public bool isExist()
        {
            if (File.Exists(pathToConf))
            {                
                return true;
            }

            Messages.errorMessage("Config file does not exist.", "ConfigFileMethods.isExist");
            return false;
        }

        public String[] getArrayStrings()
        {
            if (pathToConf != null && isExist())
            {
                try
                {
                    lines = File.ReadAllLines(this.getPathToConf());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return lines;
        }

        public int getArrayStringsLength()
        {
            if (getArrayStrings() == null)
            {
                return 0;
            }
            return getArrayStrings().Length;
        }
        public void writeToConfigFile(String[] data)
        {
            if (pathToConf != null && isExist())
            {
                try
                {
                    File.WriteAllLines(pathToConf, data);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
		
		public string getPathToConf()
		{
			return pathToConf;
		}

		public void setPathToConf(String pathToFile)
		{
			pathToConf = pathToFile;
		}

        //public StreamReader openStreamReader()
        //{
        //    try
        //    {
        //        this.stRead = new StreamReader(this.getPathToConf());
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //    return stRead;
        //}

        //public void closeStreamReader()
        //{
        //    this.stRead.Dispose();
        //}
	}
}
