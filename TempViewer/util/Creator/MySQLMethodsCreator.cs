using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TempViewer.util.Creator
{
    class MySQLMethodsCreator
    {
        public static MySQLMethods getMySQLMethods(string configMySQLConnection)
        {
            MySQLMethods mysqlMethods = new MySQLMethods();
            mysqlMethods.setConfigMySQLConnection(configMySQLConnection);
            return mysqlMethods;
        }
    }
}
