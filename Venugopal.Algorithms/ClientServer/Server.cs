/*   Server Program    */

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace ClientServer
{
    public class Server
    {
        public Server()
        {
            Code();
        }

        private void Code()
        {
            try
            {
                IPAddress ipAd = IPAddress.Parse("127.0.0.1");
                // use local m/c IP address, and 
                // use the same in the client

                /* Initializes the Listener */
                TcpListener myList = new TcpListener(ipAd, 8001);

                /* Start Listeneting at the specified port */
                myList.Start();

                Console.WriteLine("The server is running at port 8001...");
                Console.WriteLine("The local End point is  :" +
                                  myList.LocalEndpoint);
                Console.WriteLine("Waiting for a connection.....");

                Socket s = myList.AcceptSocket();
                Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);

                ASCIIEncoding asen = new ASCIIEncoding();

                while (true)
                {
                    byte[] b = new byte[100];
                    int k = s.Receive(b);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("===============================================================");
                    Console.ForegroundColor = ConsoleColor.White;

                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < k; i++)
                        builder.Append(Convert.ToChar(b[i]));

                    Console.WriteLine(string.Format("Recieved Item - {0}", builder.ToString()));
                        
                    s.Send(asen.GetBytes(string.Format("ACK for {0}", builder.ToString())));
                    Console.WriteLine(string.Format("Sent ACK for {0}", builder.ToString()));
                }

                /* clean up */
                s.Close();
                myList.Stop();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        }

    }
}