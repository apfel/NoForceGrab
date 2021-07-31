// Copyright (c) 2021 Apfel
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

using System.Diagnostics;
using MelonLoader;
using ModThatIsNotMod.BoneMenu;
using UnityEngine;

public class NoForceGrab : MelonMod
{
    bool disableForceGrabRemoval = false;
    int updateWaitTime = 2000;

    Stopwatch waitTimer;

    private void updateDisableForceGrabRemoval(bool _new)
    {
        this.disableForceGrabRemoval = _new;

        if (this.disableForceGrabRemoval) this.waitTimer.Stop();
        else this.waitTimer.Start();
    }

    private void updateUpdateWaitTime(int _new)
    {
        this.updateWaitTime = _new;

        if (!this.disableForceGrabRemoval) this.waitTimer.Reset();
    }

    public override void OnApplicationStart()
    {
        waitTimer = new Stopwatch();

        MelonPreferences_Category prefCategory = MelonPreferences.CreateCategory("NoForceGrab", "No Force Grab");

        MelonPreferences_Entry<bool> disableEntry   = prefCategory.CreateEntry<bool>("DisableForceGrabRemoval", false, "Disable Force Grab removal", "Whether to disable the removal of Force Grabbing or not.");
        this.disableForceGrabRemoval                = disableEntry.Value;
        disableEntry.OnValueChanged                 += (_, _new) => updateDisableForceGrabRemoval(_new);

        MelonPreferences_Entry<int> timeEntry       = prefCategory.CreateEntry<int>("WaitTime", 2000, "Wait Time", "How long the update routine has to wait before it starts searching for Force Grab points, in milliseconds.");
        this.updateWaitTime                         = timeEntry.Value;
        timeEntry.OnValueChanged                    += (_, _new) => updateUpdateWaitTime(_new);

        MenuCategory category = ModThatIsNotMod.BoneMenu.MenuManager.CreateCategory("No Force Grab", Color.white);
        category.CreateBoolElement("Enabled", Color.white, !disableForceGrabRemoval, updateDisableForceGrabRemoval);
        category.CreateIntElement("Wait time", Color.white, updateWaitTime, updateUpdateWaitTime, 1, 1, 5000, true);

        if (!this.disableForceGrabRemoval) waitTimer.Start();
    }

    public override void OnFixedUpdate()
    {
        if (this.disableForceGrabRemoval || this.waitTimer.Elapsed.TotalMilliseconds < this.updateWaitTime) return;

        StressLevelZero.Interaction.ForcePullGrip grip = Object.FindObjectOfType<StressLevelZero.Interaction.ForcePullGrip>();
        if (grip != null) Object.Destroy(grip);

        StressLevelZero.Interaction.InteractableIcon icon = Object.FindObjectOfType<StressLevelZero.Interaction.InteractableIcon>();
        if (icon != null) Object.Destroy(icon);

        this.waitTimer.Restart();
    }

    public override void BONEWORKS_OnLoadingScreen() => this.waitTimer.Reset();
    public override void OnSceneWasInitialized(int buildIndex, string sceneName) => this.waitTimer.Restart();
}
