using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public GameManager gameManager = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Airplane"))
        {
            gameManager.stopMove = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Airplane"))
        {
            gameManager.stopMove = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Airplane"))
        {
            gameManager.stopMove = false;
        }
    }
}
