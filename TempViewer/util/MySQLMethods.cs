using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TempViewer.util
{
	class MySQLMethods
	{
        private string configMySQLConnection;
		private string[] confSettingsArray;

		public MySQLMethods()
        {			
        }

        enum enumConnString { server, login, password, database }

        private MySqlConnection connectionDatabase;

        
        private string connectionString;
		private string selectString;

        public DateTime[] date;
        public string[] dateString;
        public float[] temperature;

        private bool buildConnectionString()
        {
			if (!getConfSettingsArray())
			{
				MessageBox.Show("buildConnectionString(): getConfSettingsArray() завершился с ошибкой.");
				return false;
			}

			if (confSettingsArray == null)
			{
				return false;
			}

			connectionString = "SERVER=" + confSettingsArray[(int)enumConnString.server] + ";"
				+ "DATABASE=" + confSettingsArray[(int)enumConnString.database] + ";"
				+ "UID=" + confSettingsArray[(int)enumConnString.login] + ";"
				+ "PASSWORD=" + confSettingsArray[(int)enumConnString.password] + ";";

            return true;
        }

		private bool getConfSettingsArray()
		{
			if (configMySQLConnection == null)
			{
				MessageBox.Show("MySQLMethods: Не указан путь к файлу конфигурации.");
				return false;
			}

			ConfigFileMethods cfm = ConfigFileMethodsCreator.getConfigFileMethods(configMySQLConnection);

			if (cfm == null)
			{
				MessageBox.Show("MySQLMethods: Объект класса ConfigFileMethods не создан.");
				return false;
			}

			confSettingsArray = new string[cfm.getArrayStringsLength()];
			confSettingsArray = cfm.getArrayStrings();

			return true;
		}

        
        public bool OpenConnection()
        {
            if (buildConnectionString())
            {
                connectionDatabase = new MySqlConnection(connectionString);
            }

            if (connectionDatabase != null)
            {
                try
                {
                    connectionDatabase.Open();
                    return true;
                }
                catch (MySqlException ex)
                {
                    string errorMessage;

                    //When handling errors, you can your application's response based 
                    //on the error number.
                    //The two most common error numbers when connecting are as follows:
                    //1042: Cannot connect to server.
                    //0: Invalid user name and/or password.

                    errorMessage = "Error: " + ex.Number + ". ";
                    switch (ex.Number)
                    {
                        case 0:
                            errorMessage += "Invalid username/password/database, please try again";
                            break;

                        case 1042:
                            errorMessage += "Message: Can't get hostname for your address. Contact administrator";
                            break;

                        case 1045:
                            errorMessage += "Invalid username/password, please try again";
                            break;

                        default:
                            errorMessage += "Something wrong...";
                            break;
                    }
                    MessageBox.Show(errorMessage);
                    return false;
                }                
            }
            return false;
        }

        //Close connection
        public bool CloseConnection()
        {
			if (connectionDatabase != null)
			{
				try
				{
					connectionDatabase.Close();
					return true;
				}
				catch (MySqlException ex)
				{
					MessageBox.Show(ex.Message);
					return false;
				}
			}
			return false;
        }



        //Типы методов для выполнения запросов к базе Mysql:
        //1. ExecuteNonQuery: используется для выполнения команды,
        //которые не вернут какие-либо данные, например Insert, update or delete.
        //2. ExecuteReader: используется для выполнения комманды,
        //которая будет возвращать 0 или более записей, например Select.
        //3. ExecuteScalar: используется для выполнения команды,
        //которая будет возвращать только 1 значение, например Select Count(*).


        //Select statement
		//public void MysqlSelect(int count, DateTime[] date, float[] temperature)
		//{
		//    // return: 0 - OK; 1 - dateTarget or tableTarget is NULL; 2 - connection NOT open

		//    string query = "SELECT * FROM " + tableTarget + " WHERE DATE(ow_date) = '" + dateTarget + "';";

		//    //Open connection
		//    if (this.OpenConnection() == true)
		//    {
		//        //Create Command
		//        MySqlCommand cmd = new MySqlCommand(query, connection);
		//        //Create a data reader and Execute the command
		//        MySqlDataReader dataReader = cmd.ExecuteReader();

		//        //Read the data and store them in the list
		//        for (int i = 0; dataReader.Read(); i++)
		//        {
		//            date[i] = Convert.ToDateTime(dataReader["ow_date"]);
		//            temperature[i] = Convert.ToSingle(dataReader["ow_val"]);
		//        }

		//        //close Data Reader
		//        dataReader.Close();

		//        //close Connection
		//        this.CloseConnection();

		//        //return list to be displayed
		//        //return 0;
		//    }
		//    else
		//    {
		//        //return 2;
		//    }
		//}

		////Count statement
		//public int MysqlCount()
		//{
		//    string query = "SELECT Count(*) FROM " + tableTarget + " WHERE DATE(ow_date) = '" + dateTarget + "';";
		//    int Count = -1;

		//    //Open Connection
		//    if (this.OpenConnection() == true)
		//    {
		//        //Create Mysql Command
		//        MySqlCommand cmd = new MySqlCommand(query, connection);

		//        //ExecuteScalar will return one value
		//        Count = int.Parse(cmd.ExecuteScalar() + "");

		//        //close Connection
		//        this.CloseConnection();

		//        return Count;
		//    }
		//    else
		//    {
		//        return Count;
		//    }
        //}



        public string getConfigMySQLConnection()
        {
            return this.configMySQLConnection;
        }

        public void setConfigMySQLConnection(String configConn)
        {
            configMySQLConnection = configConn;
        }
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
