﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18408
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace BasicFramework.Web.ESPService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EmailSending", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class EmailSending : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IDField;
        
        private int ProjectIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProjectNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailTitleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailAddField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailSendContentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] EmailAnnexField;
        
        private System.DateTime CreateTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CreatorField;
        
        private bool IsSendField;
        
        private bool SendStatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RemarkField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ToCCField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AnnexNameField;
        
        private System.DateTime DateTime1Field;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string ID {
            get {
                return this.IDField;
            }
            set {
                if ((object.ReferenceEquals(this.IDField, value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int ProjectID {
            get {
                return this.ProjectIDField;
            }
            set {
                if ((this.ProjectIDField.Equals(value) != true)) {
                    this.ProjectIDField = value;
                    this.RaisePropertyChanged("ProjectID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string ProjectName {
            get {
                return this.ProjectNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ProjectNameField, value) != true)) {
                    this.ProjectNameField = value;
                    this.RaisePropertyChanged("ProjectName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string EmailTitle {
            get {
                return this.EmailTitleField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailTitleField, value) != true)) {
                    this.EmailTitleField = value;
                    this.RaisePropertyChanged("EmailTitle");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string EmailAdd {
            get {
                return this.EmailAddField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailAddField, value) != true)) {
                    this.EmailAddField = value;
                    this.RaisePropertyChanged("EmailAdd");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string EmailSendContent {
            get {
                return this.EmailSendContentField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailSendContentField, value) != true)) {
                    this.EmailSendContentField = value;
                    this.RaisePropertyChanged("EmailSendContent");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public byte[] EmailAnnex {
            get {
                return this.EmailAnnexField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailAnnexField, value) != true)) {
                    this.EmailAnnexField = value;
                    this.RaisePropertyChanged("EmailAnnex");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=7)]
        public System.DateTime CreateTime {
            get {
                return this.CreateTimeField;
            }
            set {
                if ((this.CreateTimeField.Equals(value) != true)) {
                    this.CreateTimeField = value;
                    this.RaisePropertyChanged("CreateTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public string Creator {
            get {
                return this.CreatorField;
            }
            set {
                if ((object.ReferenceEquals(this.CreatorField, value) != true)) {
                    this.CreatorField = value;
                    this.RaisePropertyChanged("Creator");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=9)]
        public bool IsSend {
            get {
                return this.IsSendField;
            }
            set {
                if ((this.IsSendField.Equals(value) != true)) {
                    this.IsSendField = value;
                    this.RaisePropertyChanged("IsSend");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=10)]
        public bool SendStatus {
            get {
                return this.SendStatusField;
            }
            set {
                if ((this.SendStatusField.Equals(value) != true)) {
                    this.SendStatusField = value;
                    this.RaisePropertyChanged("SendStatus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=11)]
        public string Remark {
            get {
                return this.RemarkField;
            }
            set {
                if ((object.ReferenceEquals(this.RemarkField, value) != true)) {
                    this.RemarkField = value;
                    this.RaisePropertyChanged("Remark");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=12)]
        public string ToCC {
            get {
                return this.ToCCField;
            }
            set {
                if ((object.ReferenceEquals(this.ToCCField, value) != true)) {
                    this.ToCCField = value;
                    this.RaisePropertyChanged("ToCC");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=13)]
        public string AnnexName {
            get {
                return this.AnnexNameField;
            }
            set {
                if ((object.ReferenceEquals(this.AnnexNameField, value) != true)) {
                    this.AnnexNameField = value;
                    this.RaisePropertyChanged("AnnexName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=14)]
        public System.DateTime DateTime1 {
            get {
                return this.DateTime1Field;
            }
            set {
                if ((this.DateTime1Field.Equals(value) != true)) {
                    this.DateTime1Field = value;
                    this.RaisePropertyChanged("DateTime1");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ESPService.ESPServiceSoap")]
    public interface ESPServiceSoap {
        
        // CODEGEN: 命名空间 http://tempuri.org/ 的元素名称 EmailSending 以后生成的消息协定未标记为 nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddEmailSending", ReplyAction="*")]
        BasicFramework.Web.ESPService.AddEmailSendingResponse AddEmailSending(BasicFramework.Web.ESPService.AddEmailSendingRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddEmailSending", ReplyAction="*")]
        System.Threading.Tasks.Task<BasicFramework.Web.ESPService.AddEmailSendingResponse> AddEmailSendingAsync(BasicFramework.Web.ESPService.AddEmailSendingRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddEmailSendingRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AddEmailSending", Namespace="http://tempuri.org/", Order=0)]
        public BasicFramework.Web.ESPService.AddEmailSendingRequestBody Body;
        
        public AddEmailSendingRequest() {
        }
        
        public AddEmailSendingRequest(BasicFramework.Web.ESPService.AddEmailSendingRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class AddEmailSendingRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public BasicFramework.Web.ESPService.EmailSending EmailSending;
        
        public AddEmailSendingRequestBody() {
        }
        
        public AddEmailSendingRequestBody(BasicFramework.Web.ESPService.EmailSending EmailSending) {
            this.EmailSending = EmailSending;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddEmailSendingResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AddEmailSendingResponse", Namespace="http://tempuri.org/", Order=0)]
        public BasicFramework.Web.ESPService.AddEmailSendingResponseBody Body;
        
        public AddEmailSendingResponse() {
        }
        
        public AddEmailSendingResponse(BasicFramework.Web.ESPService.AddEmailSendingResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class AddEmailSendingResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool AddEmailSendingResult;
        
        public AddEmailSendingResponseBody() {
        }
        
        public AddEmailSendingResponseBody(bool AddEmailSendingResult) {
            this.AddEmailSendingResult = AddEmailSendingResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ESPServiceSoapChannel : BasicFramework.Web.ESPService.ESPServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ESPServiceSoapClient : System.ServiceModel.ClientBase<BasicFramework.Web.ESPService.ESPServiceSoap>, BasicFramework.Web.ESPService.ESPServiceSoap {
        
        public ESPServiceSoapClient() {
        }
        
        public ESPServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ESPServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ESPServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ESPServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        BasicFramework.Web.ESPService.AddEmailSendingResponse BasicFramework.Web.ESPService.ESPServiceSoap.AddEmailSending(BasicFramework.Web.ESPService.AddEmailSendingRequest request) {
            return base.Channel.AddEmailSending(request);
        }
        
        public bool AddEmailSending(BasicFramework.Web.ESPService.EmailSending EmailSending) {
            BasicFramework.Web.ESPService.AddEmailSendingRequest inValue = new BasicFramework.Web.ESPService.AddEmailSendingRequest();
            inValue.Body = new BasicFramework.Web.ESPService.AddEmailSendingRequestBody();
            inValue.Body.EmailSending = EmailSending;
            BasicFramework.Web.ESPService.AddEmailSendingResponse retVal = ((BasicFramework.Web.ESPService.ESPServiceSoap)(this)).AddEmailSending(inValue);
            return retVal.Body.AddEmailSendingResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<BasicFramework.Web.ESPService.AddEmailSendingResponse> BasicFramework.Web.ESPService.ESPServiceSoap.AddEmailSendingAsync(BasicFramework.Web.ESPService.AddEmailSendingRequest request) {
            return base.Channel.AddEmailSendingAsync(request);
        }
        
        public System.Threading.Tasks.Task<BasicFramework.Web.ESPService.AddEmailSendingResponse> AddEmailSendingAsync(BasicFramework.Web.ESPService.EmailSending EmailSending) {
            BasicFramework.Web.ESPService.AddEmailSendingRequest inValue = new BasicFramework.Web.ESPService.AddEmailSendingRequest();
            inValue.Body = new BasicFramework.Web.ESPService.AddEmailSendingRequestBody();
            inValue.Body.EmailSending = EmailSending;
            return ((BasicFramework.Web.ESPService.ESPServiceSoap)(this)).AddEmailSendingAsync(inValue);
        }
    }
}
