using System;
using Dalamud.Interface.Windowing;
using ImGuiNET;

namespace SamplePlugin.Windows;

public class MainWindow() : Window("SamplePlugin"), IDisposable {
    public override void Draw() {
        ImGui.TextUnformatted("Hello, world!");
    }

    public void Dispose() { }
}
