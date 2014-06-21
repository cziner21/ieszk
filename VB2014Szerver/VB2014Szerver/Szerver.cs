using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace VB2014Szerver
{
    
    
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)] 
    public class Szerver : ISzerver
    {
        static List<User> felhasznalok = new List<User>();
        static List<Szelveny> szelvenyek = new List<Szelveny>();
        private User aktualisUser = null;

        bool nyert;
       // static int meccsekSzama = 0; //itt kell még valamit kitalálni
        public static double szorzo = 1;
        public static double nyeremeny = 0;

        public Szelveny szelo = null;

        public static StreamWriter w = new StreamWriter(@"D:\vb2014hibak.log", true, Encoding.UTF8);

        public List<string> fmeccs = new List<string>();

        public Szerver() {
            UserFeltolt();
        }

        public void UserFeltolt() {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["vb2014"];
            SqlConnection connection = new SqlConnection(settings.ConnectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * from userek";
            try {
                connection.Open();
                SqlDataReader sqlReader = command.ExecuteReader();
                while (sqlReader.Read()) {
                    felhasznalok.Add(new User(int.Parse(sqlReader["id"].ToString()),megtisztit(sqlReader["username"].ToString()),sqlReader["passwd"].ToString(),double.Parse(sqlReader["egyenleg"].ToString())));
                }
            }
            catch (Exception ex) {
                lock (w) {
                    w.WriteLine(ex.Message);
                    w.Close();
                }

            }
            finally {
                connection.Close();
            }
        }


        public List<string> Meccslista() {
            List<string> ml = new List<string>();
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["vb2014"];
            SqlConnection connection = new SqlConnection(settings.ConnectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * from meccsek";

            try {
                connection.Open();
                SqlDataReader sqlReader = command.ExecuteReader();
                while (sqlReader.Read()) {
                    ml.Add(sqlReader["id"].ToString() + ";" + megtisztit(sqlReader["esemeny"].ToString()) + ";" + sqlReader["hazai"].ToString()+ ";" +
                           sqlReader["dontetlen"].ToString() + ";" + sqlReader["vendeg"].ToString());
                }

                return ml;
            }
            catch (Exception ex) {
                lock (w) {
                    w.WriteLine("hiba: {0}", ex.Message);
                    w.Close();
                }

                return ml;
            }
            finally {
                
                connection.Close();

            }
        }

        private string megtisztit(string szoveg) {
            string jo = "";
            for (int i = 0; i < szoveg.Length; i++) {
                if (!char.IsWhiteSpace(szoveg[i]))
                    jo += szoveg[i];        
            }
            return jo;
        }

        public bool Bejelentkezes(string nev, string jelszo) {
            try {
                lock (felhasznalok) {
                    foreach (User u in felhasznalok) {
                        if (nev == u.nev && jelszo == u.jelszo && aktualisUser == null) {
                            aktualisUser = u;
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex) {
                lock (w) {
                    w.WriteLine("hiba: {0}", ex.Message);
                    w.Close();
                }
                return false;
            }
        }

        public double egyenleg(string username) {
            if (aktualisUser != null) {
                return aktualisUser.egyenleg;
            }
            else
                return -1;
        }

        public void Fogad(string username, int tet, List<string> mikreFogad) {
            //StreamWriter w = new StreamWriter(@"D:\vb2014hibak.log", true, Encoding.UTF8);
            try {
                
                if (aktualisUser != null) {
                    if (aktualisUser.egyenleg >= tet) {
                        string[] a;
                        string[] b;
                        szorzo = 1;
                        List<string> meccsek = new List<string>();

                        foreach (string meccs in Meccslista()) {
                            a = meccs.Split(';');
                            foreach (string fogadott in mikreFogad) {
                                b = fogadott.Split(';');
                                if (int.Parse(b[0]) == int.Parse(a[0])) {

                                    if (b[2].ToUpper() == "H") {
                                        szorzo = szorzo * double.Parse(a[2]);
                                    }
                                    else if (b[2].ToUpper() == "D") {
                                        szorzo = szorzo * double.Parse(a[3]);
                                    }
                                    else if (b[2].ToUpper() == "V") {
                                        szorzo = szorzo * double.Parse(a[4]);
                                    }
                                    else
                                        throw new Exception("Hiba");
                                }

                            }

                        }
                        meccsek.Clear();
                        meccsek = mikreFogad;
                        /*lock (felhasznalok) {
                            foreach (User u in felhasznalok) {
                                if (u.nev == username) {
                                    u.egyenleg -= tet;
                                }
                            }
  
                        }*/
                        User tmp = null;
                        ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["vb2014"];
                        SqlConnection connection = new SqlConnection(settings.ConnectionString);
                        SqlCommand cmd = connection.CreateCommand();
                        connection.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "up_userek";
                        lock (felhasznalok) {
                            foreach (User u in felhasznalok) {
                                if (u.nev == username) {
                                    u.egyenleg -= tet;
                                    tmp = new User(u.id, u.nev, u.jelszo, u.egyenleg);


                                    //u.egyenleg -= tet;
                                    //aktualisUser = u;
                                }
                            }
                        }

                        //aktualisUser.egyenleg -= tet;


                        cmd.Parameters.AddWithValue("@username", tmp.nev);
                        cmd.Parameters.AddWithValue("@passwd", tmp.jelszo);
                        cmd.Parameters.AddWithValue("@egyenleg", tmp.egyenleg);
                        cmd.Parameters.AddWithValue("@user_id", tmp.id);

                        cmd.ExecuteNonQuery();

                        connection.Close();

                         
                        nyeremeny = 0;
                        nyeremeny = Math.Round(tet * szorzo / 5.0) * 5;
                        szelo = new Szelveny(meccsek, szorzo, nyeremeny);
                        szelvenyek.Add(szelo);
                    }
                    else {
                        throw new Exception("az egyenleg kevesebb, mint a megtett tét");                        
                    }
                }
                else {                    
                    throw new Exception("üres az aktuális user");                    
                }
            }
            catch (Exception ex) {
                lock (w) {
                    w.WriteLine("hiba: {0}", ex.Message);
                }
            }
            finally {
                w.Close();
            }
        }

        public List<string> EredmenytGeneral() {
            try {
                Random rnd = new Random();
                List<string> tm = Meccslista();
                int meccsekSzama = tm.Count();
                int[] reszEredmeny = new int[meccsekSzama];
                List<string> eredmeny = new List<string>();
                for (int i = 0; i < meccsekSzama; i++) {
                    reszEredmeny[i] = rnd.Next(1, 101);
                    if (reszEredmeny[i] <= 40)
                        eredmeny.Add(i + ";" + "H");
                    else if (reszEredmeny[i] <= 80)
                        /*if (i < 10)
                            eredmeny.Add("00" + i + ";" + "V");
                        else if (i < 100)
                            eredmeny.Add("0" + i + ";" + "V");
                        else*/
                        eredmeny.Add(i + ";" + "V");
                    else
                        /*if (i < 10)
                            eredmeny.Add("00" + i + ";" + "D");
                        else if (i < 100)
                            eredmeny.Add("0" + i + ";" + "D");
                        else*/
                        eredmeny.Add(i + ";" + "D");
                    Thread.Sleep(100);
                }
                if (aktualisUser != null && szelo != null) {
                    Osszehasonlit(aktualisUser.nev, eredmeny, szelo);
                }

                return eredmeny;
            }
            catch (Exception ex) {
                lock (w) {
                    w.WriteLine("hiba: {0}", ex.Message);
                    w.Close();
                }
                return null;
            }
        }

        public void Osszehasonlit(string username,List<string> eredmenyek, Szelveny szelveny) {
            try {
                nyert = false;
                int eltalalt = 0;
                Dictionary<string, string> tippekDict = new Dictionary<string, string>();
                Dictionary<string, string> eredmenyekDict = new Dictionary<string, string>();


                string[] tmp;
                foreach (string fogadott in szelveny.Meccsek) {
                    tmp = fogadott.Split(';');
                    tippekDict.Add(tmp[0], tmp[2]);
                }
                string[] tmp2;
                foreach (string eredmeny in eredmenyek) {
                    tmp2 = eredmeny.Split(';');
                    eredmenyekDict.Add(tmp2[0], tmp2[1]);

                }
                StreamWriter w2 = new StreamWriter(@"D:\Szelvényem.txt", true, Encoding.UTF8);


                foreach (var eredmeny in eredmenyekDict) {
                    foreach (var tipp in tippekDict) {
                        if (eredmeny.Key == tipp.Key) {
                            w2.WriteLine("Tipp: {0}", tipp);
                            w2.WriteLine("Eredmény: {0}", eredmeny);
                        }
                        if (tipp.Key == eredmeny.Key && tipp.Value == eredmeny.Value) {
                            eltalalt++;
                        }
                    }
                }

                w2.WriteLine("Eltalált meccsek száma: {0}",eltalalt);
                w2.WriteLine(nyeremeny);
                w2.WriteLine("--------------------------------------");
                w2.Close();

                if (eltalalt == szelveny.Meccsek.Count) {
                    User tmp1 = null;
                    nyert = true;
                    lock (felhasznalok) {
                        foreach (User u in felhasznalok) {
                            if (u.nev == username) {
                                u.egyenleg += nyeremeny;
                                tmp1 = new User(u.id, u.nev, u.jelszo, u.egyenleg);


                                //u.egyenleg -= tet;
                                //aktualisUser = u;
                            }
                        }
                    }
                    //aktualisUser.egyenleg += nyeremeny;

                    ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["vb2014"];
                    SqlConnection connection = new SqlConnection(settings.ConnectionString);
                    SqlCommand cmd = connection.CreateCommand();
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "up_userek";

                    cmd.Parameters.AddWithValue("@username", tmp1.nev);
                    cmd.Parameters.AddWithValue("@passwd", tmp1.jelszo);
                    cmd.Parameters.AddWithValue("@egyenleg", tmp1.egyenleg);
                    cmd.Parameters.AddWithValue("@user_id", tmp1.id);

                    cmd.ExecuteNonQuery();

                    connection.Close();
                }


            }
            catch (Exception ex) {
                lock (w) {
                    w.WriteLine("hiba: {0}", ex.Message);
                    w.Close();
                }
            }
        }

        public bool Kilepes() {
            if (aktualisUser == null)
                return false;
            this.aktualisUser = null;
            return true;
        }


        public string UserName() {
            return aktualisUser.nev;
        }

        public string SzelvenyInfo() {
            string info = "";
            info = "Fogadott meccsek:\n";
            foreach (var item in szelo.Meccsek) {
                info += item + "\n";
            }
            info += "Szorzó: " +
                    szelo.Szorzo.ToString() +
                    "\nVárható nyeremény: " +
                    szelo.VarhatoNyeremeny.ToString() + " Ft";

            return info;
        }

        public string NyertemE() {
            if(nyert)
                return "Nyeremény: " + szelo.VarhatoNyeremeny + " Ft";
            else
                return "Nem nyertél!";
        }
    }
}
