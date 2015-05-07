using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TempViewer.util
{
	class ReadConfFileCreator
	{
		public ReadConfFileCreator()
		{
		}

		public static ConfigFileMethods getReadConfFile()
		{
			return new ConfigFileMethods();
		}
	}
}
