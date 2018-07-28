using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp3.Form1;

namespace WindowsFormsApp3
{
    public partial class Menu_Form : Form
    {

        private string api = "https://blockchain.info/tobtc?currency={0,0}&value={1,0}";


        public Menu_Form(User user)
        {
            InitializeComponent();
            comboBox1.Items.Add("USD");
            comboBox1.Items.Add("BRL");
        }

        private void Menu_Form_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string call = String.Format(api, comboBox1.SelectedItem.ToString(), numberInput.Text.ToString());
            Console.WriteLine(call);
        }

        private void numberInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
