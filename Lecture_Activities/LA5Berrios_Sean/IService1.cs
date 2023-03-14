using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LA5Berrios_Sean
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebGet(UriTemplate ="/reverseString/{str}")]
        String reverseString(String str);

        [OperationContract]
        [WebGet(UriTemplate = "/sumOfDigits/{num}")]
        int sumOfDigits(String num);
    }


}
