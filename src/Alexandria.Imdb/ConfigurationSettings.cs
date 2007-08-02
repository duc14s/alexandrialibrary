using System;
using System.Collections.Generic;
using Alexandria.Plugins;

namespace Alexandria.Imdb
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
		private ConfigurationMap configurationMap;
		#endregion

		#region IPluginSettings Members
		[PluginSetting(PluginSettingType.Boolean, "Indicates whether or not the IMDB Search plugin is enabled")]
		public bool Enabled
		{
			get { return enabled; }
			set { enabled = value; }
		}

		public ConfigurationMap ConfigurationMap
		{
			get { return configurationMap; }
			set { configurationMap = value; }
		}

		public void Load()
		{
			if (ConfigurationMap != null)
				ConfigurationMap.Load();
		}

		public void Save()
		{
			if (ConfigurationMap != null)
				ConfigurationMap.Save();
		}
		#endregion
	}
}