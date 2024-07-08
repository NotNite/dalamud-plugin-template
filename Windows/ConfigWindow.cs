using System;
using Dalamud.Interface.Windowing;
using ImGuiNET;

namespace SamplePlugin.Windows;

public class ConfigWindow(Configuration config) : Window("SamplePlugin Config"), IDisposable {
    public override void Draw() {
        if (ImGui.Checkbox("Config Option", ref config.ConfigOption)) {
            config.Save();
        }
    }

    public void Dispose() { }
}
