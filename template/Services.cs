using Dalamud.IoC;
using Dalamud.Plugin;
#if Command
using Dalamud.Plugin.Services;
#endif

namespace SamplePlugin;

public class Services {
    [PluginService] public static IDalamudPluginInterface PluginInterface { get; private set; } = null!;
#if Command
    [PluginService] public static ICommandManager CommandManager { get; private set; } = null!;
#endif
}
