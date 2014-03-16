using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace kliens
{
    class Program
    {
        static int portSzam = 6666;
        static string ipCim = "127.0.0.1";

        static void Main(string[] args) {
            try {
                IPAddress ip = IPAddress.Parse(ipCim);
                TcpClient client = new TcpClient();
                Console.WriteLine("Kapcsolódás... {0}:{1}", ip.ToString(), portSzam);
                client.Connect(ip, portSzam);
                StreamReader reader = new StreamReader(client.GetStream(), Encoding.UTF8);
                StreamWriter writer = new StreamWriter(client.GetStream(), Encoding.UTF8);
                string messageFromServer = reader.ReadLine();
                Console.WriteLine(messageFromServer);

                while (true) {
                    Console.ResetColor();
                    Console.WriteLine("Utasításra várok...");
                    string utasitas = Console.ReadLine();
                    writer.WriteLine(utasitas);
                    writer.Flush();
                    string response = reader.ReadLine();
                    if (response == "OK") {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(response);
                    }
                    else if(response.StartsWith("ERR")){
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(response);
                    }

                }


            }
            catch (Exception e) {
                Console.WriteLine("Hiba lépett fel:\n {0}", e);
            }

            Console.ReadLine();
        }
    }
}
