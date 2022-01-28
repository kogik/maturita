using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Memory;

namespace arudionoSerialCommunication
{

    public partial class main : Form
    {

        public main()
        {
            InitializeComponent();
        }
        
        public Mem m = new Mem();

        settings sett = new settings();

        private void Form1_Load(object sender, EventArgs e)
        {

            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            while (true)
            {
                
                
                if (serialPort1.PortName != Properties.Settings.Default.serialport)
                {
                    serialPort1.Close();
                    serialPort1.PortName = Properties.Settings.Default.serialport;
                }

                if (serialPort1.BaudRate != Properties.Settings.Default.baudrate)
                {
                    serialPort1.Close();
                    serialPort1.BaudRate = Properties.Settings.Default.baudrate;
                }



                
                gameLabel.Invoke(new MethodInvoker(delegate
                {
                    gameLabel.Text = "Game: " + Properties.Settings.Default.game.ToString();
                }));

                if (m.OpenProcess(Properties.Settings.Default.game))
                {
                    processLabel.Invoke(new MethodInvoker(delegate
                    {
                        processLabel.Text = "Process: Open";
                        processLabel.ForeColor = Color.Green;
                        timer1.Start();


                    }));

                }
                else
                {
                    processLabel.Invoke(new MethodInvoker(delegate
                    {
                        processLabel.Text = "Process: Closed ";
                        processLabel.ForeColor = Color.Red;
                        timer1.Stop();

                    }));
                }




                
                if (serialPort1.IsOpen)
                { 
                    arduinoStatusLabel.Invoke(new MethodInvoker(delegate
                    {
                        arduinoStatusLabel.Text = "Arduino connected";
                        arduinoStatusLabel.ForeColor = Color.Green;

                    }));
                }
                else
                {
                    try
                    {
                        serialPort1.Open();
                    }
                    catch (UnauthorizedAccessException)
                    {
                        arduinoStatusLabel.Invoke(new MethodInvoker(delegate
                        {
                            arduinoStatusLabel.Text = "Port " + serialPort1.PortName + " is busy (probably used by some other process)";
                            arduinoStatusLabel.ForeColor = Color.Red;

                        }));
                    }
                    catch (Exception ex)
                    {
                        arduinoStatusLabel.Invoke(new MethodInvoker(delegate
                        {
                            arduinoStatusLabel.Text = "Arduino is not connected. Looking for it on " + serialPort1.PortName;
                            arduinoStatusLabel.ForeColor = Color.Red;

                        }));
                        Console.WriteLine(ex);
                    }
                }

                
                
                               
                

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            try
            {
                speedLabel.Invoke(new MethodInvoker(delegate
                {
                    float speed = m.ReadFloat("Omsi.exe+0x004614FC,0x428");
                    if(speed < 80)
                    {
                        speedLabel.Text = Math.Round(speed).ToString();
                        if (serialPort1.IsOpen)
                        {
                            serialPort1.Write(Math.Round(map(speed, 0, 85, 180, 0)).ToString());
                        }
                    }
                    else
                    {
                        speedLabel.Text = "viac ako 80 " + speed.ToString();
                    }
                }));
            }
            catch { }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                string text = textBox1.Text;
                textBox1.Text = "";
                serialPort1.Write(text);
            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int intBuffer;
            intBuffer = serialPort1.BytesToRead;
            byte[] byteBuffer = new byte[intBuffer];
            serialPort1.Read(byteBuffer, 0, intBuffer);
            richTextBox1.Invoke(new MethodInvoker(delegate
            {
                richTextBox1.Text += Encoding.Default.GetString(byteBuffer) + "\n";
            }));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sett.IsDisposed) sett = new settings();
            sett.Show();
            sett.BringToFront();
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private float map(float s, float a1, float a2, float b1, float b2)
        {
            return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
        }

    }

}
