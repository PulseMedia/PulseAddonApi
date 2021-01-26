# PulseNativeBridge
c# Class Library for registering Native Functions/Methods for Pulse

### Bugs
Found a bug? - Please create an "*issue*" that we or the community can solve the bug

### Contribute
Need a function or want to extend the current nativeBridge, just make an PR !
**Contribution Requirements:**
* C# Code must work in *NetStandard 2.0*
* Mark NatvieFunctions with the **[Native]** - Attribute
* Use the right Family for the NativeFunction attribute (if Family required create it)
* Write new Methods in the right Class (eg: "Directory"-Methods in "Directory.cs")
* Create new Classed in the right Folder (eg: "Directory.cs" in "modules/IO")
* No obfuscated codes/scripts
* No external packages

##### Examples
for Native-Method examples look at the current module folder in this repository
