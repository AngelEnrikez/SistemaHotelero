﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.34014
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiciosHoteles.ServicioCliente {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Cliente", Namespace="http://schemas.datacontract.org/2004/07/ServiciosHoteles.Dominio")]
    [System.SerializableAttribute()]
    public partial class Cliente : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ApellidoMaternoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ApellidoPaternoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdClienteField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NumeroDocumentoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ServiciosHoteles.ServicioCliente.Pais PaisField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TelefonoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ServiciosHoteles.ServicioCliente.TipoDocumento TipoDocumentoField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ApellidoMaterno {
            get {
                return this.ApellidoMaternoField;
            }
            set {
                if ((object.ReferenceEquals(this.ApellidoMaternoField, value) != true)) {
                    this.ApellidoMaternoField = value;
                    this.RaisePropertyChanged("ApellidoMaterno");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ApellidoPaterno {
            get {
                return this.ApellidoPaternoField;
            }
            set {
                if ((object.ReferenceEquals(this.ApellidoPaternoField, value) != true)) {
                    this.ApellidoPaternoField = value;
                    this.RaisePropertyChanged("ApellidoPaterno");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdCliente {
            get {
                return this.IdClienteField;
            }
            set {
                if ((this.IdClienteField.Equals(value) != true)) {
                    this.IdClienteField = value;
                    this.RaisePropertyChanged("IdCliente");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NumeroDocumento {
            get {
                return this.NumeroDocumentoField;
            }
            set {
                if ((object.ReferenceEquals(this.NumeroDocumentoField, value) != true)) {
                    this.NumeroDocumentoField = value;
                    this.RaisePropertyChanged("NumeroDocumento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiciosHoteles.ServicioCliente.Pais Pais {
            get {
                return this.PaisField;
            }
            set {
                if ((object.ReferenceEquals(this.PaisField, value) != true)) {
                    this.PaisField = value;
                    this.RaisePropertyChanged("Pais");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Telefono {
            get {
                return this.TelefonoField;
            }
            set {
                if ((object.ReferenceEquals(this.TelefonoField, value) != true)) {
                    this.TelefonoField = value;
                    this.RaisePropertyChanged("Telefono");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiciosHoteles.ServicioCliente.TipoDocumento TipoDocumento {
            get {
                return this.TipoDocumentoField;
            }
            set {
                if ((object.ReferenceEquals(this.TipoDocumentoField, value) != true)) {
                    this.TipoDocumentoField = value;
                    this.RaisePropertyChanged("TipoDocumento");
                }
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Pais", Namespace="http://schemas.datacontract.org/2004/07/ServiciosHoteles.Dominio")]
    [System.SerializableAttribute()]
    public partial class Pais : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdPaisField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombrePaisField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdPais {
            get {
                return this.IdPaisField;
            }
            set {
                if ((this.IdPaisField.Equals(value) != true)) {
                    this.IdPaisField = value;
                    this.RaisePropertyChanged("IdPais");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NombrePais {
            get {
                return this.NombrePaisField;
            }
            set {
                if ((object.ReferenceEquals(this.NombrePaisField, value) != true)) {
                    this.NombrePaisField = value;
                    this.RaisePropertyChanged("NombrePais");
                }
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TipoDocumento", Namespace="http://schemas.datacontract.org/2004/07/ServiciosHoteles.Dominio")]
    [System.SerializableAttribute()]
    public partial class TipoDocumento : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescripcionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdTipoDocumentoField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Descripcion {
            get {
                return this.DescripcionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescripcionField, value) != true)) {
                    this.DescripcionField = value;
                    this.RaisePropertyChanged("Descripcion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdTipoDocumento {
            get {
                return this.IdTipoDocumentoField;
            }
            set {
                if ((this.IdTipoDocumentoField.Equals(value) != true)) {
                    this.IdTipoDocumentoField = value;
                    this.RaisePropertyChanged("IdTipoDocumento");
                }
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicioCliente.IClientes")]
    public interface IClientes {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/CrearCliente", ReplyAction="http://tempuri.org/IClientes/CrearClienteResponse")]
        ServiciosHoteles.ServicioCliente.Cliente CrearCliente(ServiciosHoteles.ServicioCliente.Cliente clienteNuevo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/CrearCliente", ReplyAction="http://tempuri.org/IClientes/CrearClienteResponse")]
        System.Threading.Tasks.Task<ServiciosHoteles.ServicioCliente.Cliente> CrearClienteAsync(ServiciosHoteles.ServicioCliente.Cliente clienteNuevo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/ModificarCliente", ReplyAction="http://tempuri.org/IClientes/ModificarClienteResponse")]
        ServiciosHoteles.ServicioCliente.Cliente ModificarCliente(ServiciosHoteles.ServicioCliente.Cliente clienteModificado);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/ModificarCliente", ReplyAction="http://tempuri.org/IClientes/ModificarClienteResponse")]
        System.Threading.Tasks.Task<ServiciosHoteles.ServicioCliente.Cliente> ModificarClienteAsync(ServiciosHoteles.ServicioCliente.Cliente clienteModificado);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/EliminarCliente", ReplyAction="http://tempuri.org/IClientes/EliminarClienteResponse")]
        void EliminarCliente(ServiciosHoteles.ServicioCliente.Cliente clienteEliminar);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/EliminarCliente", ReplyAction="http://tempuri.org/IClientes/EliminarClienteResponse")]
        System.Threading.Tasks.Task EliminarClienteAsync(ServiciosHoteles.ServicioCliente.Cliente clienteEliminar);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/ObtenerCliente", ReplyAction="http://tempuri.org/IClientes/ObtenerClienteResponse")]
        ServiciosHoteles.ServicioCliente.Cliente ObtenerCliente(int codigo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/ObtenerCliente", ReplyAction="http://tempuri.org/IClientes/ObtenerClienteResponse")]
        System.Threading.Tasks.Task<ServiciosHoteles.ServicioCliente.Cliente> ObtenerClienteAsync(int codigo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/ListarClientes", ReplyAction="http://tempuri.org/IClientes/ListarClientesResponse")]
        ServiciosHoteles.ServicioCliente.Cliente[] ListarClientes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/ListarClientes", ReplyAction="http://tempuri.org/IClientes/ListarClientesResponse")]
        System.Threading.Tasks.Task<ServiciosHoteles.ServicioCliente.Cliente[]> ListarClientesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/BuscarClientes", ReplyAction="http://tempuri.org/IClientes/BuscarClientesResponse")]
        ServiciosHoteles.ServicioCliente.Cliente[] BuscarClientes(string nombre, string numeroDocumento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/BuscarClientes", ReplyAction="http://tempuri.org/IClientes/BuscarClientesResponse")]
        System.Threading.Tasks.Task<ServiciosHoteles.ServicioCliente.Cliente[]> BuscarClientesAsync(string nombre, string numeroDocumento);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IClientesChannel : ServiciosHoteles.ServicioCliente.IClientes, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ClientesClient : System.ServiceModel.ClientBase<ServiciosHoteles.ServicioCliente.IClientes>, ServiciosHoteles.ServicioCliente.IClientes {
        
        public ClientesClient() {
        }
        
        public ClientesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ClientesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ClientesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ClientesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ServiciosHoteles.ServicioCliente.Cliente CrearCliente(ServiciosHoteles.ServicioCliente.Cliente clienteNuevo) {
            return base.Channel.CrearCliente(clienteNuevo);
        }
        
        public System.Threading.Tasks.Task<ServiciosHoteles.ServicioCliente.Cliente> CrearClienteAsync(ServiciosHoteles.ServicioCliente.Cliente clienteNuevo) {
            return base.Channel.CrearClienteAsync(clienteNuevo);
        }
        
        public ServiciosHoteles.ServicioCliente.Cliente ModificarCliente(ServiciosHoteles.ServicioCliente.Cliente clienteModificado) {
            return base.Channel.ModificarCliente(clienteModificado);
        }
        
        public System.Threading.Tasks.Task<ServiciosHoteles.ServicioCliente.Cliente> ModificarClienteAsync(ServiciosHoteles.ServicioCliente.Cliente clienteModificado) {
            return base.Channel.ModificarClienteAsync(clienteModificado);
        }
        
        public void EliminarCliente(ServiciosHoteles.ServicioCliente.Cliente clienteEliminar) {
            base.Channel.EliminarCliente(clienteEliminar);
        }
        
        public System.Threading.Tasks.Task EliminarClienteAsync(ServiciosHoteles.ServicioCliente.Cliente clienteEliminar) {
            return base.Channel.EliminarClienteAsync(clienteEliminar);
        }
        
        public ServiciosHoteles.ServicioCliente.Cliente ObtenerCliente(int codigo) {
            return base.Channel.ObtenerCliente(codigo);
        }
        
        public System.Threading.Tasks.Task<ServiciosHoteles.ServicioCliente.Cliente> ObtenerClienteAsync(int codigo) {
            return base.Channel.ObtenerClienteAsync(codigo);
        }
        
        public ServiciosHoteles.ServicioCliente.Cliente[] ListarClientes() {
            return base.Channel.ListarClientes();
        }
        
        public System.Threading.Tasks.Task<ServiciosHoteles.ServicioCliente.Cliente[]> ListarClientesAsync() {
            return base.Channel.ListarClientesAsync();
        }
        
        public ServiciosHoteles.ServicioCliente.Cliente[] BuscarClientes(string nombre, string numeroDocumento) {
            return base.Channel.BuscarClientes(nombre, numeroDocumento);
        }
        
        public System.Threading.Tasks.Task<ServiciosHoteles.ServicioCliente.Cliente[]> BuscarClientesAsync(string nombre, string numeroDocumento) {
            return base.Channel.BuscarClientesAsync(nombre, numeroDocumento);
        }
    }
}
