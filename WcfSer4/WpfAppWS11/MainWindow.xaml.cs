using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppWS11.Properties;
using WpfAppWS11.ServiceReference1;
using WcfDS_FormAuth;
using System.Web;
using System.Web.ClientServices;
using System.Threading;
using System.IO;
using System.Security;


namespace WpfAppWS11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WcfDSUsersEntities dataServiceClient;
        System.Data.Services.Client.DataServiceQuery<Account> query;
        //private System.Data.Services.Client.DataServiceQuery<ServiceReference1.AcceptanceSet> queryAcS;
         CollectionViewSource accountsViewSource;
        static DataServiceQueryContinuation<Account> token = null;
        static List<DataServiceQueryContinuation<Account>> tokens;
        static QueryOperationResponse<Account> response;
        long pageCount = 0;
        int currPage = 1;
        string authorizRequestCodeInitialText = "Auth. Request Code";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataServiceClient = new WcfDSUsersEntities( new Uri(Settings.Default.WDSUrl) );
            dataServiceClient.UsePostTunneling = true;
            dataServiceClient.MergeOption = MergeOption.PreserveChanges;
            //If Basic Security enabled on webserver
            dataServiceClient.Credentials = new NetworkCredential(
                userName: Settings.Default.UserName,
                password: Settings.Default.Pwd,
                domain: Settings.Default.Domain);
            query = dataServiceClient.Accounts.IncludeTotalCount();
            accountsViewSource = ((CollectionViewSource)(this.FindResource("accountsViewSource")));
            dataServiceClient.SendingRequest += new EventHandler<SendingRequestEventArgs>(OnSendingRequest);
            try
            {
                try
                {
                    List<Account> accList = query.Expand("AcceptanceSets").ToList();
                    accList.Sort(CompareAccountsByPayment);
                    accountsViewSource.Source = accList;              
                }
                catch (Exception ex)
                {
                    if (ex is DataServiceQueryException)
                    {
                        throw new ApplicationException(
                        ex.Message, ex);
                    }
                    else if(ex is DataServiceTransportException)
                    {
                        throw new ApplicationException(
                        ex.Message, ex);
                    }                
                }
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "DataService query error",  MessageBoxButton.OK, MessageBoxImage.Error);
            } 
           

            // Pagination
            try
            {
                try
                {
                    // Execute the query for all customers and get the response object.
                    response = dataServiceClient.Accounts.Execute() as QueryOperationResponse<Account>;

                    //pageCount = response.TotalCount; response does not support
                    tokens = new List<DataServiceQueryContinuation<Account>>(); 
                    do
                    {                    
                        pageCount++;                  
                        if (token != null)
                        {
                             //Load the new page from the next link URI.
                            tokens.Add(token);
                            response = dataServiceClient.Execute<Account>(token)
                                as QueryOperationResponse<Account>;
                            response.ToList();
                        }
                        else response.ToList(); 
                    }
                     //Get the next link, and continue while there is a next link.
                    while ((token = response.GetContinuation()) != null);

                    lbl_Pages.Content += Convert.ToString(pageCount);
                    lbl_CurrPageNr.Content =  Convert.ToString(currPage);
                }
                catch (DataServiceQueryException ex)
                {
                    throw new ApplicationException(
                        ex.Message, ex.InnerException );
                }
                catch (DataServiceTransportException ex)
                {
                    throw new ApplicationException(
                        ex.Message, ex.InnerException);
                }
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "DataService ResponceError", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (accountsViewSource.View != null)
            {
                accountsViewSource.View.MoveCurrentToFirst();
                acceptanceSetsListView.SelectedIndex = 0;
                textBox_AuthorizationRequestCode.Text = authorizRequestCodeInitialText;
                textBox_AuthorizationRequestCode.FontWeight = FontWeights.Normal;
            }
            else 
            {
                textBox_AuthorizationRequestCode.MinLines = 3;
                textBox_AuthorizationRequestCode.Text = "Data Service \ndid not return \nany data";
                textBox_AuthorizationRequestCode.FontWeight = FontWeights.ExtraBold;
            }
        }

        void OnSendingRequest(object sender, SendingRequestEventArgs e)
        {
            string cookie = DSCookies.GetCookie();
            e.RequestHeaders.Add("Cookie", cookie);

         //   ((HttpWebRequest)e.Request).CookieContainer =
         //((ClientFormsIdentity)Thread.CurrentPrincipal.Identity).AuthenticationCookies;
        }
        private void Button_SaveAccSetChanges_Click(object sender, RoutedEventArgs e)
        {
            txtBlock_Message.Text = "";
            Account currentAcc = (Account)accountsViewSource.View.CurrentItem;
            if (currentAcc != null)
            {
                foreach (var acS in currentAcc.AcceptanceSets)
                {
                    dataServiceClient.UpdateObject(acS);
                }
                dataServiceClient.SaveChanges();
            }
            else txtBlock_Message.Text = "Current Account is not recognized!";
        }

        private void ButtonPgUp_Click(object sender, RoutedEventArgs e)
        {
            if (accountsViewSource.View != null && accountsViewSource.View.CurrentPosition > 0)
            { 
                accountsViewSource.View.MoveCurrentToPrevious();
                acceptanceSetsListView.SelectedIndex = 0;
            }
            txtBlock_Message.Text = "";
        }

        private void PgDounPgDown_Click(object sender, RoutedEventArgs e)
        {
            if (accountsViewSource.View != null && accountsViewSource.View.CurrentPosition < ((CollectionView)accountsViewSource.View).Count - 1)
            {
                accountsViewSource.View.MoveCurrentToNext();
                acceptanceSetsListView.SelectedIndex = 0;
            }
            txtBlock_Message.Text = "";
        }

        private void ButtonSaveAccountChanges_Click(object sender, RoutedEventArgs e)
        {
            if (accountsViewSource.View != null)
            {
                try
                { 
                    foreach (var ac in accountsViewSource.View)
                    {
                        if (ac is ServiceReference1.Account)
                        {
                           if((ac as ServiceReference1.Account).Id == 0)                                             
                                dataServiceClient.AddToAccounts(ac as ServiceReference1.Account);                       
                        }
                    }
                    dataServiceClient.SaveChanges(SaveChangesOptions.Batch);
                    accountsViewSource.View.Refresh();
                }
                catch (ArgumentNullException ex)
                {
                    txtBlock_Message.Text = ex.InnerException.ToString();
                    throw new ApplicationException("Save Account Changes failed. ", ex.InnerException);
                }          
            }
            
        }

        private void ButtonAddNewAccSet_Click(object sender, RoutedEventArgs e)
        {
            Account currentAcc = (Account)accountsViewSource.View.CurrentItem;
            if(currentAcc != null)
            { 
                currentAcc.AcceptanceSets.Add(new AcceptanceSet() { Account_Id = currentAcc.Id });
                txtBlock_Message.Text = "";
            }
            else txtBlock_Message.Text = "Please, select an Account";
        }

        private void ButtonMoveLast_Click(object sender, RoutedEventArgs e)
        {
            if (accountsViewSource.View != null)
            {
                accountsViewSource.View.MoveCurrentToLast();
                txtBlock_Message.Text = "";
            }
            else
            {
                txtBlock_Message.Text = "DS View Error";
            }
            
        }

        private void ButtonMoveFirst_Click(object sender, RoutedEventArgs e)
        {
            if (accountsViewSource.View != null)
            {
                accountsViewSource.View.MoveCurrentToFirst();
                txtBlock_Message.Text = "";
            }
            else
            {
                txtBlock_Message.Text = "DS View Error";
            }
        }

       
        private void accountsDataGrid_OnRowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var accToUpdate =  (Account)accountsViewSource.View.CurrentItem;
            if(accToUpdate != null)
            {
                if ((accToUpdate as Account).Id > 0)
                    try
                    {
                        dataServiceClient.UpdateObject(accToUpdate as Account);
                    }
                    catch (ArgumentException ex)
                    {
                        txtBlock_Message.Text = ex.InnerException.ToString();
                        throw new ApplicationException("Update Account Changes failed. ", ex.InnerException);
                    }                   
            }
        }

        private void btn_PgDn_Click(object sender, RoutedEventArgs e)
        {
            if (pageCount > 1)
            {
                List<Account> accList = new List<Account>();
                if (token == null)
                {
                    response = dataServiceClient.Accounts.Execute() as QueryOperationResponse<Account>;
                }
                else
                {
                    response = dataServiceClient.Execute<Account>(token) as QueryOperationResponse<Account>;
                }
                response.ToList<Account>();
                token = response.GetContinuation();
                if (token != null)
                {
                    response = dataServiceClient.Execute<Account>(token)
                                            as QueryOperationResponse<Account>;
                    accList = response.ToList<Account>();
                    foreach (Account item in accList)
                    {
                        IEnumerable<AcceptanceSet> accSet = dataServiceClient.LoadProperty(item, "AcceptanceSets") as QueryOperationResponse<AcceptanceSet>;
                    }
                    if (currPage < pageCount)
                    {
                        lbl_CurrPageNr.Content = Convert.ToString(++currPage);
                    }
                    else
                    {
                        lbl_CurrPageNr.Content = Convert.ToString(currPage = 1);
                    }
                    accountsViewSource.Source = accList;
                }
                else
                {
                    accountsViewSource.Source = query.Expand("AcceptanceSets").ToList();
                    lbl_CurrPageNr.Content = Convert.ToString(currPage = 1);
                }
                accountsViewSource.View.Refresh();
            }
            
        }

        private void btn_LastPage_Click(object sender, RoutedEventArgs e)
        {
            if(tokens != null)
            {
                List<Account> accList = new List<Account>();
                int qtyTokens = tokens.Count();

                if (qtyTokens > 1)
                {
                    token = tokens[qtyTokens - 1];
                    response = dataServiceClient.Execute<Account>(token) as QueryOperationResponse<Account>;
                    accList = response.ToList<Account>();
                           
                    foreach (Account item in accList)
                    {
                        IEnumerable<AcceptanceSet> accSet = dataServiceClient.LoadProperty(item, "AcceptanceSets") as QueryOperationResponse<AcceptanceSet>;
                    }
                    accountsViewSource.Source = accList;
                    lbl_CurrPageNr.Content = Convert.ToString(pageCount);
                    accountsViewSource.View.Refresh();
                }           
            }
            
        }

        private void button_GetAuthorizCode_Click(object sender, RoutedEventArgs e)
        {
            AcceptanceSet currentAccSet = acceptanceSetsListView.SelectedItem as AcceptanceSet;
            string authorizationRequestCode = textBox_AuthorizationRequestCode.Text.Equals(authorizRequestCodeInitialText) ? String.Empty : textBox_AuthorizationRequestCode.Text;
            if (currentAccSet != null )
            {
                if (String.IsNullOrWhiteSpace(currentAccSet.AuthCode) && !String.IsNullOrWhiteSpace(currentAccSet.AuthReqCode))
                {
                    currentAccSet.AuthCode = SimpleSecurity.Security.GetAuthorizationCode(currentAccSet.AuthReqCode);
                }
                else
                    if (!String.IsNullOrWhiteSpace(authorizationRequestCode) )
                    {
                        currentAccSet.AuthCode = SimpleSecurity.Security.GetAuthorizationCode(authorizationRequestCode);
                        currentAccSet.AuthReqCode = authorizationRequestCode;
                    }
                    else txtBlock_Message.Text = "Please, enter Authorization Request Code!";
            }
            else txtBlock_Message.Text = "Please, create Acceptance.";
        }

        private void txtBox_AuthRequestCode_MouseUp(object sender, MouseButtonEventArgs e)
        {
            textBox_AuthorizationRequestCode.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (accountsViewSource.View != null)
            {
                accountsViewSource.View.Refresh();
            }           
        } 
     
        private int CompareAccountsByPayment(Account a1, Account a2)
        {
            if (a1 == null)
            {
                if (a2 == null)
                {
                    return 0;
                }
                else return -1;
            }
            else
            {
                if (a2 == null)
                {
                    return 1;
                }
                else
                {
                    if (a1.IsPaid == a2.IsPaid)
                    {
                        return 0;
                    }
                    else
                    {
                        if (a1.IsPaid)
                        {
                            return 1;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
            }
        }
    }
}
 