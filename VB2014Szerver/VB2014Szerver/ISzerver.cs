using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace VB2014Szerver
{
    
    class User
    {
        public int id;
        public string nev;
        public string jelszo;
        public double egyenleg;

        public User(int id, string usernev, string jelszo, double egyenleg) {
            this.id = id;
            this.nev = usernev;
            this.jelszo = jelszo;
            this.egyenleg = egyenleg;
        }
    }

    /*class Meccs
    {
        public int id;
        public string esemeny;
        public double hazai;
        public double dontetlen;
        public double vendeg;

        public Meccs(int id, string esemeny, double hazai, double dontetlen, double vendeg) {
            this.id = id;
            this.esemeny = esemeny;
            this.hazai = hazai;
            this.dontetlen = dontetlen;
            this.vendeg = vendeg;
        }
    }*/

    [DataContract]
    public class Szelveny
    {
        public List<string> Meccsek = new List<string>();
        public double Szorzo;
        public double VarhatoNyeremeny;

        public Szelveny(List<string> Meccsek, double szorzo, double varhatonyeremeny) {
            this.Meccsek = Meccsek;
            this.Szorzo = szorzo;
            this.VarhatoNyeremeny = varhatonyeremeny;
        }
    }

    [ServiceContract(SessionMode = SessionMode.Required)] 
    public interface ISzerver
    {
        [OperationContract]
        List<string> Meccslista();
        [OperationContract(IsInitiating = true)]
        bool Bejelentkezes(string nev, string jelszo);
        [OperationContract]
        string UserName();
        [OperationContract]
        string SzelvenyInfo();
        [OperationContract]
        double egyenleg(string username);
        [OperationContract]
        void Fogad(string username, int tet, List<string> mikreFogad);       
        [OperationContract]
        List<string> EredmenytGeneral();
        [OperationContract]
        void Osszehasonlit(string username, List<string> eredmeny, Szelveny szelveny);
        [OperationContract]
        string NyertemE();
        [OperationContract(IsTerminating = true)]
        bool Kilepes(); 
    }
}
