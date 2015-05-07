using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TempViewer.util
{
	class ConfigFile
	{
		private static string pathToConf;

		public StreamReader openStreamReader (String pathToFile)
		{
			pathToConf = pathToFile;
			StreamReader stRead = null;

			try
			{
				stRead = new StreamReader(pathToConf);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			return stRead;
		}

		public void closeStreamReader (StreamReader stRead)
		{
			stRead.Dispose();
		}

		//public String getNewLine(StreamReader streamReader)
		//{	
		//    return streamReader.ReadLine();			
		//}

        public String[] getArrayStrings()
        {
            string[] lines = File.ReadAllLines(this.getPathToConf());
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
