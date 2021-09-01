# No Force Grab
Removes Force Grabbing from every object in BONEWORKS.
Requires [MelonLoader](https://github.com/LavaGang/MelonLoader) 0.4 and [ModThatIsNotMod](https://boneworks.thunderstore.io/package/gnonme/ModThatIsNotMod/).

## Settings
You can change whether the mod is disabled (`Disabled`) and whether to keep the white interaction icons (`KeepInteractableIcons`) in your `MelonPreferences.cfg`.  
ModThatIsNotMod's BoneMenu is also supported.

## Compiling
Requires:
- .NET Framework 4.7.2 SDK
- CMake 3.10 or newer
- A copy of BONEWORKS with MelonLoader and ModThatIsNotMod installed

```ps1
cmake -B build                          # Creates a build folder, use -DBONEWORKS_DIR=<path> if you installed BONEWORKS somewhere outside of C:\Program Files (x86)\Steam\steamapps\common
cmake --build build --config Release    # Builds the Release configuration.
```

## ChangeLog
2.0.0:
- Replaced the wait timer and search mechanism with a Harmony-based patch
- Renamed settings values

1.1.1:
- Uploaded missing files
- Fixed a bug that would flip the Enabled status within BoneMenu

1.1.0:
- Added BoneMenu support
- Cleaned up some code

1.0.0:
Initial release. Later MIT-licensed.
