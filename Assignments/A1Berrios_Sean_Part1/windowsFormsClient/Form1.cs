using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace windowsFormsClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client mySvc = new ServiceReference1.Service1Client();
            ServiceReference1.stringStatistics stats = new ServiceReference1.stringStatistics();
            int words;
            words = mySvc.wordCount(textBox1.Text);
            stats = mySvc.analyzeStr(textBox1.Text);
            textBox2.Text = words.ToString();
            textBox3.Text = stats.upperCaseCount.ToString();
            textBox4.Text = stats.lowerCaseCount.ToString();
            textBox5.Text = stats.digitCount.ToString();
            textBox6.Text = stats.vowelCount.ToString(); 
        }
    }
}
