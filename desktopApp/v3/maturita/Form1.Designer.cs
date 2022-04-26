namespace maturita
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gameProc = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gameName = new System.Windows.Forms.Label();
            this.gameSpeed = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.arduinoBaud = new System.Windows.Forms.Label();
            this.arduinoPort = new System.Windows.Forms.Label();
            this.arduinoStatus = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gameProc
            // 
            this.gameProc.AutoSize = true;
            this.gameProc.Location = new System.Drawing.Point(17, 47);
            this.gameProc.Name = "gameProc";
            this.gameProc.Size = new System.Drawing.Size(71, 13);
            this.gameProc.TabIndex = 0;
            this.gameProc.Text = "Process: N/A";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gameName);
            this.groupBox1.Controls.Add(this.gameSpeed);
            this.groupBox1.Controls.Add(this.gameProc);
            this.groupBox1.Location = new System.Drawing.Point(47, 165);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game";
            // 
            // gameName
            // 
            this.gameName.AutoSize = true;
            this.gameName.Location = new System.Drawing.Point(17, 34);
            this.gameName.Name = "gameName";
            this.gameName.Size = new System.Drawing.Size(61, 13);
            this.gameName.TabIndex = 2;
            this.gameName.Text = "Game: N/A";
            // 
            // gameSpeed
            // 
            this.gameSpeed.AutoSize = true;
            this.gameSpeed.Location = new System.Drawing.Point(17, 60);
            this.gameSpeed.Name = "gameSpeed";
            this.gameSpeed.Size = new System.Drawing.Size(64, 13);
            this.gameSpeed.TabIndex = 1;
            this.gameSpeed.Text = "Speed: N/A";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.arduinoBaud);
            this.groupBox2.Controls.Add(this.arduinoPort);
            this.groupBox2.Controls.Add(this.arduinoStatus);
            this.groupBox2.Location = new System.Drawing.Point(363, 165);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Arduino";
            // 
            // arduinoBaud
            // 
            this.arduinoBaud.AutoSize = true;
            this.arduinoBaud.Location = new System.Drawing.Point(15, 60);
            this.arduinoBaud.Name = "arduinoBaud";
            this.arduinoBaud.Size = new System.Drawing.Size(76, 13);
            this.arduinoBaud.TabIndex = 2;
            this.arduinoBaud.Text = "Baudrate: N/A";
            // 
            // arduinoPort
            // 
            this.arduinoPort.AutoSize = true;
            this.arduinoPort.Location = new System.Drawing.Point(15, 47);
            this.arduinoPort.Name = "arduinoPort";
            this.arduinoPort.Size = new System.Drawing.Size(52, 13);
            this.arduinoPort.TabIndex = 1;
            this.arduinoPort.Text = "Port: N/A";
            // 
            // arduinoStatus
            // 
            this.arduinoStatus.AutoSize = true;
            this.arduinoStatus.Location = new System.Drawing.Point(15, 34);
            this.arduinoStatus.Name = "arduinoStatus";
            this.arduinoStatus.Size = new System.Drawing.Size(63, 13);
            this.arduinoStatus.TabIndex = 0;
            this.arduinoStatus.Text = "Status: N/A";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.richTextBox1);
            this.groupBox3.Location = new System.Drawing.Point(47, 298);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(516, 212);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Debug";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(435, 180);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Send";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 182);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(423, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.CausesValidation = false;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.richTextBox1.Location = new System.Drawing.Point(7, 20);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(10);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(503, 154);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(47, 537);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Settings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(54, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(506, 96);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 596);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Maturita";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label gameProc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label gameSpeed;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label arduinoBaud;
        private System.Windows.Forms.Label arduinoPort;
        private System.Windows.Forms.Label arduinoStatus;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label gameName;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

