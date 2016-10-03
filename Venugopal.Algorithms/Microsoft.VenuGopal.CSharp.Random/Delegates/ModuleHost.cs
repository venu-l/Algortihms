using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace Microsoft.VenuGopal.CSharp.Random.Delegates
{
    public class ModuleHost : IModuleHost
    {
        public void PostOutputDataItems(DataItem item, ModuleHostCallback.DataItemAcknowledgementCallback acknowledgeCallback, object acknowledgementState)
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
                Console.Write("Enter the string to be transmitted : ");

                String str = Console.ReadLine();
                Stream stm = tcpclnt.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(str);
                Console.WriteLine("Transmitting.....");

                stm.Write(ba, 0, ba.Length);

                byte[] bb = new byte[100];
                int k = stm.Read(bb, 0, 100);

                for (int i = 0; i < k; i++)
                    Console.Write(Convert.ToChar(bb[i]));

                tcpclnt.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        }
    }
}