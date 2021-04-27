using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportRockTrigger : MonoBehaviour
{
    GameManager gameManager = null;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Application.isEditor || Debug.isDebugBuild)
            Debug.Log("hit support rock Trigger");

        if (other.gameObject.name.Equals("SupportRock"))
        {
            Destroy(other.gameObject);
            gameManager.FinishGame();
        }
    }
}
