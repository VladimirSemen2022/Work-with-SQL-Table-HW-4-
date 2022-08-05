using System;
using System.IO;
using System.Text.Json;
using Work_with_SQL_Table__HW_4_.Controller;

namespace Work_with_SQL_Table__HW_4_
{
    class Program
    {
        static void Main(string[] args)
        {
            //Создание строки-подключения к базе SQL используя параметры, сохранненые в файле формата JSON где-то на диске пользователя
            
            ConnectionController controller = new ConnectionController(@"D:\DBSetting.json");
            controller.Download();

            //Создание подключения типа Singleton через класс Link используя созданную из файла строку подключения
            Link newLink = Link.GetInstance(controller.defaultsetting);

            //Чтение данных из БД после подключения и вывод их на экран
            //ObjectLog[] Table1 = newLink.ReadAndShow(true);
            newLink.ReadAndShow(true);

        }
    }
}
