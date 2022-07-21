using System;

namespace Work_with_SQL_Table__HW_4_
{
    class Program
    {
        static void Main(string[] args)
        {
            //Создание класса Singleton (одиночка) для реализации подключения к базе данных SQL с наличием методов чтения, удаления, добавления
            SQLTable SQL_obj = SQLTable.GetInstance("Server=DESKTOP-MV43C0T;Database=LogFile;Trusted_Connection=True;");
            
            ObjectLog[] Table1 = SQL_obj.ReadAndShow(true);
            SQL_obj.Delete("Action", "moves");
            SQL_obj.ReadAndShow(true);
            SQL_obj.Add(Table1);
            SQL_obj.ReadAndShow(true);
        }
    }
}
