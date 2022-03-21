using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace arudionoSerialCommunication
{
    public partial class settings : Form
    {
        public settings()
        {
            InitializeComponent();
        }
        private void settings_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            settings_comport.Invoke(new MethodInvoker(delegate
            {
                settings_comport.Items.Clear();
                foreach (string port in ports)
                {
                    settings_comport.Items.Add(port);

                }
                settings_comport.SelectedItem = Properties.Settings.Default.serialport;
            }));

            settings_baudrate.SelectedItem = Properties.Settings.Default.baudrate.ToString();
            setting_gameprocess.SelectedItem = Properties.Settings.Default.game.ToString();
        }

        private void settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.serialport = settings_comport.SelectedItem.ToString();
            Properties.Settings.Default.baudrate = Int32.Parse(settings_baudrate.SelectedItem.ToString());
            Properties.Settings.Default.game = setting_gameprocess.Text.ToString();
        }

    }
}
