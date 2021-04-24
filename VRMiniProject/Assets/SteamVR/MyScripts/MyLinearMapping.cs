using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class MyLinearMapping : LinearMapping
{
    public string targetMethodName = "";
    void Start()
    {
        StartCoroutine(UpdateValue());
    }

    IEnumerator UpdateValue()
    {
        while (true)
        {
            GameObject.Find("GameManager").transform.SendMessage(targetMethodName, base.value);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
