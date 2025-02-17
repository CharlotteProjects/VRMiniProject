﻿//======= Copyright (c) Valve Corporation, All rights reserved. ===============

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

namespace Valve.VR.InteractionSystem.Sample
{
    public class ButtonEffect : MonoBehaviour
    {
        public virtual void OnButtonDown(Hand fromHand)
        {
            ColorSelf(Color.green);
            fromHand.TriggerHapticPulse(1000);
        }

        public virtual void OnButtonUp(Hand fromHand)
        {
            ColorSelf(Color.red);
        }

        protected void ColorSelf(Color newColor)
        {
            Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
            for (int rendererIndex = 0; rendererIndex < renderers.Length; rendererIndex++)
            {
                renderers[rendererIndex].material.color = newColor;
            }
        }
    }
}