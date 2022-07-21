using System;
using System.Data.SqlClient;

namespace Work_with_SQL_Table__HW_4_
{
    public sealed class SQLTable
    {
        static string connect;
        public SqlConnection connection { get; private set; }

        private SQLTable()     //Создание подключения к базе SQL
        {
            connection = new SqlConnection(connect);
            connection.Open();      //Открытие соединения с базой SQL
        }

        private static SQLTable _instance;     //Внутренняя переменная класса, хранящая соединение с базой 
        public static SQLTable GetInstance(string connStr)     //Метод создания подключения к базе SQL
        {
            if (_instance == null)
            {
                connect = connStr;
                _instance = new SQLTable();
            }
            return _instance;
        }

        public ObjectLog[] ReadAndShow (bool show)  //Если параметр show при обращении к методу равен true то кроме чтения базы, данные также выведутся на экран
        {
            ObjectLog[] Table = new ObjectLog[1];
            using (SqlCommand cmd = new SqlCommand("SELECT TOP (1000) [id],[Name],[SoldierType],[WeaponType],[HP],[Action],[DateTime]FROM[LogFile].[dbo].[Log]", connection))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    Table[i] = new ObjectLog(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetString(5), reader.GetDateTime(6));
                    Array.Resize(ref Table, Table.Length + 1);
                    if (show) Console.WriteLine(Table[i].ToString());
                    i++;
                }
                reader.Close();
                if (show) Console.WriteLine($"From the table read {i} rows");
            }
            return Table;
        }

        public void Add(ObjectLog Table)      //Метод записи данных в открытую базу SQL. Данные передаются в виде единичного объекта класса ObjectLog
        {
            if (Table != null)
            {
                string sqlText = String.Format($@"INSERT INTO [dbo].[Log]([Name],[SoldierType],[WeaponType],[HP],[Action],[DateTime]) VALUES ('{Table.Name}','{Table.Type}', '{Table.Weapone}', {Table.HP}, '{Table.Action}', '{Table.DateTime.ToString("yyyy-MM-dd HH:mm:ss")}');");
                SqlCommand command = new SqlCommand(sqlText, connection);
                Console.WriteLine($"To the table Log added {command.ExecuteNonQuery()} row");
            }
        }

        public void Add(ObjectLog [] Table)      //Метод записи данных в открытую базу SQL. Данные передаются в виде массива данных класса ObjectLog
        {
            if (Table != null)
            {
                int i = 0;
                foreach (ObjectLog item in Table)
                {
                    if (item!=null)
                    {
                        string sqlText = String.Format($@"INSERT INTO [dbo].[Log]([Name],[SoldierType],[WeaponType],[HP],[Action],[DateTime]) VALUES ('{item.Name}','{item.Type}', '{item.Weapone}', {item.HP}, '{item.Action}', '{item.DateTime.ToString("yyyy-MM-dd HH:mm:ss")}');");
                        SqlCommand command = new SqlCommand(sqlText, connection);
                        i+=command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine($"To the table Log added {i} rows");
            }
        }

        public void Delete(int col)         //Удаление указанного в параметре col количества строк
        {
            if (ReadAndShow(false).Length > 1)
            {
                string sqlText = $"DELETE TOP ({col}) FROM [dbo].[Log]";
                SqlCommand command = new SqlCommand(sqlText, connection);
                Console.WriteLine($"From table Log deleted {command.ExecuteNonQuery()} rows");

            }
        }

        public void Delete(string nameCol, string value)        //Удаление строк с указанным в параметрах значением value для столбца с именем nameCol
        {
            if (ReadAndShow(false).Length > 1)
            {
                string sqlText = $"DELETE FROM [dbo].[Log] WHERE {nameCol}='{value}'";
                SqlCommand command = new SqlCommand(sqlText, connection);
                Console.WriteLine($"In the column {nameCol}={value} the table Log was found and deleted {command.ExecuteNonQuery()} rows");
            }
        }
    }
}
