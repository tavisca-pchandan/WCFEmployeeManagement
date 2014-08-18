﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Consumer.EmployeeServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Employee", Namespace="http://schemas.datacontract.org/2004/07/EmployeeManagementService")]
    [System.SerializableAttribute()]
    public partial class Employee : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Consumer.EmployeeServiceReference.Employee.Remark[] RemarksField;
        
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
        public System.Guid Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Consumer.EmployeeServiceReference.Employee.Remark[] Remarks {
            get {
                return this.RemarksField;
            }
            set {
                if ((object.ReferenceEquals(this.RemarksField, value) != true)) {
                    this.RemarksField = value;
                    this.RaisePropertyChanged("Remarks");
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
        
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.Runtime.Serialization.DataContractAttribute(Name="Employee.Remark", Namespace="http://schemas.datacontract.org/2004/07/EmployeeManagementService")]
        [System.SerializableAttribute()]
        public partial class Remark : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
            
            [System.NonSerializedAttribute()]
            private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string _remarkField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.DateTime _remarkTimeField;
            
            public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
                get {
                    return this.extensionDataField;
                }
                set {
                    this.extensionDataField = value;
                }
            }
            
            [System.Runtime.Serialization.DataMemberAttribute()]
            public string _remark {
                get {
                    return this._remarkField;
                }
                set {
                    if ((object.ReferenceEquals(this._remarkField, value) != true)) {
                        this._remarkField = value;
                        this.RaisePropertyChanged("_remark");
                    }
                }
            }
            
            [System.Runtime.Serialization.DataMemberAttribute()]
            public System.DateTime _remarkTime {
                get {
                    return this._remarkTimeField;
                }
                set {
                    if ((this._remarkTimeField.Equals(value) != true)) {
                        this._remarkTimeField = value;
                        this.RaisePropertyChanged("_remarkTime");
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
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmployeeServiceReference.ICreateEmployeeService")]
    public interface ICreateEmployeeService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployeeService/CreateEmployee", ReplyAction="http://tempuri.org/ICreateEmployeeService/CreateEmployeeResponse")]
        Consumer.EmployeeServiceReference.Employee CreateEmployee(Consumer.EmployeeServiceReference.Employee e);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployeeService/CreateEmployee", ReplyAction="http://tempuri.org/ICreateEmployeeService/CreateEmployeeResponse")]
        System.Threading.Tasks.Task<Consumer.EmployeeServiceReference.Employee> CreateEmployeeAsync(Consumer.EmployeeServiceReference.Employee e);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployeeService/AddRemarks", ReplyAction="http://tempuri.org/ICreateEmployeeService/AddRemarksResponse")]
        string AddRemarks(System.Guid id, string remark);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployeeService/AddRemarks", ReplyAction="http://tempuri.org/ICreateEmployeeService/AddRemarksResponse")]
        System.Threading.Tasks.Task<string> AddRemarksAsync(System.Guid id, string remark);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICreateEmployeeServiceChannel : Consumer.EmployeeServiceReference.ICreateEmployeeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CreateEmployeeServiceClient : System.ServiceModel.ClientBase<Consumer.EmployeeServiceReference.ICreateEmployeeService>, Consumer.EmployeeServiceReference.ICreateEmployeeService {
        
        public CreateEmployeeServiceClient() {
        }
        
        public CreateEmployeeServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CreateEmployeeServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CreateEmployeeServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CreateEmployeeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Consumer.EmployeeServiceReference.Employee CreateEmployee(Consumer.EmployeeServiceReference.Employee e) {
            return base.Channel.CreateEmployee(e);
        }
        
        public System.Threading.Tasks.Task<Consumer.EmployeeServiceReference.Employee> CreateEmployeeAsync(Consumer.EmployeeServiceReference.Employee e) {
            return base.Channel.CreateEmployeeAsync(e);
        }
        
        public string AddRemarks(System.Guid id, string remark) {
            return base.Channel.AddRemarks(id, remark);
        }
        
        public System.Threading.Tasks.Task<string> AddRemarksAsync(System.Guid id, string remark) {
            return base.Channel.AddRemarksAsync(id, remark);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmployeeServiceReference.IRetrieveEmployeeService")]
    public interface IRetrieveEmployeeService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRetrieveEmployeeService/GetAllEmployees", ReplyAction="http://tempuri.org/IRetrieveEmployeeService/GetAllEmployeesResponse")]
        Consumer.EmployeeServiceReference.Employee[] GetAllEmployees();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRetrieveEmployeeService/GetAllEmployees", ReplyAction="http://tempuri.org/IRetrieveEmployeeService/GetAllEmployeesResponse")]
        System.Threading.Tasks.Task<Consumer.EmployeeServiceReference.Employee[]> GetAllEmployeesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRetrieveEmployeeService/SearchById", ReplyAction="http://tempuri.org/IRetrieveEmployeeService/SearchByIdResponse")]
        Consumer.EmployeeServiceReference.Employee SearchById(System.Guid Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRetrieveEmployeeService/SearchById", ReplyAction="http://tempuri.org/IRetrieveEmployeeService/SearchByIdResponse")]
        System.Threading.Tasks.Task<Consumer.EmployeeServiceReference.Employee> SearchByIdAsync(System.Guid Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRetrieveEmployeeService/SearchByName", ReplyAction="http://tempuri.org/IRetrieveEmployeeService/SearchByNameResponse")]
        Consumer.EmployeeServiceReference.Employee SearchByName(string Name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRetrieveEmployeeService/SearchByName", ReplyAction="http://tempuri.org/IRetrieveEmployeeService/SearchByNameResponse")]
        System.Threading.Tasks.Task<Consumer.EmployeeServiceReference.Employee> SearchByNameAsync(string Name);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRetrieveEmployeeServiceChannel : Consumer.EmployeeServiceReference.IRetrieveEmployeeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RetrieveEmployeeServiceClient : System.ServiceModel.ClientBase<Consumer.EmployeeServiceReference.IRetrieveEmployeeService>, Consumer.EmployeeServiceReference.IRetrieveEmployeeService {
        
        public RetrieveEmployeeServiceClient() {
        }
        
        public RetrieveEmployeeServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RetrieveEmployeeServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RetrieveEmployeeServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RetrieveEmployeeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Consumer.EmployeeServiceReference.Employee[] GetAllEmployees() {
            return base.Channel.GetAllEmployees();
        }
        
        public System.Threading.Tasks.Task<Consumer.EmployeeServiceReference.Employee[]> GetAllEmployeesAsync() {
            return base.Channel.GetAllEmployeesAsync();
        }
        
        public Consumer.EmployeeServiceReference.Employee SearchById(System.Guid Id) {
            return base.Channel.SearchById(Id);
        }
        
        public System.Threading.Tasks.Task<Consumer.EmployeeServiceReference.Employee> SearchByIdAsync(System.Guid Id) {
            return base.Channel.SearchByIdAsync(Id);
        }
        
        public Consumer.EmployeeServiceReference.Employee SearchByName(string Name) {
            return base.Channel.SearchByName(Name);
        }
        
        public System.Threading.Tasks.Task<Consumer.EmployeeServiceReference.Employee> SearchByNameAsync(string Name) {
            return base.Channel.SearchByNameAsync(Name);
        }
    }
}