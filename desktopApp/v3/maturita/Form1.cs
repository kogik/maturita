using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Memory;

namespace maturita
{
    public partial class Form1 : Form
    {
        public Form1()
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


        private void timer1_Tick(object sender, EventArgs e)
        {
            /*
             * timer1
             * take care of:
             *  - game speed label
             *  - sending speed information via serial connection
             *  - 
             */


            try
            {
                gameSpeed.Invoke(new MethodInvoker(delegate
                {
                    float speed = m.ReadFloat("Omsi.exe+0x004614FC,0x428");
                    if (speed < 120)
                    {
                        gameSpeed.Text = "Speed: " + Math.Round(speed, 1).ToString();
                        if (serialPort1.IsOpen)
                        {
                            serialPort1.Write(Math.Round(speed, 1).ToString());
                        }
                    }
                    else
                    {
                        gameSpeed.Text = "Speed: > 120 ";
                    }
                }));
            }
            catch { }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            /* 
             * backgroundWorker1
             * take care of:
             *  - setting port and baudrate
             *  - serial and process connection
             *  - setting labels
             */

            while (true)
            {

                // Set port and baudrate from settings
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

                // Set labels
                gameName.Invoke(new MethodInvoker(delegate
                {
                    gameName.Text = "Game: " + Properties.Settings.Default.game.ToString();
                }));

                arduinoPort.Invoke(new MethodInvoker(delegate
                {
                    arduinoPort.Text = "Port: " + Properties.Settings.Default.serialport.ToString();
                }));

                arduinoBaud.Invoke(new MethodInvoker(delegate
                {
                    arduinoBaud.Text = "Baudrate: " + Properties.Settings.Default.baudrate.ToString();
                }));


                // Process connection managment
                if (m.OpenProcess(Properties.Settings.Default.game))
                {
                    gameProc.Invoke(new MethodInvoker(delegate
                    {
                        gameProc.Text = "Process: Open";
                        gameProc.ForeColor = Color.Green;
                        timer1.Start();


                    }));

                }
                else
                {
                    gameProc.Invoke(new MethodInvoker(delegate
                    {
                        gameProc.Text = "Process: Closed ";
                        gameProc.ForeColor = Color.Red;
                        timer1.Stop();

                    }));
                }

                // Serial connection managment
                if (serialPort1.IsOpen)
                {
                    arduinoStatus.Invoke(new MethodInvoker(delegate
                    {
                        arduinoStatus.Text = "Status: Arduino connected";
                        arduinoStatus.ForeColor = Color.Green;

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
                        arduinoStatus.Invoke(new MethodInvoker(delegate
                        {
                            arduinoStatus.Text = "Port is busy";
                            arduinoStatus.ForeColor = Color.Red;

                        }));
                    }
                    catch (Exception ex)
                    {
                        arduinoStatus.Invoke(new MethodInvoker(delegate
                        {
                            arduinoStatus.Text = "Arduino is not connected";
                            arduinoStatus.ForeColor = Color.Red;

                        }));
                        Console.WriteLine(ex);
                    }
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                string text = textBox1.Text;
                textBox1.Text = "";
                serialPort1.Write(text);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return) 
            {
                if (serialPort1.IsOpen)
                {
                    string text = textBox1.Text;
                    textBox1.Text = "";
                    serialPort1.Write(text);
                }
            }
        }


        // Receiving data from serial port for debug
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (sett.IsDisposed) sett = new settings();
            sett.Show();
            sett.BringToFront();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
