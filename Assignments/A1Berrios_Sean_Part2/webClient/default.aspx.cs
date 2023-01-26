using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace webClient
{
    public partial class _default : System.Web.UI.Page
    {
        public static string encryptMessage;
        public static string imgText;
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

        protected void encryptButton_Click(object sender, EventArgs e)
        {
            ServiceReference2.ServiceClient mySvc = new ServiceReference2.ServiceClient("BasicHttpsBinding_IService");
            encryptMessage =  mySvc.Encrypt(textToEncrypt.Text);
            encryptedMessage.Text = encryptMessage;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            receivedMessage.Text = encryptMessage;
        }

        protected void decryptButton_Click(object sender, EventArgs e)
        {
            ServiceReference2.ServiceClient mySvc = new ServiceReference2.ServiceClient("BasicHttpsBinding_IService");
            string decryptMessage = mySvc.Decrypt(encryptMessage);
            decryptedMessage.Text = decryptMessage;
        }

        protected void showImage_Click(object sender, EventArgs e)
        {
            Image1.Visible = true;
            ServiceReference3.ServiceClient mySvc = new ServiceReference3.ServiceClient("BasicHttpsBinding_IService1");
            Stream stream = mySvc.GetImage(imageInputLength.Text);
            StreamReader reader = new StreamReader(stream);
            imgText = reader.ReadToEnd();
            System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Jpeg);
            System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
            Image1.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(ms.ToArray());
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ServiceReference3.ServiceClient mySvc = new ServiceReference3.ServiceClient("BasicHttpsBinding_IService1");
            submitResult.Text = mySvc.GetVerifierString(imageTextInput.Text);
            
        }
    }
}