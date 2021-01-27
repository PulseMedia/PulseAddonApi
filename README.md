# PulseAddonApi
**This repository includes the following Api's for Pulse**
* ✔️ C# Class Library for registering Native Functions/Methods for Pulse
* ✔️ Basic JavaScript Api (Nativeless)

   
it does NOT include ❌ BuiltIn JavaScript Apis (Widgets, AddonBehaviour ...)

### Bugs
Found a bug? - Please create an "*issue*" that we or the community can solve the bug   

If you found an bug or have an wish for the "BuiltIn JavaScript Apis" you can also create an "*issue*"

### Contribute
Need a function or want to extend the current Api, just make an PR !

**C# Contribution Requirements:**
* C# Code must work in *NetStandard 2.0*
* Mark NatvieFunctions with the **[Native]** - Attribute
* Use the right Family for the NativeFunction attribute (if Family required create it)
* Write new Methods in the right Class (eg: "Directory"-Methods in "Directory.cs")
* Create new Classed in the right Folder (eg: "Directory.cs" in "modules/IO")
* No obfuscated codes/scripts
* No external packages


**JavaScript Contribution Requirements:**
* JavaScript Code must be Compatible with Pulse (see "Pulse compatibility support")
* Write new Functions in the right Object (eg: "Path"-Methods in "const Path")
* Create new JavaScript files in the right Folder (eg: "path.js" in "Path")
* No obfuscated codes/scripts
* No external packages

### Pulse compatibility support
ECMAScript 2015 (ES6)

**ES6 Note:** currently UWP (Windows(appx), XBOX ..) is using [Windows.UI.Xaml.Controls.WebView](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.webview?view=winrt-19041#:~:text=WebView%20always%20uses%20Internet%20Explorer%2010%20in%20document%20mode.) .Sadly on some Platforms it uses IE which does not support ES6, theoretically on Windows it should use Edge which relies on Chromium. *WinUI 3* is currently an Preview Function from Microsoft which contains an WebView with "Microsoft Edge Chromium" but sadly its currently not supported on Xbox. Later Pulse will move on and will use the new WinUI3, so basically Es6 is safe to use.
