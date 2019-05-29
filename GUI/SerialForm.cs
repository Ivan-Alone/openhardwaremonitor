using System;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace OpenHardwareMonitor.GUI
{
	public class SerialForm : Form
	{
		private bool _loaded = false;
		private IContainer components = (IContainer)null;
		private readonly MainForm _parent;
		private Label label1;
		private Button okButton;
		private CheckBox chkManualFan;
		private TrackBar sldManualFan;
		private PictureBox pictureBox1;
		private TrackBar sldManualColor;
		private CheckBox chkManualColor;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private Label label6;
		private Label label7;
		private Label label8;
		private Label label9;
		private Label label10;
		private Label label11;
		private Label label12;
		private TrackBar sldLedBrightness;
		private Label label13;
		private Label label14;
		private TrackBar sldPlotInterval;
		private Label label15;
		private NumericUpDown nMaxFan;
		private NumericUpDown nMinFan;
		private NumericUpDown nMinTemp;
		private NumericUpDown nMaxTemp;
		private Label lblManualFanValue;
		private Label lblManualColorValue;
		private Label lblLedBrightnessValue;
		private Label lblPlotIntervalValue;
		private ComboBox cboComPort;
		private ComboBox cboMaxTempSource;
		private Label label16;

		public SerialForm(MainForm parent)
		{
			this.InitializeComponent();
			this._parent = parent;
		}

		public string Port
		{
			get
			{
				return (string)this.cboComPort.SelectedItem;
			}
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void SerialForm_Load(object sender, EventArgs e)
		{
			this.cboMaxTempSource.SelectedIndex = this._parent.settings.GetValue("cboMaxTempSource", 0);
			this.LoadComPortNames();
			this.nMaxFan.Value = (Decimal)this._parent.settings.GetValue("nMaxFan", 100);
			this.nMinFan.Value = (Decimal)this._parent.settings.GetValue("nMinFan", 20);
			this.nMaxTemp.Value = (Decimal)this._parent.settings.GetValue("nMaxTemp", 80);
			this.nMinTemp.Value = (Decimal)this._parent.settings.GetValue("nMinTemp", 20);
			this.chkManualFan.Checked = this._parent.settings.GetValue("chkManualFan", false);
			this.chkManualColor.Checked = this._parent.settings.GetValue("chkManualColor", false);
			this.sldManualFan.Value = this._parent.settings.GetValue("sldManualFan", 50);
			this.sldManualColor.Value = this._parent.settings.GetValue("sldManualColor", 500);
			this.sldLedBrightness.Value = this._parent.settings.GetValue("sldLedBrightness", 50);
			this.sldPlotInterval.Value = this._parent.settings.GetValue("sldPlotInterval", 5);
			this._loaded = true;
		}

		private void LoadComPortNames()
		{
			this.cboComPort.Items.AddRange((object[])SerialPort.GetPortNames());
			if (this.cboComPort.Items.Count <= 0)
				return;
			if (this.cboComPort.Items.Contains((object)this._parent.Serial.Port))
				this.cboComPort.SelectedItem = (object)this._parent.Serial.Port;
			else if (!string.IsNullOrEmpty(this._parent.Serial.Port))
			{
				this.cboComPort.Items.Add((object)this._parent.Serial.Port);
			}
			else
			{
				this.cboComPort.SelectedIndex = 0;
				this._parent.Serial.Port = (string)this.cboComPort.SelectedItem;
			}
		}

		private void SaveAndSend()
		{
			if (!this._loaded)
				return;
			this._parent.settings.SetValue("cboMaxTempSource", this.cboMaxTempSource.SelectedIndex);
			this._parent.Serial.Port = (string)this.cboComPort.SelectedItem;
			this._parent.settings.SetValue("nMaxFan", (int)this.nMaxFan.Value);
			this._parent.settings.SetValue("nMinFan", (int)this.nMinFan.Value);
			this._parent.settings.SetValue("nMaxTemp", (int)this.nMaxTemp.Value);
			this._parent.settings.SetValue("nMinTemp", (int)this.nMinTemp.Value);
			this._parent.settings.SetValue("chkManualFan", this.chkManualFan.Checked);
			this._parent.settings.SetValue("chkManualColor", this.chkManualColor.Checked);
			this._parent.settings.SetValue("sldManualFan", this.sldManualFan.Value);
			this._parent.settings.SetValue("sldManualColor", this.sldManualColor.Value);
			this._parent.settings.SetValue("sldLedBrightness", this.sldLedBrightness.Value);
			this._parent.settings.SetValue("sldPlotInterval", this.sldPlotInterval.Value);
			this._parent.SaveConfiguration();
		}

		private void sldManualFan_ValueChanged(object sender, EventArgs e)
		{
			this.lblManualFanValue.Text = this.sldManualFan.Value.ToString();
			this.SaveAndSend();
		}

		private void sldManualColor_ValueChanged(object sender, EventArgs e)
		{
			this.lblManualColorValue.Text = this.sldManualColor.Value.ToString();
			this.SaveAndSend();
		}

		private void sldLedBrightness_ValueChanged(object sender, EventArgs e)
		{
			this.lblLedBrightnessValue.Text = this.sldLedBrightness.Value.ToString();
			this.SaveAndSend();
		}

		private void sldPlotInterval_ValueChanged(object sender, EventArgs e)
		{
			this.lblPlotIntervalValue.Text = this.sldPlotInterval.Value.ToString();
			this.SaveAndSend();
		}

		private void nMaxFan_ValueChanged(object sender, EventArgs e)
		{
			this.SaveAndSend();
		}

		private void nMinFan_ValueChanged(object sender, EventArgs e)
		{
			this.SaveAndSend();
		}

		private void nMinTemp_ValueChanged(object sender, EventArgs e)
		{
			this.SaveAndSend();
		}

		private void nMaxTemp_ValueChanged(object sender, EventArgs e)
		{
			this.SaveAndSend();
		}

		private void chkManualFan_CheckedChanged(object sender, EventArgs e)
		{
			this.SaveAndSend();
		}

		private void chkManualColor_CheckedChanged(object sender, EventArgs e)
		{
			this.SaveAndSend();
		}

		private void portBox_TextChanged(object sender, EventArgs e)
		{
			this.SaveAndSend();
		}

		private void cboComPort_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.SaveAndSend();
		}

		private void cboMaxTempSource_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.SaveAndSend();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
				this.components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(SerialForm));
			this.label1 = new Label();
			this.okButton = new Button();
			this.chkManualFan = new CheckBox();
			this.sldManualFan = new TrackBar();
			this.pictureBox1 = new PictureBox();
			this.sldManualColor = new TrackBar();
			this.chkManualColor = new CheckBox();
			this.label2 = new Label();
			this.label3 = new Label();
			this.label4 = new Label();
			this.label5 = new Label();
			this.label6 = new Label();
			this.label7 = new Label();
			this.label8 = new Label();
			this.label9 = new Label();
			this.label10 = new Label();
			this.label11 = new Label();
			this.label12 = new Label();
			this.sldLedBrightness = new TrackBar();
			this.label13 = new Label();
			this.label14 = new Label();
			this.sldPlotInterval = new TrackBar();
			this.label15 = new Label();
			this.nMaxFan = new NumericUpDown();
			this.nMinFan = new NumericUpDown();
			this.nMinTemp = new NumericUpDown();
			this.nMaxTemp = new NumericUpDown();
			this.lblManualFanValue = new Label();
			this.lblManualColorValue = new Label();
			this.lblLedBrightnessValue = new Label();
			this.lblPlotIntervalValue = new Label();
			this.cboComPort = new ComboBox();
			this.cboMaxTempSource = new ComboBox();
			this.label16 = new Label();
			this.sldManualFan.BeginInit();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			this.sldManualColor.BeginInit();
			this.sldLedBrightness.BeginInit();
			this.sldPlotInterval.BeginInit();
			this.nMaxFan.BeginInit();
			this.nMinFan.BeginInit();
			this.nMinTemp.BeginInit();
			this.nMaxTemp.BeginInit();
			this.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new Size(77, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "PORT address";
			this.okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.okButton.DialogResult = DialogResult.Cancel;
			this.okButton.Location = new System.Drawing.Point(575, 391);
			this.okButton.Name = "okButton";
			this.okButton.Size = new Size(75, 23);
			this.okButton.TabIndex = 2;
			this.okButton.Text = "Close";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new EventHandler(this.okButton_Click);
			this.chkManualFan.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.chkManualFan.AutoSize = true;
			this.chkManualFan.Location = new System.Drawing.Point(12, 79);
			this.chkManualFan.Name = "chkManualFan";
			this.chkManualFan.Size = new Size(85, 17);
			this.chkManualFan.TabIndex = 3;
			this.chkManualFan.Text = "Manual FAN";
			this.chkManualFan.UseVisualStyleBackColor = true;
			this.chkManualFan.CheckedChanged += new EventHandler(this.chkManualFan_CheckedChanged);
			this.sldManualFan.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.sldManualFan.Location = new System.Drawing.Point(12, 115);
			this.sldManualFan.Maximum = 100;
			this.sldManualFan.Name = "sldManualFan";
			this.sldManualFan.Size = new Size(294, 45);
			this.sldManualFan.TabIndex = 4;
			this.sldManualFan.TickFrequency = 5;
			this.sldManualFan.TickStyle = TickStyle.TopLeft;
			this.sldManualFan.ValueChanged += new EventHandler(this.sldManualFan_ValueChanged);
			this.pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.pictureBox1.Image = (Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new System.Drawing.Point(391, 15);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(256, 256);
			this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new EventHandler(this.pictureBox1_Click);
			this.sldManualColor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.sldManualColor.Location = new System.Drawing.Point(12, 202);
			this.sldManualColor.Maximum = 1000;
			this.sldManualColor.Name = "sldManualColor";
			this.sldManualColor.Size = new Size(294, 45);
			this.sldManualColor.TabIndex = 7;
			this.sldManualColor.TickFrequency = 25;
			this.sldManualColor.TickStyle = TickStyle.TopLeft;
			this.sldManualColor.ValueChanged += new EventHandler(this.sldManualColor_ValueChanged);
			this.chkManualColor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.chkManualColor.AutoSize = true;
			this.chkManualColor.Location = new System.Drawing.Point(12, 166);
			this.chkManualColor.Name = "chkManualColor";
			this.chkManualColor.Size = new Size(101, 17);
			this.chkManualColor.TabIndex = 6;
			this.chkManualColor.Text = "Manual COLOR";
			this.chkManualColor.UseVisualStyleBackColor = true;
			this.chkManualColor.CheckedChanged += new EventHandler(this.chkManualColor_CheckedChanged);
			this.label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(342, 219);
			this.label2.Name = "label2";
			this.label2.Size = new Size(47, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "FAN min";
			this.label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(339, 54);
			this.label3.Name = "label3";
			this.label3.Size = new Size(50, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "FAN max";
			this.label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(388, 276);
			this.label4.Name = "label4";
			this.label4.Size = new Size(56, 13);
			this.label4.TabIndex = 13;
			this.label4.Text = "TEMP min";
			this.label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(534, 276);
			this.label5.Name = "label5";
			this.label5.Size = new Size(59, 13);
			this.label5.TabIndex = 15;
			this.label5.Text = "TEMP max";
			this.label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(21, 99);
			this.label6.Name = "label6";
			this.label6.Size = new Size(13, 13);
			this.label6.TabIndex = 16;
			this.label6.Text = "0";
			this.label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(281, 99);
			this.label7.Name = "label7";
			this.label7.Size = new Size(25, 13);
			this.label7.TabIndex = 17;
			this.label7.Text = "100";
			this.label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(275, 186);
			this.label8.Name = "label8";
			this.label8.Size = new Size(31, 13);
			this.label8.TabIndex = 19;
			this.label8.Text = "1000";
			this.label9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(21, 186);
			this.label9.Name = "label9";
			this.label9.Size = new Size(13, 13);
			this.label9.TabIndex = 18;
			this.label9.Text = "0";
			this.label10.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(9, 250);
			this.label10.Name = "label10";
			this.label10.Size = new Size(79, 13);
			this.label10.TabIndex = 20;
			this.label10.Text = "LED brightness";
			this.label11.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(281, 272);
			this.label11.Name = "label11";
			this.label11.Size = new Size(25, 13);
			this.label11.TabIndex = 23;
			this.label11.Text = "100";
			this.label12.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(21, 272);
			this.label12.Name = "label12";
			this.label12.Size = new Size(13, 13);
			this.label12.TabIndex = 22;
			this.label12.Text = "0";
			this.sldLedBrightness.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.sldLedBrightness.Location = new System.Drawing.Point(12, 288);
			this.sldLedBrightness.Maximum = 100;
			this.sldLedBrightness.Name = "sldLedBrightness";
			this.sldLedBrightness.Size = new Size(294, 45);
			this.sldLedBrightness.TabIndex = 21;
			this.sldLedBrightness.TickFrequency = 5;
			this.sldLedBrightness.TickStyle = TickStyle.TopLeft;
			this.sldLedBrightness.ValueChanged += new EventHandler(this.sldLedBrightness_ValueChanged);
			this.label13.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(287, 357);
			this.label13.Name = "label13";
			this.label13.Size = new Size(19, 13);
			this.label13.TabIndex = 27;
			this.label13.Text = "10";
			this.label14.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(21, 357);
			this.label14.Name = "label14";
			this.label14.Size = new Size(13, 13);
			this.label14.TabIndex = 26;
			this.label14.Text = "0";
			this.sldPlotInterval.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.sldPlotInterval.Location = new System.Drawing.Point(12, 373);
			this.sldPlotInterval.Name = "sldPlotInterval";
			this.sldPlotInterval.Size = new Size(294, 45);
			this.sldPlotInterval.TabIndex = 25;
			this.sldPlotInterval.TickStyle = TickStyle.TopLeft;
			this.sldPlotInterval.ValueChanged += new EventHandler(this.sldPlotInterval_ValueChanged);
			this.label15.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(9, 335);
			this.label15.Name = "label15";
			this.label15.Size = new Size(81, 13);
			this.label15.TabIndex = 24;
			this.label15.Text = "CHART interval";
			this.nMaxFan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.nMaxFan.Location = new System.Drawing.Point(341, 31);
			this.nMaxFan.Name = "nMaxFan";
			this.nMaxFan.Size = new Size(48, 20);
			this.nMaxFan.TabIndex = 28;
			this.nMaxFan.ValueChanged += new EventHandler(this.nMaxFan_ValueChanged);
			this.nMinFan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.nMinFan.Location = new System.Drawing.Point(341, 235);
			this.nMinFan.Name = "nMinFan";
			this.nMinFan.Size = new Size(48, 20);
			this.nMinFan.TabIndex = 29;
			this.nMinFan.ValueChanged += new EventHandler(this.nMinFan_ValueChanged);
			this.nMinTemp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.nMinTemp.Location = new System.Drawing.Point(450, 274);
			this.nMinTemp.Name = "nMinTemp";
			this.nMinTemp.Size = new Size(48, 20);
			this.nMinTemp.TabIndex = 30;
			this.nMinTemp.ValueChanged += new EventHandler(this.nMinTemp_ValueChanged);
			this.nMaxTemp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.nMaxTemp.Location = new System.Drawing.Point(599, 274);
			this.nMaxTemp.Name = "nMaxTemp";
			this.nMaxTemp.Size = new Size(48, 20);
			this.nMaxTemp.TabIndex = 31;
			this.nMaxTemp.ValueChanged += new EventHandler(this.nMaxTemp_ValueChanged);
			this.lblManualFanValue.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.lblManualFanValue.BorderStyle = BorderStyle.Fixed3D;
			this.lblManualFanValue.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
			this.lblManualFanValue.Location = new System.Drawing.Point(139, 144);
			this.lblManualFanValue.Name = "lblManualFanValue";
			this.lblManualFanValue.Size = new Size(41, 16);
			this.lblManualFanValue.TabIndex = 32;
			this.lblManualFanValue.Text = "100";
			this.lblManualFanValue.TextAlign = ContentAlignment.MiddleCenter;
			this.lblManualColorValue.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.lblManualColorValue.BorderStyle = BorderStyle.Fixed3D;
			this.lblManualColorValue.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
			this.lblManualColorValue.Location = new System.Drawing.Point(139, 231);
			this.lblManualColorValue.Name = "lblManualColorValue";
			this.lblManualColorValue.Size = new Size(41, 16);
			this.lblManualColorValue.TabIndex = 33;
			this.lblManualColorValue.Text = "100";
			this.lblManualColorValue.TextAlign = ContentAlignment.MiddleCenter;
			this.lblLedBrightnessValue.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.lblLedBrightnessValue.BorderStyle = BorderStyle.Fixed3D;
			this.lblLedBrightnessValue.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
			this.lblLedBrightnessValue.Location = new System.Drawing.Point(139, 317);
			this.lblLedBrightnessValue.Name = "lblLedBrightnessValue";
			this.lblLedBrightnessValue.Size = new Size(41, 16);
			this.lblLedBrightnessValue.TabIndex = 34;
			this.lblLedBrightnessValue.Text = "100";
			this.lblLedBrightnessValue.TextAlign = ContentAlignment.MiddleCenter;
			this.lblPlotIntervalValue.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.lblPlotIntervalValue.BorderStyle = BorderStyle.Fixed3D;
			this.lblPlotIntervalValue.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
			this.lblPlotIntervalValue.Location = new System.Drawing.Point(139, 402);
			this.lblPlotIntervalValue.Name = "lblPlotIntervalValue";
			this.lblPlotIntervalValue.Size = new Size(41, 16);
			this.lblPlotIntervalValue.TabIndex = 35;
			this.lblPlotIntervalValue.Text = "100";
			this.lblPlotIntervalValue.TextAlign = ContentAlignment.MiddleCenter;
			this.cboComPort.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cboComPort.FormattingEnabled = true;
			this.cboComPort.Location = new System.Drawing.Point(106, 12);
			this.cboComPort.Name = "cboComPort";
			this.cboComPort.Size = new Size(95, 21);
			this.cboComPort.TabIndex = 36;
			this.cboComPort.SelectedIndexChanged += new EventHandler(this.cboComPort_SelectedIndexChanged);
			this.cboMaxTempSource.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cboMaxTempSource.FormattingEnabled = true;
			this.cboMaxTempSource.Items.AddRange(new object[5]
			{
		(object) "CPU only",
		(object) "GPU only",
		(object) "Max (CPU, GPU)",
		(object) "Temp 1",
		(object) "Temp 2"
			});
			this.cboMaxTempSource.Location = new System.Drawing.Point(106, 39);
			this.cboMaxTempSource.Name = "cboMaxTempSource";
			this.cboMaxTempSource.Size = new Size(95, 21);
			this.cboMaxTempSource.TabIndex = 37;
			this.cboMaxTempSource.SelectedIndexChanged += new EventHandler(this.cboMaxTempSource_SelectedIndexChanged);
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(12, 42);
			this.label16.Name = "label16";
			this.label16.Size = new Size(72, 13);
			this.label16.TabIndex = 38;
			this.label16.Text = "TEMP source";
			this.AcceptButton = (IButtonControl)this.okButton;
			this.AutoScaleDimensions = new SizeF(6f, 13f);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.CancelButton = (IButtonControl)this.okButton;
			this.ClientSize = new Size(662, 426);
			this.Controls.Add((Control)this.label16);
			this.Controls.Add((Control)this.cboMaxTempSource);
			this.Controls.Add((Control)this.cboComPort);
			this.Controls.Add((Control)this.lblPlotIntervalValue);
			this.Controls.Add((Control)this.lblLedBrightnessValue);
			this.Controls.Add((Control)this.lblManualColorValue);
			this.Controls.Add((Control)this.lblManualFanValue);
			this.Controls.Add((Control)this.nMaxTemp);
			this.Controls.Add((Control)this.nMinTemp);
			this.Controls.Add((Control)this.nMinFan);
			this.Controls.Add((Control)this.nMaxFan);
			this.Controls.Add((Control)this.label13);
			this.Controls.Add((Control)this.label14);
			this.Controls.Add((Control)this.sldPlotInterval);
			this.Controls.Add((Control)this.label15);
			this.Controls.Add((Control)this.label11);
			this.Controls.Add((Control)this.label12);
			this.Controls.Add((Control)this.sldLedBrightness);
			this.Controls.Add((Control)this.label10);
			this.Controls.Add((Control)this.label8);
			this.Controls.Add((Control)this.label9);
			this.Controls.Add((Control)this.label7);
			this.Controls.Add((Control)this.label6);
			this.Controls.Add((Control)this.label5);
			this.Controls.Add((Control)this.label4);
			this.Controls.Add((Control)this.label3);
			this.Controls.Add((Control)this.label2);
			this.Controls.Add((Control)this.sldManualColor);
			this.Controls.Add((Control)this.chkManualColor);
			this.Controls.Add((Control)this.pictureBox1);
			this.Controls.Add((Control)this.sldManualFan);
			this.Controls.Add((Control)this.chkManualFan);
			this.Controls.Add((Control)this.okButton);
			this.Controls.Add((Control)this.label1);
			this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			this.Name = nameof(SerialForm);
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = FormStartPosition.CenterParent;
			this.Text = "Serial Configuration";
			this.Load += new EventHandler(this.SerialForm_Load);
			this.sldManualFan.EndInit();
			((ISupportInitialize)this.pictureBox1).EndInit();
			this.sldManualColor.EndInit();
			this.sldLedBrightness.EndInit();
			this.sldPlotInterval.EndInit();
			this.nMaxFan.EndInit();
			this.nMinFan.EndInit();
			this.nMinTemp.EndInit();
			this.nMaxTemp.EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
	}
}
