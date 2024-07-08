using Dalamud.Plugin;
#if Windowing
using Dalamud.Interface.Windowing;
using SamplePlugin.Windows;
#endif
#if (ServiceType == StaticProperty)
using Dalamud.IoC;
#endif
#if Command
using Dalamud.Game.Command;
#endif
#if (ServiceType != GodObject)
using Dalamud.Plugin.Services;
#endif

namespace SamplePlugin;

public class Plugin : IDalamudPlugin {
#if Command
    public const string CommandName = "/sampleplugin";

#endif
#if Configuration
    public Configuration Configuration;

#endif
#if Windowing
    public readonly WindowSystem WindowSystem = new("SamplePlugin");
    public MainWindow MainWindow;
#if (Configuration && Windowing)
    public ConfigWindow ConfigWindow;
#endif

#endif
#if (ServiceType == GodObject)
    public Plugin(IDalamudPluginInterface pluginInterface) {
        pluginInterface.Create<Services>();
#if (Configuration || Windowing || Command)

#endif
#elif (ServiceType == Constructor)
    public Plugin(IDalamudPluginInterface pluginInterface) {
#elif (ServiceType == StaticProperty)
    [PluginService] public static IDalamudPluginInterface PluginInterface { get; private set; } = null!;
#if Command
    [PluginService] public static ICommandManager CommandManager { get; private set; } = null!;
#endif

    public Plugin() {
#endif
#if Configuration
#if (ServiceType == GodObject)
        this.Configuration = Services.PluginInterface.GetPluginConfig() as Configuration ?? new Configuration(pluginInterface);
#elif (ServiceType == Constructor)
        this.Configuration = pluginInterface.GetPluginConfig() as Configuration ?? new Configuration(pluginInterface);
#elif (ServiceType == StaticProperty)
        this.Configuration = PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
#endif
#if (Windowing || Command)

#endif
#endif
#if Windowing
        this.MainWindow = new MainWindow();
#if Configuration
        this.ConfigWindow = new ConfigWindow(this.Configuration);
#endif
        this.WindowSystem.AddWindow(this.MainWindow);
#if Configuration
        this.WindowSystem.AddWindow(this.ConfigWindow);
#endif

#if (ServiceType == GodObject)
        Services.PluginInterface.UiBuilder.Draw += this.DrawUi;
        Services.PluginInterface.UiBuilder.OpenMainUi += this.ToggleMainUi;
#elif (ServiceType == Constructor)
        pluginInterface.UiBuilder.Draw += this.DrawUi;
        pluginInterface.UiBuilder.OpenMainUi += this.ToggleMainUi;
#elif (ServiceType == StaticProperty)
        PluginInterface.UiBuilder.Draw += this.DrawUi;
        PluginInterface.UiBuilder.OpenMainUi += this.ToggleMainUi;
#endif
#if Configuration
#if (ServiceType == GodObject)
        Services.PluginInterface.UiBuilder.OpenConfigUi += this.ToggleConfigUi;
#elif (ServiceType == Constructor)
        pluginInterface.UiBuilder.OpenConfigUi += this.ToggleConfigUi;
#elif (ServiceType == StaticProperty)
        PluginInterface.UiBuilder.OpenConfigUi += this.ToggleConfigUi;
#endif
#endif
#if Command

#endif
#endif
#if Command
#if (ServiceType == GodObject)
        Services.CommandManager.AddHandler(CommandName, new CommandInfo(this.OnCommand) {
#elif (ServiceType == Constructor)
        pluginInterface.CommandManager.AddHandler(CommandName, new CommandInfo(this.OnCommand) {
#elif (ServiceType == StaticProperty)
        CommandManager.AddHandler(CommandName, new CommandInfo(this.OnCommand) {
#endif
#if Windowing
            HelpMessage = "Open the main window"
#else
            HelpMessage = ""
#endif
        });
#endif
    }

    public void Dispose() {
#if Command
#if (ServiceType == GodObject)
        Services.CommandManager.RemoveHandler(CommandName);
#elif (ServiceType == Constructor)
        pluginInterface.CommandManager.RemoveHandler(CommandName);
#elif (ServiceType == StaticProperty)
        CommandManager.RemoveHandler(CommandName);
#endif
#if (Configuration || Windowing)

#endif
#endif
#if Configuration
        this.Configuration.Save();
#if Windowing

#endif
#endif
#if Windowing
        this.WindowSystem.RemoveAllWindows();
        this.MainWindow.Dispose();
#if Configuration
        this.ConfigWindow.Dispose();
#endif

#if (ServiceType == GodObject)
        Services.PluginInterface.UiBuilder.Draw -= this.DrawUi;
        Services.PluginInterface.UiBuilder.OpenMainUi -= this.ToggleMainUi;
#elif (ServiceType == Constructor)
        pluginInterface.UiBuilder.Draw -= this.DrawUi;
        pluginInterface.UiBuilder.OpenMainUi -= this.ToggleMainUi;
#elif (ServiceType == StaticProperty)
        PluginInterface.UiBuilder.Draw -= this.DrawUi;
        PluginInterface.UiBuilder.OpenMainUi -= this.ToggleMainUi;
#endif
#if Configuration
#if (ServiceType == GodObject)
        Services.PluginInterface.UiBuilder.OpenConfigUi -= this.ToggleConfigUi;
#elif (ServiceType == Constructor)
        pluginInterface.UiBuilder.OpenConfigUi -= this.ToggleConfigUi;
#elif (ServiceType == StaticProperty)
        PluginInterface.UiBuilder.OpenConfigUi -= this.ToggleConfigUi;
#endif
#endif
#endif
    }
#if (Windowing || Command)

#endif
#if Windowing
    private void DrawUi() => this.WindowSystem.Draw();
    private void ToggleMainUi() => this.MainWindow.Toggle();
#if Configuration
    private void ToggleConfigUi() => this.ConfigWindow.Toggle();
#endif
#if Command

#endif
#endif
#if Command
    private void OnCommand(string command, string args) {
#if Windowing
#if Configuration
        if (args is "settings" or "config") {
            this.ToggleConfigUi();
        } else {
            this.ToggleMainUi();
        }
#else
        this.ToggleMainUi();
#endif
    }
#endif
#endif
}
