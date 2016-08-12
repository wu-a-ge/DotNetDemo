﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18444
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 4.0.30319.18444 版自动生成。
// 
#pragma warning disable 1591

namespace VS2010.ConsoleApp.Test.ReaderInfoService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ReaderInfoServiceSoapBinding", Namespace="http://vipcloud.cqvip.com/vipCloud/webService/ReaderInfo/service")]
    public partial class ReaderInfoService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback addOperationCompleted;
        
        private System.Threading.SendOrPostCallback deleteOperationCompleted;
        
        private System.Threading.SendOrPostCallback updateOperationCompleted;
        
        private System.Threading.SendOrPostCallback getListsByPageOperationCompleted;
        
        private System.Threading.SendOrPostCallback getUserInfoOperationCompleted;
        
        private System.Threading.SendOrPostCallback countsOperationCompleted;
        
        private System.Threading.SendOrPostCallback getListsByIdsOperationCompleted;
        
        private System.Threading.SendOrPostCallback countsByGroupOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ReaderInfoService() {
            this.Url = global::VS2010.ConsoleApp.Test.Properties.Settings.Default.VS2010_ConsoleApp_Test_ReaderInfoService_ReaderInfoService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event addCompletedEventHandler addCompleted;
        
        /// <remarks/>
        public event deleteCompletedEventHandler deleteCompleted;
        
        /// <remarks/>
        public event updateCompletedEventHandler updateCompleted;
        
        /// <remarks/>
        public event getListsByPageCompletedEventHandler getListsByPageCompleted;
        
        /// <remarks/>
        public event getUserInfoCompletedEventHandler getUserInfoCompleted;
        
        /// <remarks/>
        public event countsCompletedEventHandler countsCompleted;
        
        /// <remarks/>
        public event getListsByIdsCompletedEventHandler getListsByIdsCompleted;
        
        /// <remarks/>
        public event countsByGroupCompletedEventHandler countsByGroupCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://vipcloud.cqvip.com/vipCloud/webService/ReaderInfo", ResponseNamespace="http://vipcloud.cqvip.com/vipCloud/webService/ReaderInfo", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public results add([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string readers) {
            object[] results = this.Invoke("add", new object[] {
                        readers});
            return ((results)(results[0]));
        }
        
        /// <remarks/>
        public void addAsync(string readers) {
            this.addAsync(readers, null);
        }
        
        /// <remarks/>
        public void addAsync(string readers, object userState) {
            if ((this.addOperationCompleted == null)) {
                this.addOperationCompleted = new System.Threading.SendOrPostCallback(this.OnaddOperationCompleted);
            }
            this.InvokeAsync("add", new object[] {
                        readers}, this.addOperationCompleted, userState);
        }
        
        private void OnaddOperationCompleted(object arg) {
            if ((this.addCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.addCompleted(this, new addCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://vipcloud.cqvip.com/vipCloud/webService/ReaderInfo", ResponseNamespace="http://vipcloud.cqvip.com/vipCloud/webService/ReaderInfo", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public results delete([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string ids) {
            object[] results = this.Invoke("delete", new object[] {
                        ids});
            return ((results)(results[0]));
        }
        
        /// <remarks/>
        public void deleteAsync(string ids) {
            this.deleteAsync(ids, null);
        }
        
        /// <remarks/>
        public void deleteAsync(string ids, object userState) {
            if ((this.deleteOperationCompleted == null)) {
                this.deleteOperationCompleted = new System.Threading.SendOrPostCallback(this.OndeleteOperationCompleted);
            }
            this.InvokeAsync("delete", new object[] {
                        ids}, this.deleteOperationCompleted, userState);
        }
        
        private void OndeleteOperationCompleted(object arg) {
            if ((this.deleteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.deleteCompleted(this, new deleteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://vipcloud.cqvip.com/vipCloud/webService/ReaderInfo", ResponseNamespace="http://vipcloud.cqvip.com/vipCloud/webService/ReaderInfo", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public results update([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string readers) {
            object[] results = this.Invoke("update", new object[] {
                        readers});
            return ((results)(results[0]));
        }
        
        /// <remarks/>
        public void updateAsync(string readers) {
            this.updateAsync(readers, null);
        }
        
        /// <remarks/>
        public void updateAsync(string readers, object userState) {
            if ((this.updateOperationCompleted == null)) {
                this.updateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnupdateOperationCompleted);
            }
            this.InvokeAsync("update", new object[] {
                        readers}, this.updateOperationCompleted, userState);
        }
        
        private void OnupdateOperationCompleted(object arg) {
            if ((this.updateCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.updateCompleted(this, new updateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://vipcloud.cqvip.com/vipCloud/webService/ReaderInfo", ResponseNamespace="http://vipcloud.cqvip.com/vipCloud/webService/ReaderInfo", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public results getListsByPage([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] int pageIndex, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] int pageSize, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string where, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string selector, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string orderby, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] bool isAsc) {
            object[] results = this.Invoke("getListsByPage", new object[] {
                        pageIndex,
                        pageSize,
                        where,
                        selector,
                        orderby,
                        isAsc});
            return ((results)(results[0]));
        }
        
        /// <remarks/>
        public void getListsByPageAsync(int pageIndex, int pageSize, string where, string selector, string orderby, bool isAsc) {
            this.getListsByPageAsync(pageIndex, pageSize, where, selector, orderby, isAsc, null);
        }
        
        /// <remarks/>
        public void getListsByPageAsync(int pageIndex, int pageSize, string where, string selector, string orderby, bool isAsc, object userState) {
            if ((this.getListsByPageOperationCompleted == null)) {
                this.getListsByPageOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetListsByPageOperationCompleted);
            }
            this.InvokeAsync("getListsByPage", new object[] {
                        pageIndex,
                        pageSize,
                        where,
                        selector,
                        orderby,
                        isAsc}, this.getListsByPageOperationCompleted, userState);
        }
        
        private void OngetListsByPageOperationCompleted(object arg) {
            if ((this.getListsByPageCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getListsByPageCompleted(this, new getListsByPageCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://vipcloud.cqvip.com/vipCloud/webService/ReaderInfo", ResponseNamespace="http://vipcloud.cqvip.com/vipCloud/webService/ReaderInfo", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public results getUserInfo([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string loginName, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string password) {
            object[] results = this.Invoke("getUserInfo", new object[] {
                        loginName,
                        password});
            return ((results)(results[0]));
        }
        
        /// <remarks/>
        public void getUserInfoAsync(string loginName, string password) {
            this.getUserInfoAsync(loginName, password, null);
        }
        
        /// <remarks/>
        public void getUserInfoAsync(string loginName, string password, object userState) {
            if ((this.getUserInfoOperationCompleted == null)) {
                this.getUserInfoOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetUserInfoOperationCompleted);
            }
            this.InvokeAsync("getUserInfo", new object[] {
                        loginName,
                        password}, this.getUserInfoOperationCompleted, userState);
        }
        
        private void OngetUserInfoOperationCompleted(object arg) {
            if ((this.getUserInfoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getUserInfoCompleted(this, new getUserInfoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://vipcloud.cqvip.com/vipCloud/webService/ReaderInfo", ResponseNamespace="http://vipcloud.cqvip.com/vipCloud/webService/ReaderInfo", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public results counts([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string where) {
            object[] results = this.Invoke("counts", new object[] {
                        where});
            return ((results)(results[0]));
        }
        
        /// <remarks/>
        public void countsAsync(string where) {
            this.countsAsync(where, null);
        }
        
        /// <remarks/>
        public void countsAsync(string where, object userState) {
            if ((this.countsOperationCompleted == null)) {
                this.countsOperationCompleted = new System.Threading.SendOrPostCallback(this.OncountsOperationCompleted);
            }
            this.InvokeAsync("counts", new object[] {
                        where}, this.countsOperationCompleted, userState);
        }
        
        private void OncountsOperationCompleted(object arg) {
            if ((this.countsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.countsCompleted(this, new countsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://vipcloud.cqvip.com/vipCloud/webService/ReaderInfo", ResponseNamespace="http://vipcloud.cqvip.com/vipCloud/webService/ReaderInfo", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public results getListsByIds([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string ids, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string selector) {
            object[] results = this.Invoke("getListsByIds", new object[] {
                        ids,
                        selector});
            return ((results)(results[0]));
        }
        
        /// <remarks/>
        public void getListsByIdsAsync(string ids, string selector) {
            this.getListsByIdsAsync(ids, selector, null);
        }
        
        /// <remarks/>
        public void getListsByIdsAsync(string ids, string selector, object userState) {
            if ((this.getListsByIdsOperationCompleted == null)) {
                this.getListsByIdsOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetListsByIdsOperationCompleted);
            }
            this.InvokeAsync("getListsByIds", new object[] {
                        ids,
                        selector}, this.getListsByIdsOperationCompleted, userState);
        }
        
        private void OngetListsByIdsOperationCompleted(object arg) {
            if ((this.getListsByIdsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getListsByIdsCompleted(this, new getListsByIdsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://vipcloud.cqvip.com/vipCloud/webService/ReaderInfo", ResponseNamespace="http://vipcloud.cqvip.com/vipCloud/webService/ReaderInfo", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public results countsByGroup([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string where, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string groupName) {
            object[] results = this.Invoke("countsByGroup", new object[] {
                        where,
                        groupName});
            return ((results)(results[0]));
        }
        
        /// <remarks/>
        public void countsByGroupAsync(string where, string groupName) {
            this.countsByGroupAsync(where, groupName, null);
        }
        
        /// <remarks/>
        public void countsByGroupAsync(string where, string groupName, object userState) {
            if ((this.countsByGroupOperationCompleted == null)) {
                this.countsByGroupOperationCompleted = new System.Threading.SendOrPostCallback(this.OncountsByGroupOperationCompleted);
            }
            this.InvokeAsync("countsByGroup", new object[] {
                        where,
                        groupName}, this.countsByGroupOperationCompleted, userState);
        }
        
        private void OncountsByGroupOperationCompleted(object arg) {
            if ((this.countsByGroupCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.countsByGroupCompleted(this, new countsByGroupCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://vipcloud.cqvip.com/vipCloud/webService/ReaderInfo")]
    public partial class results {
        
        private int countsField;
        
        private string dataField;
        
        private string descField;
        
        private bool exceptionField;
        
        private bool successField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int counts {
            get {
                return this.countsField;
            }
            set {
                this.countsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string data {
            get {
                return this.dataField;
            }
            set {
                this.dataField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string desc {
            get {
                return this.descField;
            }
            set {
                this.descField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool exception {
            get {
                return this.exceptionField;
            }
            set {
                this.exceptionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool success {
            get {
                return this.successField;
            }
            set {
                this.successField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void addCompletedEventHandler(object sender, addCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class addCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal addCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public results Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((results)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void deleteCompletedEventHandler(object sender, deleteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class deleteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal deleteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public results Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((results)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void updateCompletedEventHandler(object sender, updateCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class updateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal updateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public results Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((results)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void getListsByPageCompletedEventHandler(object sender, getListsByPageCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getListsByPageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getListsByPageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public results Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((results)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void getUserInfoCompletedEventHandler(object sender, getUserInfoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getUserInfoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getUserInfoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public results Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((results)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void countsCompletedEventHandler(object sender, countsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class countsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal countsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public results Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((results)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void getListsByIdsCompletedEventHandler(object sender, getListsByIdsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getListsByIdsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getListsByIdsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public results Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((results)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void countsByGroupCompletedEventHandler(object sender, countsByGroupCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class countsByGroupCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal countsByGroupCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public results Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((results)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591