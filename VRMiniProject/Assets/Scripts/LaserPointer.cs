using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour
{

    [SerializeField]
    float range = 0.3f;

    [SerializeField]
    Laser l;

    Valve.VR.InteractionSystem.Hand _hand;

    GameObject selectingObj;

    // Use this for initialization
    void Start()
    {
        _hand = GetComponent<Valve.VR.InteractionSystem.Hand>();


        l.SetRange(range);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_hand.hoverLocked && !_hand.hoveringInteractable)
        {
            l.OnOff(true);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, range))
            {
                l.SetHitPont(hit.point);
//                if (hit.collider.GetComponent<Btn>())
//                {
                    if (selectingObj != hit.collider.gameObject)
                    {
                        if (selectingObj != null)
                            selectingObj.SendMessage("OnHandHoverEnd", _hand, SendMessageOptions.DontRequireReceiver);

                        selectingObj = hit.collider.gameObject;

                        selectingObj.SendMessage("OnHandHoverBegin", _hand, SendMessageOptions.DontRequireReceiver);
                    }
                    if (selectingObj != null)
                        selectingObj.SendMessage("HandHoverUpdate", _hand, SendMessageOptions.DontRequireReceiver);

                    l.SetTextue(true);
                    /*                if (_hand.GetStandardInteractionButtonDown())
                                    {
                                        selectingObj.SendMessage("OnHandHoverBegin", _hand);
                                    }*/
/*                }
                else
                {
                    if (selectingObj != null)
                        selectingObj.SendMessage("OnHandHoverEnd", _hand, SendMessageOptions.DontRequireReceiver);
                    selectingObj = null;

                    l.SetTextue(false);
                }*/
            }
            else
            {
                if (selectingObj != null)
                    selectingObj.SendMessage("OnHandHoverEnd", _hand, SendMessageOptions.DontRequireReceiver);
                selectingObj = null;

                l.SetTextue(false);
                l.SetNoHitPoint();
            }
        }
        else
        {
            l.OnOff(false);
        }

    }
}
