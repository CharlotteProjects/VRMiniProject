using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPosition : MonoBehaviour
{
    AudioSource audioSource = null;
    [SerializeField] int myNumber = 0;
    bool hit = false;
    bool took = false;
    GameManager gameManager = null;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").gameObject.transform.GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (took)
        {
            audioSource.Play();
            took = false;
        }

        if ((other.gameObject.name == "Terrain" || other.gameObject.name == "WorldBottom") && !hit)
        {
            if (Application.isEditor) Debug.Log($"{name} hit the ground");
            hit = true;
            gameManager.SpawnToolsAgain(myNumber);
        }
    }

    public void TookObject()
    {
        StartCoroutine(_TookObject());
    }

    IEnumerator _TookObject()
    {
        yield return new WaitForSeconds(0.5f);
        took = true;
    }
}
