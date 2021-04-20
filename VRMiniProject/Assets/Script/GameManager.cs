using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    enum ProgramStep
    {
        Step1,
        Step2,
    }
    ProgramStep programStep = ProgramStep.Step1;
    AudioSource audioSource = null;

    [Header("---Spawn Object---")]
    public Transform spawnPosition = null;
    public List<GameObject> prefabsList = new List<GameObject>();
    public List<AudioClip> soundList = new List<AudioClip>();

    [Header("---Spawn Object---")]
    public TMP_Text introText = null;
    List<string> introList = new List<string>{
        "Step 1 :\nPlease choose the screwdriver and unscrew the screwd under the wing of airplane."
    };

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ShowTheIntro();
    }

    public void SpawnToolsAgain(int typeNumber)
    {
        audioSource.PlayOneShot(soundList[0]);
        Instantiate(prefabsList[typeNumber], spawnPosition);
    }

    void ShowTheIntro()
    {
        switch (programStep)
        {
            case ProgramStep.Step1:
                introText.text = introList[0];
                break;

        }
    }
}
