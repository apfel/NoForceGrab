// Copyright (c) 2021 apfel
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute and/or sublicense copies of
// the Software.
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using HarmonyLib;
using MelonLoader;
using ModThatIsNotMod.BoneMenu;
using UnityEngine;

[HarmonyPatch(typeof(StressLevelZero.Interaction.ForcePullGrip), "Start")]
internal static class ForcePullGripRemovalPatch
{
	private static void Postfix(StressLevelZero.Interaction.ForcePullGrip __instance)
	{
		if (!NoForceGrab.DisableForceGrabRemoval) Object.Destroy(__instance);
	}
}

[HarmonyPatch(typeof(StressLevelZero.Interaction.InteractableIcon), "AddIcon")]
internal static class InteractableIconRemovalPatch
{
	private static void Postfix(StressLevelZero.Interaction.InteractableIcon __instance)
	{
		if (!NoForceGrab.DisableForceGrabRemoval && !NoForceGrab.KeepInteractableIcons) Object.Destroy(__instance);
	}
}

public class NoForceGrab : MelonMod
{
    public static bool DisableForceGrabRemoval = false;
    public static bool KeepInteractableIcons = false;

    public override void OnApplicationStart()
    {
        MelonPreferences_Category prefCategory = MelonPreferences.CreateCategory("NoForceGrab", "No Force Grab");

        MelonPreferences_Entry<bool> disableEntry   = prefCategory.CreateEntry<bool>("Disabled", false, "Disable Force Grab removal", "Whether to disable the removal of Force Grabbing or not (scene reload required).");
        DisableForceGrabRemoval                     = disableEntry.Value;
        disableEntry.OnValueChanged                 += (_, _new) => DisableForceGrabRemoval = _new;

        MelonPreferences_Entry<bool> iconEntry  = prefCategory.CreateEntry<bool>("KeepInteractionIcons", false, "Don't remove interaction icons", "Whether to keep the white interaction icons on (previously) force-grabbable game objects or not. (scene reload required).");
        KeepInteractableIcons                   = iconEntry.Value;
        iconEntry.OnValueChanged                += (_, _new) => KeepInteractableIcons = _new;

        MenuCategory category = ModThatIsNotMod.BoneMenu.MenuManager.CreateCategory("No Force Grab", Color.white);
        category.CreateBoolElement("Disabled", Color.white, DisableForceGrabRemoval, (_new) => DisableForceGrabRemoval = _new);
        category.CreateBoolElement("Keep Interaction Icons", Color.white, KeepInteractableIcons, (_new) => KeepInteractableIcons = _new);
    }
}
