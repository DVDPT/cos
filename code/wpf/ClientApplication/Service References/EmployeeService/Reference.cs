﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientApplication.EmployeeService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TwitterStudy", Namespace="http://schemas.datacontract.org/2004/07/BrandAnalytics.Data")]
    [System.SerializableAttribute()]
    public partial class TwitterStudy : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BrandField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ClientIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ClientApplication.EmployeeService.TwitterStudyStates CurrentStateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.TimeSpan DurationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int EmployeeIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ClientApplication.EmployeeService.TwitterStudyReport ReportField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] TopicsField;
        
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
        public string Brand {
            get {
                return this.BrandField;
            }
            set {
                if ((object.ReferenceEquals(this.BrandField, value) != true)) {
                    this.BrandField = value;
                    this.RaisePropertyChanged("Brand");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ClientId {
            get {
                return this.ClientIdField;
            }
            set {
                if ((this.ClientIdField.Equals(value) != true)) {
                    this.ClientIdField = value;
                    this.RaisePropertyChanged("ClientId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ClientApplication.EmployeeService.TwitterStudyStates CurrentState {
            get {
                return this.CurrentStateField;
            }
            set {
                if ((this.CurrentStateField.Equals(value) != true)) {
                    this.CurrentStateField = value;
                    this.RaisePropertyChanged("CurrentState");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.TimeSpan Duration {
            get {
                return this.DurationField;
            }
            set {
                if ((this.DurationField.Equals(value) != true)) {
                    this.DurationField = value;
                    this.RaisePropertyChanged("Duration");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int EmployeeId {
            get {
                return this.EmployeeIdField;
            }
            set {
                if ((this.EmployeeIdField.Equals(value) != true)) {
                    this.EmployeeIdField = value;
                    this.RaisePropertyChanged("EmployeeId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
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
        public ClientApplication.EmployeeService.TwitterStudyReport Report {
            get {
                return this.ReportField;
            }
            set {
                if ((object.ReferenceEquals(this.ReportField, value) != true)) {
                    this.ReportField = value;
                    this.RaisePropertyChanged("Report");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Topics {
            get {
                return this.TopicsField;
            }
            set {
                if ((object.ReferenceEquals(this.TopicsField, value) != true)) {
                    this.TopicsField = value;
                    this.RaisePropertyChanged("Topics");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="TwitterStudyReport", Namespace="http://schemas.datacontract.org/2004/07/BrandAnalytics.Data")]
    [System.SerializableAttribute()]
    public partial class TwitterStudyReport : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] FrequentTermsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int NrOfAuthorsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int NrOfTweetsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int StudyidField;
        
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
        public string[] FrequentTerms {
            get {
                return this.FrequentTermsField;
            }
            set {
                if ((object.ReferenceEquals(this.FrequentTermsField, value) != true)) {
                    this.FrequentTermsField = value;
                    this.RaisePropertyChanged("FrequentTerms");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int NrOfAuthors {
            get {
                return this.NrOfAuthorsField;
            }
            set {
                if ((this.NrOfAuthorsField.Equals(value) != true)) {
                    this.NrOfAuthorsField = value;
                    this.RaisePropertyChanged("NrOfAuthors");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int NrOfTweets {
            get {
                return this.NrOfTweetsField;
            }
            set {
                if ((this.NrOfTweetsField.Equals(value) != true)) {
                    this.NrOfTweetsField = value;
                    this.RaisePropertyChanged("NrOfTweets");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Studyid {
            get {
                return this.StudyidField;
            }
            set {
                if ((this.StudyidField.Equals(value) != true)) {
                    this.StudyidField = value;
                    this.RaisePropertyChanged("Studyid");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TwitterStudyStates", Namespace="http://schemas.datacontract.org/2004/07/BrandAnalytics.Data")]
    public enum TwitterStudyStates : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Pending = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Started = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Completed = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Revision = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Canceled = 4,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmployeeService.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetPendingStudies", ReplyAction="http://tempuri.org/IService/GetPendingStudiesResponse")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="parameter1")]
        ClientApplication.EmployeeService.TwitterStudy[] GetPendingStudies(int employeeId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetPendingStudies", ReplyAction="http://tempuri.org/IService/GetPendingStudiesResponse")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="parameter1")]
        System.Threading.Tasks.Task<ClientApplication.EmployeeService.TwitterStudy[]> GetPendingStudiesAsync(int employeeId);
        
        // CODEGEN: Generating message contract since the operation StartStudy is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/StartStudy", ReplyAction="http://tempuri.org/IService/StartStudyResponse")]
        ClientApplication.EmployeeService.StartStudyResponse StartStudy(ClientApplication.EmployeeService.StartStudyRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/StartStudy", ReplyAction="http://tempuri.org/IService/StartStudyResponse")]
        System.Threading.Tasks.Task<ClientApplication.EmployeeService.StartStudyResponse> StartStudyAsync(ClientApplication.EmployeeService.StartStudyRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="StartStudy", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class StartStudyRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public int studyId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string[] topics;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public System.TimeSpan duration;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public int employeeId;
        
        public StartStudyRequest() {
        }
        
        public StartStudyRequest(int studyId, string[] topics, System.TimeSpan duration, int employeeId) {
            this.studyId = studyId;
            this.topics = topics;
            this.duration = duration;
            this.employeeId = employeeId;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class StartStudyResponse {
        
        public StartStudyResponse() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : ClientApplication.EmployeeService.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<ClientApplication.EmployeeService.IService>, ClientApplication.EmployeeService.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ClientApplication.EmployeeService.TwitterStudy[] GetPendingStudies(int employeeId) {
            return base.Channel.GetPendingStudies(employeeId);
        }
        
        public System.Threading.Tasks.Task<ClientApplication.EmployeeService.TwitterStudy[]> GetPendingStudiesAsync(int employeeId) {
            return base.Channel.GetPendingStudiesAsync(employeeId);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ClientApplication.EmployeeService.StartStudyResponse ClientApplication.EmployeeService.IService.StartStudy(ClientApplication.EmployeeService.StartStudyRequest request) {
            return base.Channel.StartStudy(request);
        }
        
        public void StartStudy(int studyId, string[] topics, System.TimeSpan duration, int employeeId) {
            ClientApplication.EmployeeService.StartStudyRequest inValue = new ClientApplication.EmployeeService.StartStudyRequest();
            inValue.studyId = studyId;
            inValue.topics = topics;
            inValue.duration = duration;
            inValue.employeeId = employeeId;
            ClientApplication.EmployeeService.StartStudyResponse retVal = ((ClientApplication.EmployeeService.IService)(this)).StartStudy(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ClientApplication.EmployeeService.StartStudyResponse> ClientApplication.EmployeeService.IService.StartStudyAsync(ClientApplication.EmployeeService.StartStudyRequest request) {
            return base.Channel.StartStudyAsync(request);
        }
        
        public System.Threading.Tasks.Task<ClientApplication.EmployeeService.StartStudyResponse> StartStudyAsync(int studyId, string[] topics, System.TimeSpan duration, int employeeId) {
            ClientApplication.EmployeeService.StartStudyRequest inValue = new ClientApplication.EmployeeService.StartStudyRequest();
            inValue.studyId = studyId;
            inValue.topics = topics;
            inValue.duration = duration;
            inValue.employeeId = employeeId;
            return ((ClientApplication.EmployeeService.IService)(this)).StartStudyAsync(inValue);
        }
    }
}
