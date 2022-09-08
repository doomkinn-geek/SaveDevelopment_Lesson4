using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4Framework
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            Console.Title = Properties.Settings.Default.ApplicationNameDebug;
#else
            Console.Title = Properties.Settings.Default.ApplicationName;
#endif
            if(string.IsNullOrEmpty(Properties.Settings.Default.FIO) || Properties.Settings.Default.Age <= 0)
            {
                Console.Write("Введите ФИО: ");
                Properties.Settings.Default.FIO = Console.ReadLine();

                Console.Write("Ваш возраст: ");
                if(int.TryParse(Console.ReadLine(), out int age))
                {
                    Properties.Settings.Default.Age = age;
                }
                else
                {
                    Properties.Settings.Default.Age = 0;
                }
                Properties.Settings.Default.Save(); 
            }

            Console.WriteLine($"ФИО: {Properties.Settings.Default.FIO}");
            Console.WriteLine($"Возраст: {Properties.Settings.Default.Age}");

            //c:\Users\root\AppData\Local\Lesson4Framework\Lesson4Framework.exe_Url_zxpjkmcefsvbompgprvb00r2l4xddtpv\1.0.0.0\

            ConnectionString connectionString1 = new ConnectionString
            {
                DatabaseName = "Database1",
                Host = "localhost",
                Password = "12345",
                UserName = "User1"
            };

            ConnectionString connectionString2 = new ConnectionString
            {
                DatabaseName = "Database2",
                Host = "localhost",
                Password = "54321",
                UserName = "User2"
            };

            List<ConnectionString> connections = new List<ConnectionString>();
            connections.Add(connectionString1);
            connections.Add(connectionString2);
            CacheProvider cacheProvider = new CacheProvider();
            cacheProvider.CacheConnections(connections);

            CacheProvider cacheProvider2 = new CacheProvider();
            List<ConnectionString> connections2 = cacheProvider2.GetConnectionsFromCache();

            foreach (var connection in connections2)
            {
                Console.WriteLine($"{connection.Host} {connection.DatabaseName} {connection.UserName} {connection.Password}");
            }

            Console.ReadKey();
        }
    }
}
