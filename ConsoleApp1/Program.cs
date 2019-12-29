using Cowboy.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
            Random m = new Random(1);
            TcpSocketClient client = new TcpSocketClient(IPAddress.Parse("127.0.0.1"), 22222);
            client.Connect();
            while (true)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Data>>#");
                for (int i = 0; i < 9; i++)
                {
                    sb.Append(m.Next(1024).ToString());
                    sb.Append(",");
                }
                sb.Append(m.Next(1024).ToString());
                sb.Append("#\r\n");
                client.Send(Encoding.UTF8.GetBytes(sb.ToString()));
                Console.Write(sb);
                Thread.Sleep(100);
            }
        }
    }
}
