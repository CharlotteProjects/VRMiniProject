using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatingPlatformController : MonoBehaviour
{
    public List<GameObject> R_iron = new List<GameObject>();
    public List<GameObject> L_iron = new List<GameObject>();


    public List<GameObject> platformObject_ZGroup = new List<GameObject>();
    public List<GameObject> platformObject_YGroup = new List<GameObject>();

    int upMaxTime = 3;
    int downMaxTime = 8;
    int onClickNum = 0;

    void Start()
    {

    }

    public void UpDown(bool up)
    {
        float RorativeValue = 0;

        if (up)
        {
            if (onClickNum <= upMaxTime)
                onClickNum++;

            RorativeValue = 2;

            if (Application.isEditor || Debug.isDebugBuild)
                Debug.Log("OnClick the platform up button");
        }
        else
        {
            if (onClickNum >= -downMaxTime)
                onClickNum--;

            RorativeValue = -2;

            if (Application.isEditor || Debug.isDebugBuild)
                Debug.Log("OnClick the platform down button");
        }

        //! limit the onClick Time
        if (onClickNum >= -downMaxTime && onClickNum <= upMaxTime)
        {
            //! Control Rotation
            for (int i = 0; i < R_iron.Count; i++)
            {
                R_iron[i].transform.Rotate(new Vector3(0, RorativeValue, 0));
                L_iron[i].transform.Rotate(new Vector3(0, -RorativeValue, 0));
            }

            //! Control up / down
            for (int i = 0; i < platformObject_ZGroup.Count; i++)
            {
                platformObject_ZGroup[i].transform.Translate(new Vector3(0, 0, RorativeValue / 20f));
            }
            for (int i = 0; i < platformObject_YGroup.Count; i++)
            {
                platformObject_YGroup[i].transform.Translate(new Vector3(0, RorativeValue / 20f, 0));
            }
        }
    }
}
