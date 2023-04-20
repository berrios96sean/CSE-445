using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace a4_part_2_web_app
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client svc = new ServiceReference1.Service1Client();

            string xml = TextBox2.Text;
            string xsd = TextBox3.Text;

            string output = svc.verification(xml, xsd);

            TextBox1.Text = output; 
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client svc = new ServiceReference1.Service1Client();

            string xml = TextBox4.Text;
            string path = TextBox5.Text;

            string output = svc.xPathSearch(xml, path);

            Label8.Text = output; 
        }
    }
}