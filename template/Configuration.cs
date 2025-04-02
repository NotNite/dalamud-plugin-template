using Dalamud.Configuration;
using System;
using Newtonsoft.Json;
#if (ServiceType == Constructor)
using Dalamud.Plugin;
#endif

namespace SamplePlugin;

[Serializable]
#if (ServiceType == Constructor)
public class Configuration(IDalamudPluginInterface pluginInterface) : IPluginConfiguration {
#else
public class Configuration : IPluginConfiguration {
#endif
    public int Version { get; set; } = 0;

    [JsonProperty] public bool ConfigOption = true;

    public void Save() {
#if (ServiceType == GodObject)
        Services.PluginInterface.SavePluginConfig(this);
#elif (ServiceType == Constructor)
        pluginInterface.SavePluginConfig(this);
#elif (ServiceType == StaticProperty)
        Plugin.PluginInterface.SavePluginConfig(this);
#endif
    }
}
