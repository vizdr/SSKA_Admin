using System;
using System.Linq;
using System.ServiceModel;
using System.Data.Services.Client;
using WcfServARR.Properties;
using WcfServARR.ServiceRefDS3;
using System.Net;
using WcfDS_FormAuth;


namespace WcfServARR
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServARCode : IServARCode
    {
         WcfDSUsersEntities dataServiceClient;
         DataServiceQuery<Account> query;
         DataServiceQuery<Account> expandedQuery;
        public ServARCode()
        {
            dataServiceClient = new WcfDSUsersEntities(
                new Uri(Settings.Default.WcfSer4_WcfDS3url));
            //If Basic Security enabled on webserver
            dataServiceClient.Credentials = new NetworkCredential(
               userName: Settings.Default.UserName,
               password: Settings.Default.Pwd,
               domain: Settings.Default.Domain);
            dataServiceClient.UsePostTunneling = true;
            dataServiceClient.MergeOption = MergeOption.PreserveChanges;
            query = dataServiceClient.Accounts;
            dataServiceClient.SendingRequest += new EventHandler<SendingRequestEventArgs>(OnSendingRequest); 
        }


        // Cookie for Web App WcfSer4 for using in forms authentication
        void OnSendingRequest(object sender, SendingRequestEventArgs e)
        {
            string cookie = DSCookies.GetCookie();
            e.RequestHeaders.Add("Cookie", cookie);         
        }

        // Attempt to add the received from service ServARCode new request for the activation in the DB, provided by Data Service WcfDSUsersEntities.
        public int TryToRegisterAuthRequest(AuthorizationRequest request)
        {
            int result = 0;
            ServiceRefDS3.Account storedAccount = null;

            if (request == null)
            {
               String msg = "Authorisation Request is undefined";
               string reason = "TryToRegisterAuthRequest";
               throw new FaultException<AuthorizationRequestFault>
                        (new AuthorizationRequestFault(msg), reason); ;                
            }

            try
            {               
                Account accToRegister =             // new Account from request
                    Account.CreateAccount(0, false, false, request.UserEmail, request.UserName);
                accToRegister.UserFirstName = request.UserFirstName; // failed to update service reference for Create(...)
                int foundAccountId = 0;
                AcceptanceSet accS = new AcceptanceSet()
                {
                        IsAcceptEmailSent = false,
                        AuthReqCode = request.AuthRequestCode,
                        RequestDate = DateTime.Today,
                        AuthCode = request.AuthCode,
                        Account = accToRegister
                 };

                expandedQuery = query.Expand("AcceptanceSets");

                if (request.AccountId == 0  
                    && !String.IsNullOrWhiteSpace(request.UserName)
                    && !String.IsNullOrWhiteSpace(request.UserFirstName)
                    && !String.IsNullOrWhiteSpace(request.UserEmail))
                {
                    foundAccountId = TryToIdentifyUser(request.UserName, request.UserFirstName, request.UserEmail); 
                }
                if (request.AccountId > 0)  // Existing Account
                {
                     try
                    {
                        storedAccount = expandedQuery.ToList().Where(ac => ac.Id == request.AccountId).LastOrDefault();                   
                    }
                    catch (Exception ex)
                    {
                        var msg = ex.Message;
                        string reason = "AccountNotFound";
                        throw new FaultException<AuthorizationRequestFault>
                                 (new AuthorizationRequestFault(msg), reason); 
                    }
                }
                else if (foundAccountId > 0)
                {
                    storedAccount = expandedQuery.ToList().Where(a => a.Id == foundAccountId).LastOrDefault();
                }
                    
                if (storedAccount != null)   // Updates Account, optionally appends AccepanceSet
                    {                      
                        storedAccount.UserEmail = request.UserEmail;
                        storedAccount.UserFirstName = request.UserFirstName;
                        storedAccount.UserName = request.UserName;
                        if (storedAccount.AcceptanceSets != null)
                        {       // same user and pc, but the registry key is erased
                            DateTime lastRequestDate = storedAccount.AcceptanceSets.Select(a => a.RequestDate).Max();
                            accS = storedAccount.AcceptanceSets.Where(b => b.RequestDate == lastRequestDate).LastOrDefault(); 
                            accS.AuthReqCode = request.AuthRequestCode;
                            accS.AuthCode = request.AuthCode;
                            dataServiceClient.UpdateObject(storedAccount);
                            dataServiceClient.UpdateObject(accS);                        
                        }
                        else
                        {
                            dataServiceClient.AddRelatedObject(storedAccount, "AcceptanceSets", accS);
                            storedAccount.AcceptanceSets.Add(accS);
                            accS.Account = storedAccount;
                            dataServiceClient.SetLink(accS, "Account", storedAccount);
                        }
                        dataServiceClient.SaveChanges(); 
                        result = storedAccount.Id;
                    }
                else   // Appends the Account created from the request 
                {                                       
                    dataServiceClient.AddToAccounts(accToRegister);
                    dataServiceClient.AddRelatedObject(accToRegister, "AcceptanceSets", accS);
                    accToRegister.AcceptanceSets.Add(accS);
                    accS.Account = accToRegister;
                    dataServiceClient.SetLink(accS, "Account", accToRegister);
                    dataServiceClient.SaveChanges();
                    result = accToRegister.Id;
                }

                return result;              
            }
            catch (Exception e)
            {
                var msg = e.Message;
                string reason = "TryToRegisterAuthRequest";
                throw new FaultException<AuthorizationRequestFault>
                         (new AuthorizationRequestFault(msg), reason); ; 
            }                      
        }
        
        // Attempt to find user in query, received from Data Service
        private int TryToIdentifyUser(string userName, string userFirstName, string userEmail)
        {        
            var userId = query.ToList().Where(u => u.UserName == userName && u.UserFirstName == userFirstName && u.UserEmail == userEmail).Select(u => u.Id);
            if (userId == null)
                return 0;
            if (userId.Count() > 1)
                return userId.Last();
            else return userId.FirstOrDefault();
        }

        public string GetAuthCode(int accountId, string authorizReqCode)
        {
            string result = String.Empty;
            if (accountId > 0 && !string.IsNullOrEmpty(authorizReqCode))
            {
                try
                {
                    expandedQuery = query.Expand("AcceptanceSets");
                    Account acc = expandedQuery.ToList().Where(d => d.Id == accountId).LastOrDefault();
                    if (acc.IsPaid)
                    {
                        DateTime lastEmailDate = acc.AcceptanceSets.Where(a => a.AuthReqCode == authorizReqCode).Select(b => b.RequestDate).Max();
                        result = acc.AcceptanceSets.Where(a => (a.RequestDate == lastEmailDate)).Select(a => a.AuthCode).LastOrDefault();                           
                    }
                    
                }
                catch (Exception e)
                {
                    var msg = e.Message;
                    var reason = "GetAuthCode Exception";
                    throw new FaultException<AuthorizationRequestFault>
                        (new AuthorizationRequestFault(msg), reason);
               
                }               
            }
            if (string.IsNullOrEmpty(result))
            {
                string msg = String.Format("For Request Code: {0} Authorization code not found.",  authorizReqCode);
                string reason = "Empty Code";
                throw new FaultException<AuthorizationRequestFault>
                (new AuthorizationRequestFault(msg), reason);
            }
            return result;
        }
    }
}
