﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.1.
// 
#pragma warning disable 1591

namespace SSOLib.Service {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="AuthServiceSoap", Namespace="http://tempuri.org/")]
    public partial class AuthService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback AuthenticateOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetUserByUniqueIdOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetUserByTokenOperationCompleted;
        
        private System.Threading.SendOrPostCallback IsUserLoggedInOperationCompleted;
        
        private System.Threading.SendOrPostCallback IsValidRequestOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetUserStautsOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public AuthService() {
            this.Url = global::SSOLib.Properties.Settings.Default.SSOLib_Service_AuthService;
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
        public event AuthenticateCompletedEventHandler AuthenticateCompleted;
        
        /// <remarks/>
        public event GetUserByUniqueIdCompletedEventHandler GetUserByUniqueIdCompleted;
        
        /// <remarks/>
        public event GetUserByTokenCompletedEventHandler GetUserByTokenCompleted;
        
        /// <remarks/>
        public event IsUserLoggedInCompletedEventHandler IsUserLoggedInCompleted;
        
        /// <remarks/>
        public event IsValidRequestCompletedEventHandler IsValidRequestCompleted;
        
        /// <remarks/>
        public event GetUserStautsCompletedEventHandler GetUserStautsCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Authenticate", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public WebUser Authenticate(string UserName, string Password) {
            object[] results = this.Invoke("Authenticate", new object[] {
                        UserName,
                        Password});
            return ((WebUser)(results[0]));
        }
        
        /// <remarks/>
        public void AuthenticateAsync(string UserName, string Password) {
            this.AuthenticateAsync(UserName, Password, null);
        }
        
        /// <remarks/>
        public void AuthenticateAsync(string UserName, string Password, object userState) {
            if ((this.AuthenticateOperationCompleted == null)) {
                this.AuthenticateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAuthenticateOperationCompleted);
            }
            this.InvokeAsync("Authenticate", new object[] {
                        UserName,
                        Password}, this.AuthenticateOperationCompleted, userState);
        }
        
        private void OnAuthenticateOperationCompleted(object arg) {
            if ((this.AuthenticateCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AuthenticateCompleted(this, new AuthenticateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetUserByUniqueId", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public WebUser GetUserByUniqueId(string UniqueId) {
            object[] results = this.Invoke("GetUserByUniqueId", new object[] {
                        UniqueId});
            return ((WebUser)(results[0]));
        }
        
        /// <remarks/>
        public void GetUserByUniqueIdAsync(string UniqueId) {
            this.GetUserByUniqueIdAsync(UniqueId, null);
        }
        
        /// <remarks/>
        public void GetUserByUniqueIdAsync(string UniqueId, object userState) {
            if ((this.GetUserByUniqueIdOperationCompleted == null)) {
                this.GetUserByUniqueIdOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetUserByUniqueIdOperationCompleted);
            }
            this.InvokeAsync("GetUserByUniqueId", new object[] {
                        UniqueId}, this.GetUserByUniqueIdOperationCompleted, userState);
        }
        
        private void OnGetUserByUniqueIdOperationCompleted(object arg) {
            if ((this.GetUserByUniqueIdCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetUserByUniqueIdCompleted(this, new GetUserByUniqueIdCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetUserByToken", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public WebUser GetUserByToken(string Token) {
            object[] results = this.Invoke("GetUserByToken", new object[] {
                        Token});
            return ((WebUser)(results[0]));
        }
        
        /// <remarks/>
        public void GetUserByTokenAsync(string Token) {
            this.GetUserByTokenAsync(Token, null);
        }
        
        /// <remarks/>
        public void GetUserByTokenAsync(string Token, object userState) {
            if ((this.GetUserByTokenOperationCompleted == null)) {
                this.GetUserByTokenOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetUserByTokenOperationCompleted);
            }
            this.InvokeAsync("GetUserByToken", new object[] {
                        Token}, this.GetUserByTokenOperationCompleted, userState);
        }
        
        private void OnGetUserByTokenOperationCompleted(object arg) {
            if ((this.GetUserByTokenCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetUserByTokenCompleted(this, new GetUserByTokenCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IsUserLoggedIn", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool IsUserLoggedIn(string Token) {
            object[] results = this.Invoke("IsUserLoggedIn", new object[] {
                        Token});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void IsUserLoggedInAsync(string Token) {
            this.IsUserLoggedInAsync(Token, null);
        }
        
        /// <remarks/>
        public void IsUserLoggedInAsync(string Token, object userState) {
            if ((this.IsUserLoggedInOperationCompleted == null)) {
                this.IsUserLoggedInOperationCompleted = new System.Threading.SendOrPostCallback(this.OnIsUserLoggedInOperationCompleted);
            }
            this.InvokeAsync("IsUserLoggedIn", new object[] {
                        Token}, this.IsUserLoggedInOperationCompleted, userState);
        }
        
        private void OnIsUserLoggedInOperationCompleted(object arg) {
            if ((this.IsUserLoggedInCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.IsUserLoggedInCompleted(this, new IsUserLoggedInCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IsValidRequest", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool IsValidRequest(string RedirectId) {
            object[] results = this.Invoke("IsValidRequest", new object[] {
                        RedirectId});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void IsValidRequestAsync(string RedirectId) {
            this.IsValidRequestAsync(RedirectId, null);
        }
        
        /// <remarks/>
        public void IsValidRequestAsync(string RedirectId, object userState) {
            if ((this.IsValidRequestOperationCompleted == null)) {
                this.IsValidRequestOperationCompleted = new System.Threading.SendOrPostCallback(this.OnIsValidRequestOperationCompleted);
            }
            this.InvokeAsync("IsValidRequest", new object[] {
                        RedirectId}, this.IsValidRequestOperationCompleted, userState);
        }
        
        private void OnIsValidRequestOperationCompleted(object arg) {
            if ((this.IsValidRequestCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.IsValidRequestCompleted(this, new IsValidRequestCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetUserStauts", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public UserStatus GetUserStauts(string Token, string RequestId) {
            object[] results = this.Invoke("GetUserStauts", new object[] {
                        Token,
                        RequestId});
            return ((UserStatus)(results[0]));
        }
        
        /// <remarks/>
        public void GetUserStautsAsync(string Token, string RequestId) {
            this.GetUserStautsAsync(Token, RequestId, null);
        }
        
        /// <remarks/>
        public void GetUserStautsAsync(string Token, string RequestId, object userState) {
            if ((this.GetUserStautsOperationCompleted == null)) {
                this.GetUserStautsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetUserStautsOperationCompleted);
            }
            this.InvokeAsync("GetUserStauts", new object[] {
                        Token,
                        RequestId}, this.GetUserStautsOperationCompleted, userState);
        }
        
        private void OnGetUserStautsOperationCompleted(object arg) {
            if ((this.GetUserStautsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetUserStautsCompleted(this, new GetUserStautsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class WebUser {
        
        private string uniqueIdField;
        
        private string tokenField;
        
        private string userNameField;
        
        private string firstNameField;
        
        private string lastNameField;
        
        /// <remarks/>
        public string UniqueId {
            get {
                return this.uniqueIdField;
            }
            set {
                this.uniqueIdField = value;
            }
        }
        
        /// <remarks/>
        public string Token {
            get {
                return this.tokenField;
            }
            set {
                this.tokenField = value;
            }
        }
        
        /// <remarks/>
        public string UserName {
            get {
                return this.userNameField;
            }
            set {
                this.userNameField = value;
            }
        }
        
        /// <remarks/>
        public string FirstName {
            get {
                return this.firstNameField;
            }
            set {
                this.firstNameField = value;
            }
        }
        
        /// <remarks/>
        public string LastName {
            get {
                return this.lastNameField;
            }
            set {
                this.lastNameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class UserStatus {
        
        private bool userLoggedInField;
        
        private bool requestIdValidField;
        
        /// <remarks/>
        public bool UserLoggedIn {
            get {
                return this.userLoggedInField;
            }
            set {
                this.userLoggedInField = value;
            }
        }
        
        /// <remarks/>
        public bool RequestIdValid {
            get {
                return this.requestIdValidField;
            }
            set {
                this.requestIdValidField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void AuthenticateCompletedEventHandler(object sender, AuthenticateCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AuthenticateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AuthenticateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public WebUser Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((WebUser)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetUserByUniqueIdCompletedEventHandler(object sender, GetUserByUniqueIdCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetUserByUniqueIdCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetUserByUniqueIdCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public WebUser Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((WebUser)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetUserByTokenCompletedEventHandler(object sender, GetUserByTokenCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetUserByTokenCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetUserByTokenCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public WebUser Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((WebUser)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void IsUserLoggedInCompletedEventHandler(object sender, IsUserLoggedInCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class IsUserLoggedInCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal IsUserLoggedInCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void IsValidRequestCompletedEventHandler(object sender, IsValidRequestCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class IsValidRequestCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal IsValidRequestCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetUserStautsCompletedEventHandler(object sender, GetUserStautsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetUserStautsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetUserStautsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public UserStatus Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((UserStatus)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591