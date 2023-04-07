using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A3_tryIt.Services
{
    public partial class GetDates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String topic = TextBox1.Text;

            var httpClient = new HttpClient();
            var responseTask = httpClient.GetAsync("http://webstrar7.fulton.asu.edu/page4/Service1.svc/GetDates/" + topic);
            var response = responseTask.Result;
            var responseBodyTask = response.Content.ReadAsStringAsync();
            var responseBody = responseBodyTask.Result;
            Console.WriteLine(responseBody);



            Label2.Text = responseBody;
        }
    }
}