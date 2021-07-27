# Copyright (c) 2021 Apfel
#
# Permission is hereby granted, free of charge, to any person obtaining a copy
# of this software and associated documentation files (the "Software"), to deal
# in the Software without restriction, including without limitation the rights
# to use, copy, modify, merge, publish, distribute and/or sublicense copies of
# the Software.
#
# The above copyright notice and this permission notice shall be included in all
# copies or substantial portions of the Software.
#
# THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
# IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
# FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
# AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
# LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
# OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
# SOFTWARE.

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
