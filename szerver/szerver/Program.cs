using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace szerver
{
    class Operations
    {
        int a;
        int b;
        

        int result;

        public Operations(int a, int b) {
            this.a = a;
            this.b = b;
            result = 0;
        }

        public void ADD() {
            result = a + b;
        }

        public void DIV() {
            result = a / b;
        }

        public void MULTIPLY() {
            result = a * b;
        }

        public void SUBSTRACTION() {
            result = a - b;
        }

        public void PRIMS() {

        }

        public void STOP() {

        }
    }

    class Communication
    {
        public StreamReader r; 
        public StreamWriter w; 


        public Communication(TcpClient client) {
            this.r = new StreamReader(client.GetStream(), Encoding.UTF8);
            this.w = new StreamWriter(client.GetStream(), Encoding.UTF8);
            result = 0;
        }

        public void StartCommunication() {
            w.WriteLine("Üdvözöllek a szerveren!"+"Az szerver ezeket az utasításokat tudja:"
                        +"ADD pl: ADD|5|6  (5+6)"
                        +"DIV pl: DIV|9|3  (9/3)"
                        +"MULTIPLY pl: MULTIPLY|2|2  (2*2)"
                        + "SUBSTRACTION pl: SUBSTRACTION|6|3  (6-3)"
                        +"PRIMS");
            w.Flush();
            while (true) {
                string[] utasitas = null;
                try {
                    string keres = r.ReadLine();
                    
                    utasitas = keres.Split('|');
                    a = int.Parse(utasitas[1]);
                    b = int.Parse(utasitas[2]);
                    switch (utasitas[0]) {
                        case "ADD":
                            ADD();
                            break;
                        case "MULTIPLY":
                            MULTIPLY();
                            break;
                        case "SUBSTRACTION":
                            SUBSTRACTION();
                            break;
                        case "DIV":
                            DIV();
                            break;
                        case "PRIMS":
                            PRIMS();
                            break;
                        case "BYE":
                            STOP();
                            break;
                        default:
                            w.WriteLine("ERR|Nem ismerem ezt a parancsot");
                            break;
                    }
                }
                catch (Exception e) {
                    w.WriteLine("ERR|{0}", e.Message);
                }
                
                w.Flush();
                if (utasitas[0] == "BYE") break;
            }
        }


        /*műveletek*/
        public int a;
        public int b;
        

        int result;

        

        public void ADD() {
            result = a + b;
            w.WriteLine("OK");
        }

        public void DIV() {
            result = a / b;
            w.WriteLine("OK");
        }

        public void MULTIPLY() {
            result = a * b;
            w.WriteLine("OK");
        }

        public void SUBSTRACTION() {
            result = a - b;
            w.WriteLine("OK");
        }

        public void PRIMS() {

        }

        public void STOP() {
            w.WriteLine("A szerver befejezte a kommunikációt");
        }
    }

    

    

    class Program
    {
        const int portSzam = 6666; // 1024 .. 65535 kozotti szam
        const string ipCim = "127.0.0.1";
        static void Main(string[] args) {
            Console.WriteLine("Szerver indul...");
            try {
                IPAddress ip = IPAddress.Parse(ipCim);
                TcpListener k = new TcpListener(ip, portSzam);
                k.Start();
                Console.WriteLine("A szerver sikeresen elindult {0}:{1}", ip.ToString(), portSzam);
                while (true) {
                    Console.WriteLine("A szerver a bejövő kapcsolatra vár.");
                    TcpClient client = k.AcceptTcpClient();
                    Console.WriteLine("bejövő kapcsolat megérkezett");
                    Communication p = new Communication(client);
                    Thread t = new Thread(p.StartCommunication);
                    t.Start();  // p.startKomm();
                }
            }
            catch {
                Console.WriteLine("A szerver nem indult el, hiba miatt!");
            }
            Console.WriteLine("Kapcsolat vége, nyomj meg egy billentyűt a folytatáshoz...");
            Console.ReadLine();
        }
    }
}
