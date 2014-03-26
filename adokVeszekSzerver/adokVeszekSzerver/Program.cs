using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace adokVeszekSzerver
{
    class Program
    {
        class User
        {
            protected string _account;

            public string Account {
                get { return _account; }
                set { _account = value; }
            }

            protected string _password;

            public string Password {
                get {return _password;}
                set { _password = value; }
            }

            //___________Konstruktor______________________
            public User(string username, string password) {
                this._account = username;
                this._password = password;
            }
        }

        class Porteka
        {
            protected int _id;
            protected User _elado;
            protected int _ar;
            protected string _megnevezes;            

            public Porteka(int id, User elado, int ar, string megnevezes) {
                KezdoFeltoltes();
                this._ar = ar;
                this._id = id;
                this._elado = elado;
                this._megnevezes = megnevezes;
                
                portekak.Add(new Porteka(id, elado, ar, megnevezes));
            }

            //_________Kunstruktror, ha nincs belépve_____________
            public Porteka() {

            }

            protected List<Porteka> portekak = new List<Porteka>();
            public List<Porteka> Portekak {
                get { return portekak; }
            }

           

            public void KezdoFeltoltes() {
                portekak.Add(new Porteka(5, new User("kissj", "abc123"), 1500, "seprő"));
                portekak.Add(new Porteka(9, new User("kovacsi", "alma"), 2000, "lámpa"));
                portekak.Add(new Porteka(8, new User("root", "envagyokazadmin"), 15000, "500 GB WD HDD"));
                portekak.Add(new Porteka(11, new User("root", "envagyokazadmin"), 22000, "128 GB Kingston SSD"));
                portekak.Add(new Porteka(13, new User("root", "envagyokazadmin"), 500, "bézbózütő"));
            }
        }

        

        class FoSzerver
        {
            protected int _port;
            public int Port {
                get {
                    return this._port;
                }
                set {
                    this._port = value;
                }
            }
            Porteka p;

            //______________Konstruktor__________________
            public FoSzerver(string ipcim, int port) {
                this.Ipcim = IPAddress.Parse(ipcim);
                this.Port = port;
                this._felhasznalok = new List<User>();
                FelhasznalokFeltoltese();
                p = new Porteka();
                
            }

            protected IPAddress _ipcim;
            public IPAddress Ipcim{
                get{
                    return this._ipcim;
                }
                set{
                    this._ipcim = value;
                }
            }
            //ezt a szervert indítjuk
            protected TcpListener _szerver;

            //kell egy lista a userekről, egy lista a megvehető portékákról, és egy lista a parancsokról
            protected List<string> _parancsok;
            public List<string> Parancsok {
                get { return _parancsok; }
                set { _parancsok = value; }
            }
            protected List<User> _felhasznalok;
            public List<User> Felhasznalok {
                get { return _felhasznalok; }
                set { this._felhasznalok = value; }
            }
            protected List<Porteka> _portekak;
            public List<Porteka> Portekak {
                get { return _portekak; }
                set { _portekak = value; }
            }
            

            public TcpListener Szerver {
                get { return _szerver; }
            }

            public void StartSzerver() {
                _szerver = new TcpListener(Ipcim, Port);
                _szerver.Start();
            }

            /*public User Login(string username, string pass) {
                User u = new User(
            }*/

            protected User userLeker(string acc) {
                foreach (var item in _felhasznalok) {
                    if (item.Account == acc)
                        return item;
                }
                return null;
            }

            public void Listaz() {
                foreach (var item in p.Portekak) {
                    _portekak.Add(item);
                }
            }

            public void Felrak(string porteka, int osszeg) {

            }

            public void Megvesz() {

            }

            public void Torol(int id) {

            }

            public void Eladasok() {

            }

            private void FelhasznalokFeltoltese() {
                Felhasznalok.Add(new User("kissj", "abc123"));
                Felhasznalok.Add(new User("kovacsi", "alma"));
                Felhasznalok.Add(new User("root", "envagyokazadmin"));
            }

            public void KliensekreVar() {
                while (true) {
                    var tx = Szerver.AcceptTcpClient();
                    Console.WriteLine("Kliens csatlakozott!");
                   
                    //Thread t = new Thread(kc.Kommunikal);
                    //szallista.Add(t);
                    t.Start();
                }
            }

        }

        public static Thread t;
        static void Main(string[] args) {
            FoSzerver fsz = new FoSzerver("192.168.1.101", 80);
            fsz.StartSzerver();
            Console.WriteLine("A szerver elindult");
            Console.WriteLine("Gépelje be a HELP parancsot a parancslista megjelenítéséhez!");
            t = new Thread(fsz.KliensekreVar);
            t.Start();
            bool vege = false;
            string olvasottParancs;
            string[] oPreszek;
            while (!vege) {
                olvasottParancs = Console.ReadLine();
                oPreszek = olvasottParancs.Split('|');
                switch (oPreszek[0].ToUpper()) {
                    case "HELP":
                        foreach (var item in fsz.Parancsok) {
                            Console.WriteLine(item);
                        }
                            break;
                    case "LISTAZ":
                            foreach (var item in fsz.Portekak) {
                                Console.WriteLine(item);
                            }
                            break;
                    case "LOGIN":
                        //todo: ide login metódus
                            break;
                    case "FELRAK":
                            fsz.Felrak(oPreszek[1], int.Parse(oPreszek[2]));
                            break;
                    case "MEGVESZ":
                        //todo: ide megvesz metódus
                            break;
                    case "TÖRÖL":
                            fsz.Torol(int.Parse(oPreszek[1]));
                            break;
                    case "ELADASOK":
                            fsz.Eladasok();
                            break;
                    default:
                            Console.WriteLine("Ismeretlen parancs");
                            break;
                }
            }
        }
    }
}
