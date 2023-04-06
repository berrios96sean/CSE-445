using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace tryIt
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string topic = TextBox1.Text;
       
            var httpClient = new HttpClient();
            var responseTask = httpClient.GetAsync("http://localhost:60084/Service1.svc/WordFilter/"+topic);
            var response = responseTask.Result;
            var responseBodyTask = response.Content.ReadAsStringAsync();
            var responseBody = responseBodyTask.Result;
            Console.WriteLine(responseBody);



            Label3.Text = responseBody;
        }
    }
}