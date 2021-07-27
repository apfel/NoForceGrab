# No Force Grab
Removes Force Grabbing from every object in the game that supports it.  
Requires MelonLoader.

## Settings
```toml
# ...

[NoForceGrab]
DisableForceGrabRemoval = false
WaitTime = 2000

# ...
```

`DisableForceGrabRemoval` disables the removal of Force Grabbing.  
`WaitTime` sets how long the update routine has to wait before searching for Force Grab components, in milliseconds.

## Compiling
Requires:
- .NET Framework 4.7.2 SDK
- CMake 3.10 or newer

```ps1
cmake -B build                          # Creates a build folder, use -DBONEWORKS_DIR=<path> if you installed BONEWORKS somewhere outside of C:\Program Files (x86)\Steam\steamapps\common
cmake --build build --config Release    # Builds the Release configuration.
```
