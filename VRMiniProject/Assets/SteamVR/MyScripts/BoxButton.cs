using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR.InteractionSystem.Sample;

public class BoxButton : ButtonEffect
{
    public Color baseColor;

    public override void OnButtonDown(Hand fromHand)
    {
        if (Application.isEditor || Debug.isDebugBuild)
            Debug.Log("You onClick the 3D button for reset you tools.");

        GameObject.Find("GameManager").gameObject.SendMessage("ResetTools");

        ColorSelf(new Color(255f / 255f, 200f / 255f, 0));
        fromHand.TriggerHapticPulse(1000);
    }

    public override void OnButtonUp(Hand fromHand)
    {
        if (Application.isEditor || Debug.isDebugBuild)
            Debug.Log("You button up.");

        ColorSelf(baseColor);
    }

    public void ClickUpButton(Hand fromHand)
    {
        if (Application.isEditor || Debug.isDebugBuild)
            Debug.Log("You onClick the 3D button for up your ElevatingPlatform.");

        GameObject.Find("GameManager").gameObject.SendMessage("PlatformUpDown", true);

        ColorSelf(Color.yellow);
        fromHand.TriggerHapticPulse(1000);
    }

    public void ClickDownButton(Hand fromHand)
    {
        if (Application.isEditor || Debug.isDebugBuild)
            Debug.Log("You onClick the 3D button for down your ElevatingPlatform.");

        GameObject.Find("GameManager").gameObject.SendMessage("PlatformUpDown", false);

        ColorSelf(new Color(255f / 255f, 200f / 255f, 0));
        fromHand.TriggerHapticPulse(1000);
    }
}
