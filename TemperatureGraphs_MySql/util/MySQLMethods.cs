using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TempViewer.util
{
	class MySQLMethods
	{
		private string connectionString;
		private string selectString;




		public string getConnectionString()
		{
			return this.connectionString;
		}

		public void setConnectionString(String connString)
		{
			this.connectionString = connString;
		}

		public string getselectString()
		{
			return this.selectString;
		}

		public void setselectString(String selectString)
		{
			this.selectString = selectString;
		}


	}
}
