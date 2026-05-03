using System;
using Dalamud.Bindings.ImGui;
using Dalamud.Interface.Windowing;

namespace SamplePlugin.Windows;

public class MainWindow() : Window("SamplePlugin"), IDisposable {
    public override void Draw() {
        ImGui.TextUnformatted("Hello, world!");
    }

    public void Dispose() { }
}
