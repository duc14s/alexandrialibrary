using System;
using System.Collections.Generic;
using Alexandria.Plugins;

namespace Alexandria.Google
{
	public class ConfigurationSettings : IPluginSettings
	{
		#region Constructors
		public ConfigurationSettings()
		{
		}
		#endregion

		#region Private Fields
		private bool enabled;
		#endregion

		#region IPluginSettings Members
		[PluginSetting(PluginSettingType.Boolean, "Indicates whether or not the Google Search plugin is enabled")]
		public bool Enabled
		{
			get { return enabled; }
			set { enabled = value; }
		}
		#endregion
	}
}