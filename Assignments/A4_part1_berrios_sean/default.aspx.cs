using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Net;

namespace A4_part1_berrios_sean
{
    public partial class _default : System.Web.UI.Page
    {
        public XmlDocument doc = new XmlDocument();
        public XmlNode node;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                   | SecurityProtocolType.Tls11
                   | SecurityProtocolType.Tls12
                   | SecurityProtocolType.Ssl3;

            string file = TextBox1.Text;
            doc.Load(file);

            XmlNodeList restaurantList = doc.SelectNodes("//Restaurants/restaurant");

            List<string> names = new List<string>();
            List<string> delivery = new List<string>();
            List<string> phone = new List<string>();
            List<string> email = new List<string>();
            List<string> website = new List<string>();
            List<string> facebook = new List<string>();
            foreach (XmlNode restaurantNode in restaurantList)
            {
                string deliver_y = restaurantNode.Attributes["Delivery"].Value;
                delivery.Add(deliver_y);
                string name = restaurantNode.SelectSingleNode("name").InnerText;
                names.Add(name);
                string phon_e = restaurantNode.SelectSingleNode("contact/phone").InnerText;
                phone.Add(phon_e);
                string emai_l = restaurantNode.SelectSingleNode("contact/email").InnerText;
                email.Add(emai_l);
                string websit_e = restaurantNode.SelectSingleNode("website").InnerText;
                website.Add(websit_e);
                string faceboo_k = restaurantNode.SelectSingleNode("facebook").InnerText;
                facebook.Add(faceboo_k);
            }
           

            for(int i = 0; i < names.Count; i++)
            {
                DropDownList1.Items.Add(names[i]);

            }
            
        }


        protected void Button2_Click1(object sender, EventArgs e)
        {
            string file = TextBox1.Text;
            doc.Load(file);

            XmlNodeList restaurantList = doc.SelectNodes("//Restaurants/restaurant");

            List<string> names = new List<string>();
            List<string> delivery = new List<string>();
            List<string> phone = new List<string>();
            List<string> email = new List<string>();
            List<string> website = new List<string>();
            List<string> facebook = new List<string>();
            foreach (XmlNode restaurantNode in restaurantList)
            {
                string deliver_y = restaurantNode.Attributes["Delivery"].Value;
                delivery.Add(deliver_y);
                string name = restaurantNode.SelectSingleNode("name").InnerText;
                names.Add(name);
                string phon_e = restaurantNode.SelectSingleNode("contact/phone").InnerText;
                phone.Add(phon_e);
                string emai_l = restaurantNode.SelectSingleNode("contact/email").InnerText;
                email.Add(emai_l);
                string websit_e = restaurantNode.SelectSingleNode("website").InnerText;
                website.Add(websit_e);
                string faceboo_k = restaurantNode.SelectSingleNode("facebook").InnerText;
                facebook.Add(faceboo_k);
            }

            if (DropDownList1.SelectedValue == names[0])
                TextBox2.Text = names[0];
            TextBox3.Text = phone[0];
            TextBox4.Text = email[0];
            TextBox5.Text = website[0];
            TextBox6.Text = facebook[0];
            TextBox7.Text = delivery[0];
            {

            }
            if (DropDownList1.SelectedValue == names[1])
            {
                TextBox2.Text = names[1];
                TextBox3.Text = phone[1];
                TextBox4.Text = email[1];
                TextBox5.Text = website[1];
                TextBox6.Text = facebook[1];
                TextBox7.Text = delivery[1];
            }
            if (DropDownList1.SelectedValue == names[2])
            {
                TextBox2.Text = names[2];
                TextBox3.Text = phone[2];
                TextBox4.Text = email[2];
                TextBox5.Text = website[2];
                TextBox6.Text = facebook[2];
                TextBox7.Text = delivery[2];
            }
            if (DropDownList1.SelectedValue == names[3])
            {
                TextBox2.Text = names[3];
                TextBox3.Text = phone[3];
                TextBox4.Text = email[3];
                TextBox5.Text = website[3];
                TextBox6.Text = facebook[3];
                TextBox7.Text = delivery[3];
            }
            if (DropDownList1.SelectedValue == names[4])
            {
                TextBox2.Text = names[4];
                TextBox3.Text = phone[4];
                TextBox4.Text = email[4];
                TextBox5.Text = website[4];
                TextBox6.Text = facebook[4];
                TextBox7.Text = delivery[4];
            }
        }
    }
}