using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsSOAPClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(label1.Text);
            ServiceReference1.CalculatorSoapClient myClient = new ServiceReference1.CalculatorSoapClient("CalculatorSoap");
            int x = Int32.Parse(textBox1.Text);
            int y = Int32.Parse(textBox2.Text);
            Console.WriteLine("x = " + x + "y = " + y);
            int result = myClient.Multiply(x, y);
            textBox3.Text = result.ToString(); Console.WriteLine("hello");
        }
    }
}
