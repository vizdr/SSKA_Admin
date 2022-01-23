using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfServARR
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServARCode
    {

        [OperationContract]
        [FaultContract(typeof(AuthorizationRequestFault))]
        int TryToRegisterAuthRequest(AuthorizationRequest request);

        [OperationContract]
        [FaultContract(typeof(AuthorizationRequestFault))]
        string GetAuthCode(int accoundId, string authorizReqCode);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
   

    [DataContract]
    public class AuthorizationRequest
    {
        [DataMember]
        public int AccountId { get; set; }

        [DataMember]
        public string UserEmail { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string UserFirstName { get; set; }

        [DataMember]
        public string AuthRequestCode { get; set; }

        [DataMember]
        public string AuthCode { get; set; }             
    }

    [DataContract]
    public class AuthorizationRequestFault
    {
        public AuthorizationRequestFault(string msg)
        {
            FaultMessage = msg;
        }
        [DataMember]
        public string FaultMessage;
    }

}
