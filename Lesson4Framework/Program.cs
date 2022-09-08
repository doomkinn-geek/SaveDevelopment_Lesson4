﻿using System;
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

            Console.ReadKey();
        }
    }
}
