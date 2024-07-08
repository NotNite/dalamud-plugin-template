# Dalamud Plugin Template

(Of course, because we needed another one).

This is a template for the [.NET Template Engine](https://github.com/dotnet/templating) to make Dalamud plugins. It has several benefits over [SamplePlugin](https://github.com/goatcorp/SamplePlugin):

- Assumes knowledge and experience of making Dalamud plugins
- Easy to get started with
  - Easy to create from the dotnet CLI/Visual Studio/JetBrains Rider
  - Optionally toggle windowing, configuration, commands
  - Builds out of the box (but please let me know if there are issues!)
- Modern
  - Uses Dalamud.NET.Sdk
  - Only a Version field in the .csproj
- Choose your bias
  - Service injection via god objects, constructor injection, or static properties
  - No provided .editorconfig, bring your own code style & reformat
  - Contains a .gitignore ignoring JetBrains IDEs
- Clean
  - No image loading or Data folder to strip out
  - Ships with a proper LICENSE file without the Markdown extension

## Installation

Clone this repository and run this command:

```shell
dotnet new install --force .
```

You can then use `dotnet new dalamudplugin` to create a new plugin, or use the GUI in Visual Studio/JetBrains Rider.

Available options:

- `ServiceType`: How services are accessed in the plugin
  - `GodObject`: Services are accessed through static properties on a Services class
  - `Constructor`: Services are passed to the plugin constructor
  - `StaticProperty`: Services are accessed through a static property on the Plugin class
- `Windowing`: Whether to include the Dalamud window system for the plugin
- `Configuration`: Whether to include a configuration file for the plugin
  - If `Windowing` is enabled, a config window is created
- `Command`: Whether to include the Dalamud command system for the plugin
  - If `Windowing` is enabled, the command toggles the UI

## Problems

If the plugin doesn't build out of the box after creation, this is considered a bug. Please fire an issue - there's a lot of permutations of config options here.