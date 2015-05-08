using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TempViewer.util
{
	class ConfigFileMethodsCreator
	{
        public static ConfigFileMethods getConfigFileMethods(string pathToConf)
		{
			ConfigFileMethods cfm = new ConfigFileMethods();
            cfm.setPathToConf(pathToConf);
            return cfm;
		}
	}
}
