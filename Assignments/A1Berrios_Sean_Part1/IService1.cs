using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace A1Berrios_Sean_Part1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        int wordCount(string str);

        [OperationContract]
        stringStatistics analyzeStr(string str); 

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class stringStatistics
    {
        [DataMember]
        int upperCaseCount { get; set; }

        [DataMember]
        int lowerCaseCount { get; set; }

        [DataMember]
        int digitCount { get; set; }

        [DataMember]
        int vowelCount { get; set; }
    }
}
