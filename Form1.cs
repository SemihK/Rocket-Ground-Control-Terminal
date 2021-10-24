using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace YerKontrolÜnitesiV1._5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //SerialPort sp = new SerialPort();
            //serialPort1.Open();
            //sp.PortName = "COM1"; // Hangi Port açıksa onu seç.
            //sp.BaudRate = 9600;
            //sp.DataBits = 8;
            //sp.Parity = Parity.None;
            //sp.StopBits = StopBits.One; 
            //sp.Open();
            //sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataRecevied);
        }
        public void sp_DataRecevied(object sender, SerialDataReceivedEventArgs e)
        {
            MessageBox.Show(serialPort1.ReadExisting());
            // Test için gelen verinin ekrana gösterilmesini sağlar.
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 100;
            timer2.Enabled = true;
            


        }
        int saniye;
        int dakika;
        int saat;
        private void timer1_Tick(object sender, EventArgs e)
        {
            label17.Text = ((Convert.ToString(saniye) + " : ") + (Convert.ToString(dakika) + " : ") + Convert.ToString(saat));
            if ((saniye == 59))
            {
                saniye = 0;
                dakika = dakika + 1;
                if (dakika == 60)
                {
                    saniye = 0;
                    dakika = 0;
                    saat = saat + 1;
                }
            }
            saniye = saniye + 1;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label14.Text = DateTime.Now.ToLongTimeString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] portlar = SerialPort.GetPortNames();
            foreach (string portAdi in portlar)
            {
                comboBox1.Items.Add(portAdi);
            }
        }
    }
}
