﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.19453
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VB2014TippmixKliens.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Szelveny", Namespace="http://schemas.datacontract.org/2004/07/VB2014Szerver")]
    [System.SerializableAttribute()]
    public partial class Szelveny : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.ISzerver", SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface ISzerver {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISzerver/Meccslista", ReplyAction="http://tempuri.org/ISzerver/MeccslistaResponse")]
        string[] Meccslista();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISzerver/Bejelentkezes", ReplyAction="http://tempuri.org/ISzerver/BejelentkezesResponse")]
        bool Bejelentkezes(string nev, string jelszo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISzerver/UserName", ReplyAction="http://tempuri.org/ISzerver/UserNameResponse")]
        string UserName();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISzerver/SzelvenyInfo", ReplyAction="http://tempuri.org/ISzerver/SzelvenyInfoResponse")]
        string SzelvenyInfo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISzerver/egyenleg", ReplyAction="http://tempuri.org/ISzerver/egyenlegResponse")]
        double egyenleg(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISzerver/Fogad", ReplyAction="http://tempuri.org/ISzerver/FogadResponse")]
        void Fogad(string username, int tet, string[] mikreFogad);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISzerver/EredmenytGeneral", ReplyAction="http://tempuri.org/ISzerver/EredmenytGeneralResponse")]
        string[] EredmenytGeneral();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISzerver/Osszehasonlit", ReplyAction="http://tempuri.org/ISzerver/OsszehasonlitResponse")]
        void Osszehasonlit(string username, string[] eredmeny, VB2014TippmixKliens.ServiceReference1.Szelveny szelveny);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISzerver/NyertemE", ReplyAction="http://tempuri.org/ISzerver/NyertemEResponse")]
        string NyertemE();
        
        [System.ServiceModel.OperationContractAttribute(IsTerminating=true, Action="http://tempuri.org/ISzerver/Kilepes", ReplyAction="http://tempuri.org/ISzerver/KilepesResponse")]
        bool Kilepes();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISzerverChannel : VB2014TippmixKliens.ServiceReference1.ISzerver, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SzerverClient : System.ServiceModel.ClientBase<VB2014TippmixKliens.ServiceReference1.ISzerver>, VB2014TippmixKliens.ServiceReference1.ISzerver {
        
        public SzerverClient() {
        }
        
        public SzerverClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SzerverClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SzerverClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SzerverClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] Meccslista() {
            return base.Channel.Meccslista();
        }
        
        public bool Bejelentkezes(string nev, string jelszo) {
            return base.Channel.Bejelentkezes(nev, jelszo);
        }
        
        public string UserName() {
            return base.Channel.UserName();
        }
        
        public string SzelvenyInfo() {
            return base.Channel.SzelvenyInfo();
        }
        
        public double egyenleg(string username) {
            return base.Channel.egyenleg(username);
        }
        
        public void Fogad(string username, int tet, string[] mikreFogad) {
            base.Channel.Fogad(username, tet, mikreFogad);
        }
        
        public string[] EredmenytGeneral() {
            return base.Channel.EredmenytGeneral();
        }
        
        public void Osszehasonlit(string username, string[] eredmeny, VB2014TippmixKliens.ServiceReference1.Szelveny szelveny) {
            base.Channel.Osszehasonlit(username, eredmeny, szelveny);
        }
        
        public string NyertemE() {
            return base.Channel.NyertemE();
        }
        
        public bool Kilepes() {
            return base.Channel.Kilepes();
        }
    }
}
