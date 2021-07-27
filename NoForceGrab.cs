using System.Diagnostics;
using MelonLoader;
using UnityEngine;

public class NoForceGrab : MelonMod
{
    bool disableForceGrabRemoval = false;
    int updateWaitTime = 2000;

    Stopwatch waitTimer;

    public override void OnApplicationStart()
    {
        MelonPreferences.CreateCategory("NoForceGrab", "No Force Grab").CreateEntry<bool>("DisableForceGrabRemoval", false, "Whether to disable the removal of Force Grabbing or not.", false);
        MelonPreferences.CreateCategory("NoForceGrab", "No Force Grab").CreateEntry<int>("WaitTime", 2000, "How long the update routine has to wait before it starts searching for Force Grab points, in milliseconds.", false);

        MelonPreferences_Entry<bool> disableEntry = MelonPreferences.GetCategory("NoForceGrab").GetEntry<bool>("DisableForceGrabRemoval");
        this.disableForceGrabRemoval    = disableEntry.Value;
        disableEntry.OnValueChanged     += (old, _new) => this.disableForceGrabRemoval = _new;

        MelonPreferences_Entry<int> timeEntry = MelonPreferences.GetCategory("NoForceGrab").GetEntry<int>("WaitTime");
        this.updateWaitTime         = timeEntry.Value;
        timeEntry.OnValueChanged    += (old, _new) =>
        {
            this.updateWaitTime = _new;
            this.waitTimer?.Reset();
        };

        waitTimer = new Stopwatch();
        waitTimer.Start();
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
}
