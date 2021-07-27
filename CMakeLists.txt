cmake_minimum_required(VERSION 3.10.0)
project(NoForceGrab CSharp)

set(BONEWORKS_DIR "C:\\Program Files (x86)\\Steam\\steamapps\\common\\BONEWORKS")

add_library(NoForceGrab SHARED
    ${CMAKE_CURRENT_LIST_DIR}/Manifest.cs

    ${CMAKE_CURRENT_LIST_DIR}/NoForceGrab.cs
)

target_compile_options(NoForceGrab PRIVATE "/langversion:latest")

set_property(TARGET NoForceGrab PROPERTY VS_DOTNET_TARGET_FRAMEWORK_VERSION "v4.7.2")
set_property(TARGET NoForceGrab PROPERTY VS_DOTNET_REFERENCES
    "Microsoft.CSharp"
    "System"
    "System.Core"
    "System.Data"
)

set_property(TARGET NoForceGrab PROPERTY VS_DOTNET_REFERENCE_MelonLoader            ${BONEWORKS_DIR}/BONEWORKS/MelonLoader/MelonLoader.dll)
set_property(TARGET NoForceGrab PROPERTY VS_DOTNET_REFERENCE_AssemblyCSharp         ${BONEWORKS_DIR}/BONEWORKS/MelonLoader/Managed/Assembly-CSharp.dll)
set_property(TARGET NoForceGrab PROPERTY VS_DOTNET_REFERENCE_Il2Cppmscorlib         ${BONEWORKS_DIR}/BONEWORKS/MelonLoader/Managed/Il2Cppmscorlib.dll)
set_property(TARGET NoForceGrab PROPERTY VS_DOTNET_REFERENCE_UnhollowerBaseLib      ${BONEWORKS_DIR}/BONEWORKS/MelonLoader/Managed/UnhollowerBaseLib.dll)
set_property(TARGET NoForceGrab PROPERTY VS_DOTNET_REFERENCE_UnityEngineCoreModule  ${BONEWORKS_DIR}/BONEWORKS/MelonLoader/Managed/UnityEngine.CoreModule.dll)
