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
    public List<Transform> spawnPosition = new List<Transform>();
    public List<GameObject> prefabsList = new List<GameObject>();
    public List<AudioClip> soundList = new List<AudioClip>();
    public DeleteTools tableTrigger = null;

    [Header("---Intro---")]
    public TMP_Text introText = null;
    List<string> introList = new List<string>{
        "Step 1 :\nPlease choose the screwdriver and unscrew the screwd under the wing of airplane."
    };



    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ShowTheIntro();
    }

    #region The Tool reset spwan setting

    public void SpawnToolsAgain(int typeNumber)
    {
        audioSource.PlayOneShot(soundList[0]);
        Instantiate(prefabsList[typeNumber], spawnPosition[typeNumber]);
    }

    public void ResetTools()
    {
        StartCoroutine(_ResetTools());
    }

    IEnumerator _ResetTools()
    {
        audioSource.PlayOneShot(soundList[0]);

        tableTrigger.delObject = true;

        yield return new WaitForSeconds(0.2f);

        tableTrigger.delObject = false;

        for (int i = 0; i < prefabsList.Count; i++)
            Instantiate(prefabsList[i], spawnPosition[i]);
    }

    #endregion

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
