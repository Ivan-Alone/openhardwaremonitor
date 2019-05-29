using System;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace OpenHardwareMonitor.Utilities
{
	public class Serial
	{
		private string _Port;
		private SerialPort serial;

		public string Port
		{
			get
			{
				return this._Port;
			}
			set
			{
				this._Port = value;
				Properties.Default.ComName = this._Port;
				Properties.Default.Save();
			}
		}

		public Serial()
		{
			int baudRate = Properties.Default.BaudRate;
			this.Port = Properties.Default.ComName;
			this.serial = new SerialPort(string.IsNullOrEmpty(this.Port) ? "COM1" : this.Port, baudRate);
		}

		public bool Open()
		{
			if (this.serial.IsOpen)
			{
				try
				{
					this.serial.Close();
				}
				catch
				{
				}
			}
			this.serial.PortName = this.Port;
			try
			{
				this.serial.Open();
			}
			catch (IOException ex)
			{
				return false;
			}
			return true;
		}

		public void Close()
		{
			if (!this.serial.IsOpen)
				return;
			this.serial.Close();
		}

		public void Write(byte[] data)
		{
			if (!this.serial.IsOpen)
				return;
			try
			{
				this.serial.Write(data, 0, data.Length);
			}
			catch (Exception ex)
			{
				int num = (int)MessageBox.Show("Ошибка отправки данных в COM-порт:\r\n\r\n" + ex.Message);
				try
				{
					this.serial.Close();
				}
				catch
				{
				}
				this.Open();
			}
		}
	}
}
