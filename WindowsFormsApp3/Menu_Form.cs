using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp3.Form1;

namespace WindowsFormsApp3
{
    public partial class Menu_Form : Form
    {

        private static string api = "https://blockchain.info/tobtc?currency={0,0}&value={1,0}";
        private static string currency, number;
        private static double buyPrice;

        public Menu_Form(User user)
        {
            InitializeComponent();
            comboBox1.Items.Add("USD");
            comboBox1.Items.Add("BRL");


            string call = String.Format(api, "USD", "1");
           
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(call);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine(call);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                label5.Text = readStream.ReadToEnd();

            }
        }

        private void Menu_Form_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void numberInput_TextChanged(object sender, EventArgs e)
        {

        }

        private static void checkPrice()
        {
            while(true)
            {
                Thread.Sleep(10000);
                string call = String.Format(api, currency, number);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(call);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Console.WriteLine(call);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    if (response.CharacterSet == null)
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    }

                    double data = Convert.ToDouble(readStream.ReadToEnd());

                    if (buyPrice > data)
                    {
                        MessageBox.Show("You can buy bitcoin at the price you selected before! " + buyPrice);
                    }
                                       
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buyPrice = Convert.ToDouble(textBox1.Text);
            MessageBox.Show("Sucess you will be notified when the price reaches the desired ammount");
            Thread worker = new Thread(checkPrice);
            worker.IsBackground = true;
            worker.SetApartmentState(System.Threading.ApartmentState.STA);
            worker.Start();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string call = String.Format(api, comboBox1.SelectedItem.ToString(), numberInput.Text.ToString());
            currency = comboBox1.SelectedItem.ToString();
            number = numberInput.Text.ToString();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(call);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine(call);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                string data = readStream.ReadToEnd();

                MessageBox.Show("You will be able to buy " + data + " of bitcoin");
            }
        }
    }
}
