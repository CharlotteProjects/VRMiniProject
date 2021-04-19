using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    AudioSource audioSource = null;
    public Transform spawnPosition = null;
    public List<GameObject> prefabsList = new List<GameObject>();
    public List<AudioClip> soundList = new List<AudioClip>();
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SpawnToolsAgain(int typeNumber)
    {
        audioSource.PlayOneShot(soundList[0]);
        Instantiate(prefabsList[typeNumber], spawnPosition);
    }
}
