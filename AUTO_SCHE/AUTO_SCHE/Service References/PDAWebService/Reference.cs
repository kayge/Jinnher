﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.17379
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace AUTO_SCHE.PDAWebService {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://intra.brightonbest.com/PDAServiceForVendor", ConfigurationName="PDAWebService.PDAServiceForVendorSoap")]
    public interface PDAServiceForVendorSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://intra.brightonbest.com/PDAServiceForVendor/UploadData", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        AUTO_SCHE.PDAWebService.Result UploadData(System.Data.DataSet PDA_DataSet, string ParamXML);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17379")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://intra.brightonbest.com/PDAServiceForVendor")]
    public partial class Result : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool successField;
        
        private string messageField;
        
        private int rowCountField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public bool success {
            get {
                return this.successField;
            }
            set {
                this.successField = value;
                this.RaisePropertyChanged("success");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
                this.RaisePropertyChanged("message");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int RowCount {
            get {
                return this.rowCountField;
            }
            set {
                this.rowCountField = value;
                this.RaisePropertyChanged("RowCount");
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
    public interface PDAServiceForVendorSoapChannel : AUTO_SCHE.PDAWebService.PDAServiceForVendorSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PDAServiceForVendorSoapClient : System.ServiceModel.ClientBase<AUTO_SCHE.PDAWebService.PDAServiceForVendorSoap>, AUTO_SCHE.PDAWebService.PDAServiceForVendorSoap {
        
        public PDAServiceForVendorSoapClient() {
        }
        
        public PDAServiceForVendorSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PDAServiceForVendorSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PDAServiceForVendorSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PDAServiceForVendorSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public AUTO_SCHE.PDAWebService.Result UploadData(System.Data.DataSet PDA_DataSet, string ParamXML) {
            return base.Channel.UploadData(PDA_DataSet, ParamXML);
        }
    }
}
