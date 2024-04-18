using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PublishingServices
{
    [ServiceContract]
    public interface ServicesInterface
    {
        [OperationContract]
        string Registration(string userName, string password);
        [OperationContract]
        int Login(string userName, string password);
        [OperationContract]
        void PublishService(string serviceName, string description, 
            string APIEndPoint, string noOfOperands, string operandType);
    }
}
