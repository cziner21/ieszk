using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace adokVeszekKliens2
{

    class Program
    {
        const int port = 4678;
        const string ipcim = "127.0.0.1";
        static void Main(string[] args) {
            IPAddress ip = IPAddress.Parse(ipcim);
            TcpClient cl = new TcpClient();
            Console.WriteLine("konnektalas a szerver fele indul: {0}:{1}", ip.ToString(), port);
            cl.Connect(ip, port);
            Console.WriteLine("konnektalas sikerult!");
            StreamReader r = new StreamReader(cl.GetStream(), Encoding.UTF8);
            StreamWriter w = new StreamWriter(cl.GetStream(), Encoding.UTF8);
            //--------
            string udvozlet = r.ReadLine();
            Console.WriteLine("> {0}", udvozlet);
            while (true) {
                Console.ForegroundColor = ConsoleColor.Gray;
                string s = Console.ReadLine();
                w.WriteLine(s);
                w.Flush();
                string v = r.ReadLine();
                if (v == "OK") {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("> OK");
                }
                else if (v.StartsWith("ERR")) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("> {0}", v);
                }
                else if (v == "OK*") {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("> -------- tobbsoros valasz eleje ----");
                    while (true) {
                        string a = r.ReadLine();
                        if (a == "OK!") break;
                        Console.WriteLine("> {0}", a);
                    }
                    Console.WriteLine("> -------- vege ----------------------");
                }
                else if (v == "VEGE") break;
                else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ISMERETLEN VALASZ: {0}", v);
                }
            }
            Console.WriteLine("-- vege, nyomj <Enter>-t");
            Console.ReadLine();
        }
    }
}
