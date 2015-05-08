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
		private static string pathToConf;

        StreamReader stRead = null;
        public StreamReader openStreamReader ()
		{
			try
			{
				this.stRead = new StreamReader(this.getPathToConf());
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			return stRead;
		}

		public void closeStreamReader ()
		{
			this.stRead.Dispose();
		}
        
        public String[] getArrayStrings()
        {
            string[] lines = File.ReadAllLines(this.getPathToConf());
            return lines;
        }

        public int getArrayStringsLength()
        {
            int lines = File.ReadAllLines(this.getPathToConf()).Length;
            return lines;
        }
        public void writeToConfigFile(String[] data)
        {
            File.WriteAllLines(pathToConf, data);
        }
		
		public string getPathToConf()
		{
			return pathToConf;
		}

		public void setPathToConf(String pathToFile)
		{
			pathToConf = pathToFile;
		}
	}
}
