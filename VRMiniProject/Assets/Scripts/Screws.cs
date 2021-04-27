using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screws : MonoBehaviour
{
    GameManager gameManager = null;
    public string myTargerTools = "";
    Coroutine unscrew;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Application.isEditor || Debug.isDebugBuild)
            Debug.Log("hit Trigger");

        if (other.gameObject.name.Equals(myTargerTools))
        {
            unscrew = StartCoroutine(Unscrew());
        }
    }

    IEnumerator Unscrew()
    {
        yield return new WaitForSeconds(1f);

        gameManager.Unscrews();
        this.gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (Application.isEditor || Debug.isDebugBuild)
            Debug.Log("lose Trigger");

        if (other.gameObject.name.Equals(myTargerTools))
        {
            if (unscrew != null)
            {
                StopCoroutine(unscrew);
                unscrew = null;
            }
        }
    }
}
