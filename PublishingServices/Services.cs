using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Authenticator_;

namespace PublishingServices
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]

    internal class Services : ServicesInterface
    {
        public int Login(string userName, string password)
        {
            int token = Class1.Login(userName, password);

            return token;
        }

        public void PublishService(string serviceName, string description, string APIEndPoint, string noOfOperands, string operandType)
        {
            throw new NotImplementedException();
        }

        public string Registration(string userName, string password)
        {
            string registerMsg = Class1.Register(userName, password);

            return registerMsg;
        }
    }
}
