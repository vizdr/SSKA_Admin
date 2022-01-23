//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Original file name:
// Generation date: 08.03.2017 09:06:32
namespace WpfAppWS11.ServiceReference1
{
    
    /// <summary>
    /// There are no comments for WcfDSUsersEntities in the schema.
    /// </summary>
    public partial class WcfDSUsersEntities : global::System.Data.Services.Client.DataServiceContext
    {
        /// <summary>
        /// Initialize a new WcfDSUsersEntities object.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public WcfDSUsersEntities(global::System.Uri serviceRoot) : 
                base(serviceRoot, global::System.Data.Services.Common.DataServiceProtocolVersion.V3)
        {
            this.ResolveName = new global::System.Func<global::System.Type, string>(this.ResolveNameFromType);
            this.ResolveType = new global::System.Func<string, global::System.Type>(this.ResolveTypeFromName);
            this.OnContextCreated();
            this.Format.LoadServiceModel = GeneratedEdmModel.GetInstance;
        }
        partial void OnContextCreated();
        /// <summary>
        /// Since the namespace configured for this service reference
        /// in Visual Studio is different from the one indicated in the
        /// server schema, use type-mappers to map between the two.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected global::System.Type ResolveTypeFromName(string typeName)
        {
            global::System.Type resolvedType = this.DefaultResolveType(typeName, "WcfDSUsersModel", "WpfAppWS11.ServiceReference1");
            if ((resolvedType != null))
            {
                return resolvedType;
            }
            return null;
        }
        /// <summary>
        /// Since the namespace configured for this service reference
        /// in Visual Studio is different from the one indicated in the
        /// server schema, use type-mappers to map between the two.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected string ResolveNameFromType(global::System.Type clientType)
        {
            if (clientType.Namespace.Equals("WpfAppWS11.ServiceReference1", global::System.StringComparison.Ordinal))
            {
                return string.Concat("WcfDSUsersModel.", clientType.Name);
            }
            return null;
        }
        /// <summary>
        /// There are no comments for AcceptanceSets in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<AcceptanceSet> AcceptanceSets
        {
            get
            {
                if ((this._AcceptanceSets == null))
                {
                    this._AcceptanceSets = base.CreateQuery<AcceptanceSet>("AcceptanceSets");
                }
                return this._AcceptanceSets;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<AcceptanceSet> _AcceptanceSets;
        /// <summary>
        /// There are no comments for Accounts in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Account> Accounts
        {
            get
            {
                if ((this._Accounts == null))
                {
                    this._Accounts = base.CreateQuery<Account>("Accounts");
                }
                return this._Accounts;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Account> _Accounts;
        /// <summary>
        /// There are no comments for AcceptanceSets in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToAcceptanceSets(AcceptanceSet acceptanceSet)
        {
            base.AddObject("AcceptanceSets", acceptanceSet);
        }
        /// <summary>
        /// There are no comments for Accounts in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToAccounts(Account account)
        {
            base.AddObject("Accounts", account);
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private abstract class GeneratedEdmModel
        {
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            private static global::Microsoft.Data.Edm.IEdmModel ParsedModel = LoadModelFromString();
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            private const string ModelPart0 = "<edmx:Edmx Version=\"1.0\" xmlns:edmx=\"http://schemas.microsoft.com/ado/2007/06/edm" +
                "x\"><edmx:DataServices m:DataServiceVersion=\"1.0\" m:MaxDataServiceVersion=\"3.0\" x" +
                "mlns:m=\"http://schemas.microsoft.com/ado/2007/08/dataservices/metadata\"><Schema " +
                "Namespace=\"WcfDSUsersModel\" xmlns=\"http://schemas.microsoft.com/ado/2009/11/edm\"" +
                "><EntityType Name=\"AcceptanceSet\"><Key><PropertyRef Name=\"Id\" /></Key><Property " +
                "Name=\"Id\" Type=\"Edm.Int32\" Nullable=\"false\" p6:StoreGeneratedPattern=\"Identity\" " +
                "xmlns:p6=\"http://schemas.microsoft.com/ado/2009/02/edm/annotation\" /><Property N" +
                "ame=\"IsAcceptEmailSent\" Type=\"Edm.Boolean\" Nullable=\"false\" /><Property Name=\"Ac" +
                "ceptEmailDate\" Type=\"Edm.DateTime\" Precision=\"3\" /><Property Name=\"AuthReqCode\" " +
                "Type=\"Edm.String\" Nullable=\"false\" MaxLength=\"Max\" FixedLength=\"false\" Unicode=\"" +
                "true\" /><Property Name=\"RequestDate\" Type=\"Edm.DateTime\" Nullable=\"false\" Precis" +
                "ion=\"3\" /><Property Name=\"AuthCode\" Type=\"Edm.String\" MaxLength=\"Max\" FixedLengt" +
                "h=\"false\" Unicode=\"true\" /><Property Name=\"Account_Id\" Type=\"Edm.Int32\" Nullable" +
                "=\"false\" /><NavigationProperty Name=\"Account\" Relationship=\"WcfDSUsersModel.FK_A" +
                "ccountAcceptance\" ToRole=\"Accounts\" FromRole=\"AcceptanceSet\" /></EntityType><Ent" +
                "ityType Name=\"Account\"><Key><PropertyRef Name=\"Id\" /></Key><Property Name=\"Id\" T" +
                "ype=\"Edm.Int32\" Nullable=\"false\" p6:StoreGeneratedPattern=\"Identity\" xmlns:p6=\"h" +
                "ttp://schemas.microsoft.com/ado/2009/02/edm/annotation\" /><Property Name=\"IsRequ" +
                "estOpen\" Type=\"Edm.Boolean\" /><Property Name=\"IsAcceptedAR\" Type=\"Edm.Boolean\" /" +
                "><Property Name=\"IsPaid\" Type=\"Edm.Boolean\" Nullable=\"false\" /><Property Name=\"I" +
                "sSentACEmail\" Type=\"Edm.Boolean\" Nullable=\"false\" /><Property Name=\"UserEmail\" T" +
                "ype=\"Edm.String\" Nullable=\"false\" MaxLength=\"50\" FixedLength=\"false\" Unicode=\"tr" +
                "ue\" /><Property Name=\"UserName\" Type=\"Edm.String\" Nullable=\"false\" MaxLength=\"50" +
                "\" FixedLength=\"false\" Unicode=\"true\" /><Property Name=\"UserFirstName\" Type=\"Edm." +
                "String\" MaxLength=\"50\" FixedLength=\"false\" Unicode=\"true\" /><NavigationProperty " +
                "Name=\"AcceptanceSets\" Relationship=\"WcfDSUsersModel.FK_AccountAcceptance\" ToRole" +
                "=\"AcceptanceSet\" FromRole=\"Accounts\" /></EntityType><Association Name=\"FK_Accoun" +
                "tAcceptance\"><End Type=\"WcfDSUsersModel.Account\" Role=\"Accounts\" Multiplicity=\"1" +
                "\" /><End Type=\"WcfDSUsersModel.AcceptanceSet\" Role=\"AcceptanceSet\" Multiplicity=" +
                "\"*\" /><ReferentialConstraint><Principal Role=\"Accounts\"><PropertyRef Name=\"Id\" /" +
                "></Principal><Dependent Role=\"AcceptanceSet\"><PropertyRef Name=\"Account_Id\" /></" +
                "Dependent></ReferentialConstraint></Association></Schema><Schema Namespace=\"WcfS" +
                "er4\" xmlns=\"http://schemas.microsoft.com/ado/2009/11/edm\"><EntityContainer Name=" +
                "\"WcfDSUsersEntities\" m:IsDefaultEntityContainer=\"true\"><EntitySet Name=\"Acceptan" +
                "ceSets\" EntityType=\"WcfDSUsersModel.AcceptanceSet\" /><EntitySet Name=\"Accounts\" " +
                "EntityType=\"WcfDSUsersModel.Account\" /><AssociationSet Name=\"FK_AccountAcceptanc" +
                "e\" Association=\"WcfDSUsersModel.FK_AccountAcceptance\"><End Role=\"AcceptanceSet\" " +
                "EntitySet=\"AcceptanceSets\" /><End Role=\"Accounts\" EntitySet=\"Accounts\" /></Assoc" +
                "iationSet></EntityContainer></Schema></edmx:DataServices></edmx:Edmx>";
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            private static string GetConcatenatedEdmxString()
            {
                return string.Concat(ModelPart0);
            }
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            public static global::Microsoft.Data.Edm.IEdmModel GetInstance()
            {
                return ParsedModel;
            }
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            private static global::Microsoft.Data.Edm.IEdmModel LoadModelFromString()
            {
                string edmxToParse = GetConcatenatedEdmxString();
                global::System.Xml.XmlReader reader = CreateXmlReader(edmxToParse);
                try
                {
                    return global::Microsoft.Data.Edm.Csdl.EdmxReader.Parse(reader);
                }
                finally
                {
                    ((global::System.IDisposable)(reader)).Dispose();
                }
            }
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            private static global::System.Xml.XmlReader CreateXmlReader(string edmxToParse)
            {
                return global::System.Xml.XmlReader.Create(new global::System.IO.StringReader(edmxToParse));
            }
        }
    }
    /// <summary>
    /// There are no comments for WcfDSUsersModel.AcceptanceSet in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("AcceptanceSets")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("Id")]
    public partial class AcceptanceSet : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new AcceptanceSet object.
        /// </summary>
        /// <param name="ID">Initial value of Id.</param>
        /// <param name="isAcceptEmailSent">Initial value of IsAcceptEmailSent.</param>
        /// <param name="authReqCode">Initial value of AuthReqCode.</param>
        /// <param name="requestDate">Initial value of RequestDate.</param>
        /// <param name="account_Id">Initial value of Account_Id.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static AcceptanceSet CreateAcceptanceSet(int ID, bool isAcceptEmailSent, string authReqCode, global::System.DateTime requestDate, int account_Id)
        {
            AcceptanceSet acceptanceSet = new AcceptanceSet();
            acceptanceSet.Id = ID;
            acceptanceSet.IsAcceptEmailSent = isAcceptEmailSent;
            acceptanceSet.AuthReqCode = authReqCode;
            acceptanceSet.RequestDate = requestDate;
            acceptanceSet.Account_Id = account_Id;
            return acceptanceSet;
        }
        /// <summary>
        /// There are no comments for Property Id in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this.OnIdChanging(value);
                this._Id = value;
                this.OnIdChanged();
                this.OnPropertyChanged("Id");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _Id;
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        /// <summary>
        /// There are no comments for Property IsAcceptEmailSent in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public bool IsAcceptEmailSent
        {
            get
            {
                return this._IsAcceptEmailSent;
            }
            set
            {
                this.OnIsAcceptEmailSentChanging(value);
                this._IsAcceptEmailSent = value;
                this.OnIsAcceptEmailSentChanged();
                this.OnPropertyChanged("IsAcceptEmailSent");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private bool _IsAcceptEmailSent;
        partial void OnIsAcceptEmailSentChanging(bool value);
        partial void OnIsAcceptEmailSentChanged();
        /// <summary>
        /// There are no comments for Property AcceptEmailDate in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<global::System.DateTime> AcceptEmailDate
        {
            get
            {
                return this._AcceptEmailDate;
            }
            set
            {
                this.OnAcceptEmailDateChanging(value);
                this._AcceptEmailDate = value;
                this.OnAcceptEmailDateChanged();
                this.OnPropertyChanged("AcceptEmailDate");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<global::System.DateTime> _AcceptEmailDate;
        partial void OnAcceptEmailDateChanging(global::System.Nullable<global::System.DateTime> value);
        partial void OnAcceptEmailDateChanged();
        /// <summary>
        /// There are no comments for Property AuthReqCode in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string AuthReqCode
        {
            get
            {
                return this._AuthReqCode;
            }
            set
            {
                this.OnAuthReqCodeChanging(value);
                this._AuthReqCode = value;
                this.OnAuthReqCodeChanged();
                this.OnPropertyChanged("AuthReqCode");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _AuthReqCode;
        partial void OnAuthReqCodeChanging(string value);
        partial void OnAuthReqCodeChanged();
        /// <summary>
        /// There are no comments for Property RequestDate in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.DateTime RequestDate
        {
            get
            {
                return this._RequestDate;
            }
            set
            {
                this.OnRequestDateChanging(value);
                this._RequestDate = value;
                this.OnRequestDateChanged();
                this.OnPropertyChanged("RequestDate");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.DateTime _RequestDate;
        partial void OnRequestDateChanging(global::System.DateTime value);
        partial void OnRequestDateChanged();
        /// <summary>
        /// There are no comments for Property AuthCode in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string AuthCode
        {
            get
            {
                return this._AuthCode;
            }
            set
            {
                this.OnAuthCodeChanging(value);
                this._AuthCode = value;
                this.OnAuthCodeChanged();
                this.OnPropertyChanged("AuthCode");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _AuthCode;
        partial void OnAuthCodeChanging(string value);
        partial void OnAuthCodeChanged();
        /// <summary>
        /// There are no comments for Property Account_Id in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int Account_Id
        {
            get
            {
                return this._Account_Id;
            }
            set
            {
                this.OnAccount_IdChanging(value);
                this._Account_Id = value;
                this.OnAccount_IdChanged();
                this.OnPropertyChanged("Account_Id");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _Account_Id;
        partial void OnAccount_IdChanging(int value);
        partial void OnAccount_IdChanged();
        /// <summary>
        /// There are no comments for Account in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public Account Account
        {
            get
            {
                return this._Account;
            }
            set
            {
                this._Account = value;
                this.OnPropertyChanged("Account");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private Account _Account;
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for WcfDSUsersModel.Account in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Accounts")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("Id")]
    public partial class Account : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Account object.
        /// </summary>
        /// <param name="ID">Initial value of Id.</param>
        /// <param name="isPaid">Initial value of IsPaid.</param>
        /// <param name="isSentACEmail">Initial value of IsSentACEmail.</param>
        /// <param name="userEmail">Initial value of UserEmail.</param>
        /// <param name="userName">Initial value of UserName.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Account CreateAccount(int ID, bool isPaid, bool isSentACEmail, string userEmail, string userName)
        {
            Account account = new Account();
            account.Id = ID;
            account.IsPaid = isPaid;
            account.IsSentACEmail = isSentACEmail;
            account.UserEmail = userEmail;
            account.UserName = userName;
            return account;
        }
        /// <summary>
        /// There are no comments for Property Id in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this.OnIdChanging(value);
                this._Id = value;
                this.OnIdChanged();
                this.OnPropertyChanged("Id");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _Id;
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        /// <summary>
        /// There are no comments for Property IsRequestOpen in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<bool> IsRequestOpen
        {
            get
            {
                return this._IsRequestOpen;
            }
            set
            {
                this.OnIsRequestOpenChanging(value);
                this._IsRequestOpen = value;
                this.OnIsRequestOpenChanged();
                this.OnPropertyChanged("IsRequestOpen");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<bool> _IsRequestOpen;
        partial void OnIsRequestOpenChanging(global::System.Nullable<bool> value);
        partial void OnIsRequestOpenChanged();
        /// <summary>
        /// There are no comments for Property IsAcceptedAR in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<bool> IsAcceptedAR
        {
            get
            {
                return this._IsAcceptedAR;
            }
            set
            {
                this.OnIsAcceptedARChanging(value);
                this._IsAcceptedAR = value;
                this.OnIsAcceptedARChanged();
                this.OnPropertyChanged("IsAcceptedAR");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<bool> _IsAcceptedAR;
        partial void OnIsAcceptedARChanging(global::System.Nullable<bool> value);
        partial void OnIsAcceptedARChanged();
        /// <summary>
        /// There are no comments for Property IsPaid in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public bool IsPaid
        {
            get
            {
                return this._IsPaid;
            }
            set
            {
                this.OnIsPaidChanging(value);
                this._IsPaid = value;
                this.OnIsPaidChanged();
                this.OnPropertyChanged("IsPaid");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private bool _IsPaid;
        partial void OnIsPaidChanging(bool value);
        partial void OnIsPaidChanged();
        /// <summary>
        /// There are no comments for Property IsSentACEmail in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public bool IsSentACEmail
        {
            get
            {
                return this._IsSentACEmail;
            }
            set
            {
                this.OnIsSentACEmailChanging(value);
                this._IsSentACEmail = value;
                this.OnIsSentACEmailChanged();
                this.OnPropertyChanged("IsSentACEmail");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private bool _IsSentACEmail;
        partial void OnIsSentACEmailChanging(bool value);
        partial void OnIsSentACEmailChanged();
        /// <summary>
        /// There are no comments for Property UserEmail in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string UserEmail
        {
            get
            {
                return this._UserEmail;
            }
            set
            {
                this.OnUserEmailChanging(value);
                this._UserEmail = value;
                this.OnUserEmailChanged();
                this.OnPropertyChanged("UserEmail");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _UserEmail;
        partial void OnUserEmailChanging(string value);
        partial void OnUserEmailChanged();
        /// <summary>
        /// There are no comments for Property UserName in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
                this.OnUserNameChanging(value);
                this._UserName = value;
                this.OnUserNameChanged();
                this.OnPropertyChanged("UserName");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _UserName;
        partial void OnUserNameChanging(string value);
        partial void OnUserNameChanged();
        /// <summary>
        /// There are no comments for Property UserFirstName in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string UserFirstName
        {
            get
            {
                return this._UserFirstName;
            }
            set
            {
                this.OnUserFirstNameChanging(value);
                this._UserFirstName = value;
                this.OnUserFirstNameChanged();
                this.OnPropertyChanged("UserFirstName");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _UserFirstName;
        partial void OnUserFirstNameChanging(string value);
        partial void OnUserFirstNameChanged();
        /// <summary>
        /// There are no comments for AcceptanceSets in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceCollection<AcceptanceSet> AcceptanceSets
        {
            get
            {
                return this._AcceptanceSets;
            }
            set
            {
                this._AcceptanceSets = value;
                this.OnPropertyChanged("AcceptanceSets");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceCollection<AcceptanceSet> _AcceptanceSets = new global::System.Data.Services.Client.DataServiceCollection<AcceptanceSet>(null, global::System.Data.Services.Client.TrackingMode.None);
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
}
