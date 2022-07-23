using System;
using System.IO;

namespace Work_with_SQL_Table__HW_4_
{
    class Program
    {
        static void Main(string[] args)
        {
            //Создание класса Singleton (одиночка) для реализации подключения к базе данных SQL с наличием методов чтения, удаления, добавления
            //const string fileName = "Link.txt";
            //if (!File.Exists(fileName))
            //    File.WriteAllText(fileName, "Server=DESKTOP-MV43C0T;Database=LogFile;Trusted_Connection=True;");

            //string link = File.ReadAllText(fileName);
            //SQLTable.GetInstance(link);


            //Singleton класс с подключением к базе SQL из строки, сохраненной в файле
            //по умолчанию класс получает строку подключения из байла "Link.txt" или можно указать в параметрах
            //название или полный путь к файлу, хранящему строку подключения к SQL базе
            Link.GetInstance();

            //ObjectLog[] Table1 = Link.GetInstance().ReadAndShow(true);
            Link.GetInstance().ReadAndShow(true);
            Link.GetInstance().Delete("Name", "Ruf");
            Link.GetInstance().ReadAndShow(true);
            //Link.GetInstance().Add(Table1);
            //Link.GetInstance().ReadAndShow(true);
        }
    }
}
