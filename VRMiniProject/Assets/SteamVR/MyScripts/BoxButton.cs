using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem.Sample;

public class BoxButton : ButtonEffect
{
    public override void OnButtonDown(Valve.VR.InteractionSystem.Hand fromHand)
    {
        if (Application.isEditor || Debug.isDebugBuild)
            Debug.Log("You onClick the 3D button for reset you tools.");

        GameObject.Find("GameManager").gameObject.SendMessage("ResetTools");

        base.OnButtonDown(fromHand);
    }

    public override void OnButtonUp(Valve.VR.InteractionSystem.Hand fromHand)
    {
        if (Application.isEditor || Debug.isDebugBuild)
            Debug.Log("You button up.");

        base.OnButtonUp(fromHand);
    }
}
