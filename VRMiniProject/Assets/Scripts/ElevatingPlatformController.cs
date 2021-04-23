using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatingPlatformController : MonoBehaviour
{
    public List<GameObject> R_iron = new List<GameObject>();
    public List<GameObject> L_iron = new List<GameObject>();

    void Start()
    {

    }

    public void UpDown(bool up)
    {
        if (Application.isEditor || Debug.isDebugBuild)
            Debug.Log("OnClick the platform up button");

        for (int i = 0; i < R_iron.Count; i++)
        {
            R_iron[i].transform.Rotate(new Vector3(0, 5, 0));
            L_iron[i].transform.Rotate(new Vector3(0, -5, 0));
        }
    }
}
