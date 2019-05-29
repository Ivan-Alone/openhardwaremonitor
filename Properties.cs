using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace OpenHardwareMonitor
{
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
	internal sealed class Properties : ApplicationSettingsBase
	{
		private static Properties defaultInstance = (Properties)SettingsBase.Synchronized((SettingsBase)new Properties());

		public static Properties Default
		{
			get
			{
				return defaultInstance;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("COM3")]
		public string ComName
		{
			get
			{
				return (string)this[nameof(ComName)];
			}
			set
			{
				this[nameof(ComName)] = (object)value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("9600")]
		public int BaudRate
		{
			get
			{
				return (int)this[nameof(BaudRate)];
			}
			set
			{
				this[nameof(BaudRate)] = (object)value;
			}
		}
	}
}
