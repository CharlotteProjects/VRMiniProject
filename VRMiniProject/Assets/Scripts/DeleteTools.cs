using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTools : MonoBehaviour
{
    public bool delObject = false;
    private void OnTriggerStay(Collider other)
    {
        if (delObject && other.tag == "Tools")
            Destroy(other.gameObject);
    }
}
