using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace adokVeszekSzerver2
{
    class FoSzerver
    {
        const int port = 4678;
        const string ipcim = "127.0.0.1";
        static void Main(string[] args) {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Indul a szerver...");
            try {
                IPAddress ip = IPAddress.Parse(ipcim);
                TcpListener s = new TcpListener(ip, port);
                s.Start();
                Console.WriteLine("A szerver sikeresen elindult.");
                while (true) {
                    Console.WriteLine("Kliensekre vár...");
                    TcpClient kliens = s.AcceptTcpClient();
                    Console.WriteLine("sikeres kapcsolódás");
                    Kommunikacio komm = new Kommunikacio(kliens);
                    Thread t = new Thread(komm.Start);
                    t.Start();
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Vége");
            Console.ReadKey();
        }
    }

    class Termek
    {
        protected int _id;
        public int Id{ get{ return _id; } set{ _id = value; } }
        protected string _nev;
        public string Nev{ get{ return _nev; } set{ _nev = value; } }
        protected int _ar;
        public int Ar{ get{ return _ar; } set{ _ar = value; } }
        protected string _elado;
        public string Elado { get { return _elado; } set { _elado = value; } }

        public Termek(int termekId, string termekNev, int termekAr, string termekElado) {
            Id = termekId;
            Nev = termekNev;
            Ar = termekAr;
            Elado = termekElado;
        }
    }

    class User
    {
        protected string _username;

        public string UserName {
            get { return _username; }
            set { _username = value; }
        }

        protected string _password;

        public string Password {
            get { return _password; }
            set { _password = value; }
        }

        //___________Konstruktor______________________
        public User(string username, string password) {
            this._username = username;
            this._password = password;
        }

    }

    class Kommunikacio
    {
        //Ezt a listát használja mindenki, azért static
        protected static List<Termek> Portekak = new List<Termek>();

        public StreamReader reader;
        public StreamWriter writer;
        public User user = null;
        public List<string> Eladasok = new List<string>(); 


        public Kommunikacio(TcpClient c) {
            this.reader = new StreamReader(c.GetStream(), Encoding.UTF8);
            this.writer = new StreamWriter(c.GetStream(), Encoding.UTF8);

            //Néhány adat bevitele a termékek listába:
            lock (Portekak) {

                Portekak.Add(new Termek(1,"Fogpiszkáló",5,"kissJ"));
                Portekak.Add(new Termek(2,"Kanapé",20000,"kovacsL"));
            }
        }

        public void Start() {
            writer.WriteLine("Adok-Veszek szerver");
            writer.Flush();

            while (true) {
                string command = null;
                try {
                    string olvas = reader.ReadLine();
                    string[] olvasReszek = olvas.Split('|');
                    command = olvasReszek[0].ToUpper();
                    switch (command) {
                        case "HELP":
                            ParancsLista();
                            break;
                        case "LISTAZ":
                            Listaz();
                            break;
                        case "LOGIN":
                            Login(olvasReszek[1], olvasReszek[2]);
                            break;
                        case "FELRAK":
                            Felrak(olvasReszek[1], int.Parse(olvasReszek[2]));
                            break;
                        case "MEGVESZ":
                            Megvesz(int.Parse(olvasReszek[1]));
                            break;
                        case "TÖRÖL":
                            Torol(int.Parse(olvasReszek[1]));
                            break;
                        case "ELADASOK":
                            foreach (var item in Eladasok) {
                                writer.WriteLine(item);
                            }
                            break;
                        case "VEGE":
                            Vege();
                            break;
                        default:
                            Console.WriteLine("Ismeretlen parancs");
                            break;

                    }
                }
                catch (Exception e) {
                    writer.WriteLine("ERR|{0}", e.Message);
                }
                writer.Flush();
                if (command == "VEGE") break;
            }
            Console.WriteLine("---");
        }

        #region Commands
        
        
        protected void ParancsLista() {
            List<string> Parancsok = new List<string>();

            Parancsok.Add("HELP - Kilistázza a parancsokat");
            Parancsok.Add("LISTAZ - Kilistázza a termékeket");
            Parancsok.Add("LOGIN - Bejelentkezés");
            Parancsok.Add("FELRAK - Új termék felvitele a rendszerbe");
            Parancsok.Add("MEGVESZ - Termék megvétele");
            Parancsok.Add("TOROL - Termék törlése");
            Parancsok.Add("ELADASOK - Kilistázza ki mit vett meg");
            writer.WriteLine("OK*");
            foreach (var item in Parancsok) {
                writer.WriteLine(item);
            }
            writer.WriteLine("OK!");
        }

        protected void Login(string username, string password) {
            user = new User(username, password);
            writer.WriteLine("OK");
        }

        protected void Listaz() {
            lock (Portekak) {
                writer.WriteLine("OK*");
                foreach (Termek t in Portekak) {
                    writer.WriteLine("{0} | {1} | {2} | {3}",t.Id,t.Elado,t.Nev,t.Ar);
                }
                writer.WriteLine("OK!");
            }
        }

        protected void Felrak(string megnevezes, int osszeg) {
            if (user == null) {
                writer.WriteLine("ERR|Loginolj be!");
                return;
            }
            if (osszeg <= 5 || osszeg > 1000000) {
                writer.WriteLine("ERR|Hibás ár, 5 és 1000000 közötti árat lehet csak megadni!");
            }
            else {
                lock (Portekak) {
                    int id = Portekak.Last().Id + 1;
                    Termek uj = new Termek(id, megnevezes, osszeg, user.UserName);
                    Portekak.Add(uj);
                    writer.WriteLine("OK");
                }
            }
        }

        protected void Megvesz(int id) {
            if (user == null) {
                writer.WriteLine("ERR|Loginolj be!");
                return;
            }
            lock (Portekak) {
                foreach (var item in Portekak) {
                    if (item.Id == id) {
                        Eladasok.Add(item.Id + " | " + item.Elado + " | " + item.Nev + " | " + item.Ar + " | " + user.UserName);
                        Portekak.RemoveAt(id);
                        writer.WriteLine("OK");
                    }
                    else {
                        throw new Exception("Nincs ilyen id-vel termék!");
                    }
                }
            }
        }

        protected void Torol(int id) {
            if (user == null) {
                writer.WriteLine("ERR|Loginolj be!");
                return;
            }

            lock (Portekak) {
                foreach (var item in Portekak) {
                    if (item.Id == id) {
                        Portekak.RemoveAt(id);
                        writer.WriteLine("OK");
                    }
                    else {
                        throw new Exception("Nincs ilyen id-vel termék!");
                    }
                }
            }
        }

        protected void Vege() {
            writer.WriteLine("Vége a kapcsolatnak");
        }
        #endregion
    }
}
