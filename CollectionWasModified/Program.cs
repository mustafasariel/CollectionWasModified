using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace CollectionWasModified
{
    class Program
    {
       // static Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
        static ConcurrentDictionary<int, int> keyValuePairs = new ConcurrentDictionary<int, int>();
        static void Main(string[] args)
        {

            try
            {
                Thread threadWrite = new Thread(new ParameterizedThreadStart(processWrite));

                threadWrite.Start();


                Thread threadMore = new Thread(new ParameterizedThreadStart(processStartMore));
                threadMore.Start();

                Thread threadLess = new Thread(new ParameterizedThreadStart(processLess));
                 threadLess.Start();

               

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void processWrite(object obj)
        {
            try
            {

                while (true)
                {

                    foreach (var item in keyValuePairs)
                    {
                        Console.WriteLine($"{item.Key} {item.Value}");
                        Thread.Sleep(100);
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private static void processLess(object obj)
        {
            try
            {
                Less();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private static void processStartMore(object obj)
        {
            try
            {
                More();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void More()
        {
            try
            {

                while (true)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        keyValuePairs[i] = 5;
                    }
                    Thread.Sleep(100);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private static void Less()
        {
            while (true)
            {

                for (int i = 0; i < 10; i++)
                {
                    var number = FakeData.NumberData.GetNumber(0, 100);
                    keyValuePairs[i] = 1;
                }
                Thread.Sleep(100);

            }
        }
    }
}
