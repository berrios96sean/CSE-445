using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace A3_berrios_sean_part_3
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebGet(UriTemplate = "/add/{a}/{b}")]
        String add(String a, String b);

        [OperationContract]
        [WebGet(UriTemplate = "/getWikiURL/{topic}")]
        String getWikiURL(String topic);

        [OperationContract]
        [WebGet(UriTemplate = "/WordFilter/{topic}")]
        String WordFilter(String topic);

        [OperationContract]
        [WebGet(UriTemplate = "/GetDates/{topic}")]
        String GetDates(String topic);

        [OperationContract]
        [WebGet(UriTemplate = "/GetTopics/{topic}")]
        String GetTopics(String topic);
    }
}
