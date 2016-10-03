/*       Client Program      */

using System;
using System.IO;
using System.Text;
using System.Net.Sockets;
using System.Collections.Generic;

namespace ClientServer
{
    public class Client
    {
        Queue<string> myItemsQueue = new Queue<string>();

        public Client()
        {
            Code();
        }

        private void Code()
        {
            try
            {
                TcpClient tcpclnt = new TcpClient();
                Console.WriteLine("Connecting.....");

                tcpclnt.Connect("127.0.0.1", 8001);
                // use the ipaddress as in the server program

                Console.WriteLine("Connected");
                Console.WriteLine("Enter the strings to be transmitted: ");
                Console.WriteLine("Simply hit Enter to close the Socket.");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("===============================================================");
                Console.ForegroundColor = ConsoleColor.White;

                using (Stream stm = tcpclnt.GetStream())
                {
                    ASCIIEncoding asen = new ASCIIEncoding();

                    string str;
                    while (!string.IsNullOrWhiteSpace((str = Console.ReadLine())))
                    {
                        byte[] ba = asen.GetBytes(str);
                        Console.WriteLine(string.Format("Sending - {0}", str));
                        stm.Write(ba, 0, ba.Length);

                        byte[] bb = new byte[100];
                        int k = stm.Read(bb, 0, 100);

                        StringBuilder builder = new StringBuilder();
                        for (int i = 0; i < k; i++)
                            builder.Append(Convert.ToChar(bb[i]));

                        Console.WriteLine(builder.ToString());

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("===============================================================");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    stm.Write(asen.GetBytes("END"), 0, 3);
                    tcpclnt.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        }
    }
}