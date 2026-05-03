using System;
using Dalamud.Bindings.ImGui;
using Dalamud.Interface.Windowing;

namespace SamplePlugin.Windows;

public class ConfigWindow(Configuration config) : Window("SamplePlugin Config"), IDisposable {
    public override void Draw() {
        if (ImGui.Checkbox("Config Option", ref config.ConfigOption)) {
            config.Save();
        }
    }

    public void Dispose() { }
}
