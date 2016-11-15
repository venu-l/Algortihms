using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ClientServer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args != null && args.Length == 1)
            {
                if (args[0] == "Server")
                {
                    Console.WriteLine("Initiating Server Process...");
                    new Server();
                }
                else if (args[0] == "Client")
                {
                    Console.WriteLine("Initiating Client Process...");
                    new Client();
                }
            }
            else
            {
                DataItem[] items = new DataItem[2];
                items[0] = new DataItem() { x = 10, y = 20 };
                items[1] = new DataItem() { x = 10, y = 30 };

                byte[] binary = ObjectToByteArray(items);

                Object x = ByteArrayToObject(binary);

                DataItem[] casted = x as DataItem[];

                Console.WriteLine("Supply a Valid Argument Dude!");
            }
        }

        static byte[] ObjectToByteArray(object[] obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        static Object ByteArrayToObject(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);
            return obj;
        }
    }

    [Serializable]
    class DataItem
    {
        public int x;

        public int y;
    }
}
