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
                this._ar = ar;
                this._id = id;
                this._elado = elado;
                this._megnevezes = megnevezes;
                Feltolt();
            }

            protected List<Porteka> portekak = new List<Porteka>();
            public List<Porteka> Portekak {
                get { return portekak; }
            }

            public void Feltolt() {
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

            //______________Konstruktor__________________
            public FoSzerver(string ipcim, int port) {
                this.Ipcim = IPAddress.Parse(ipcim);
                this.Port = port;
                this._felhasznalok = new List<User>();
                FelhasznalokFeltoltese();
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
            protected List<User> _felhasznalok;
            public List<User> Felhasznalok {
                get { return _felhasznalok; }
                set { this._felhasznalok = value; }
            }
            public List<string> Parancsok {
                get { return _parancsok; }
                set { _parancsok = value; }
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
                
            }

            public void Felrak(string porteka, int osszeg) {

            }

            public void Megvesz() {

            }

            public void Torol() {

            }

            public void Eladasok() {

            }

            private void FelhasznalokFeltoltese() {
                Felhasznalok.Add(new User("kissj", "abc123"));
                Felhasznalok.Add(new User("kovacsi", "alma"));
                Felhasznalok.Add(new User("root", "envagyokazadmin"));
            }

        }

        static void Main(string[] args) {
            

        }
    }
}
