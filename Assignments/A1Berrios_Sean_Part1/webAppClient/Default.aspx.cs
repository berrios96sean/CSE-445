using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webAppClient
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client mySvc = new ServiceReference1.Service1Client();
            ServiceReference1.stringStatistics stats = new ServiceReference1.stringStatistics();
            int words = mySvc.wordCount(TextBox1.Text);
            stats = mySvc.analyzeStr(TextBox1.Text); 
            TextBox2.Text = words.ToString();
            TextBox3.Text = stats.upperCaseCount.ToString();
            TextBox4.Text = stats.lowerCaseCount.ToString();
            TextBox5.Text = stats.digitCount.ToString();
            TextBox6.Text = stats.vowelCount.ToString(); 
        }
    }
}