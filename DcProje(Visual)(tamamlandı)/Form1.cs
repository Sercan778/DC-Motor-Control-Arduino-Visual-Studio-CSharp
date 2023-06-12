using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DcProje_Visual__tamamlandı_
{
    public partial class Form1 : Form
    {
        SerialPort port;
        bool baglanti_durumu = false;
        public Form1()
        {
            InitializeComponent();
            init();
            groupBox2.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            pictureBox4.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
                comboBox1.SelectedIndex = 0;
                serialPort1.BaudRate = (9600);
                serialPort1.ReadTimeout = (2000);
                serialPort1.WriteTimeout = (2000);
            }
            timer1.Enabled = true;
        }
        private void init()
        {
            port = new SerialPort();
            port.PortName = "COM5";
            port.BaudRate = 9600;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            try
            {

                pictureBox1.Visible = false; pictureBox2.Visible = true; pictureBox3.Visible = false; pictureBox4.Visible = true;
                groupBox2.Visible = true;

            }
            catch
            {
                MessageBox.Show("Seri Port Seçiniz");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            serialPort1.Close();
            port.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox2.Text = DateTime.Now.ToLongTimeString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string x = comboBox1.SelectedItem.ToString();
            serialPort1.PortName = x;
            serialPort1.BaudRate = 9600;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true; pictureBox2.Visible = false;
            groupBox2.Visible = false;
            port.Close();
        }

        private void track_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = track.Value.ToString();
            try
            {
                serialPort1.Open();
                serialPort1.WriteLine(track.Value.ToString());
                serialPort1.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            if (baglanti_durumu == false)
            {

                try
                {
                    port.Open();
                    port.WriteLine("2");
                    port.Close();
                    baglanti_durumu = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (baglanti_durumu == true)
            {
                try
                {
                    port.Open();
                    port.WriteLine("3");
                    port.Close();
                    baglanti_durumu = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Yon_Scroll(object sender, EventArgs e)
        {

            if (Yon.Value == 1)
            {
                try
                {
                    port.Open();
                    port.WriteLine("4");
                    port.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (Yon.Value == 2)
            {
                try
                {
                    port.Open();
                    port.WriteLine("1");
                    port.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
