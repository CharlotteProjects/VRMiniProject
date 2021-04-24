using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    [Header("---Platform---")]
    public ElevatingPlatformController platformController = null;
    [Header("---UI---")]
    public GameObject introObject = null;
    public GameObject menuObject = null;
    public Button closeButton = null;
    //! false = close menu, true = show menu
    bool menuButtonState = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ShowTheIntro();
    }

    #region Button Setting

    public void MenuButtonOnClick()
    {
        audioSource.PlayOneShot(soundList[3]);

        if (menuButtonState)
        {
            menuButtonState = false;

            ColorBlock colorBlock = closeButton.colors;
            colorBlock.normalColor = new Color(1, 135f / 255f, 135f / 255f, 1);
            colorBlock.highlightedColor = Color.red;
            colorBlock.pressedColor = new Color(150f / 255f, 0, 0, 1);
            colorBlock.selectedColor = new Color(1, 135f / 255f, 135f / 255f, 1);
            closeButton.colors = colorBlock;

            closeButton.gameObject.transform.GetComponentInChildren<TMP_Text>().text = "Close Menu";

            introObject.SetActive(true);
            menuObject.SetActive(true);
        }
        else
        {
            menuButtonState = true;

            ColorBlock colorBlock = closeButton.colors;
            colorBlock.normalColor = new Color(135f / 255f, 1, 135f / 255f, 1);
            colorBlock.highlightedColor = Color.green;
            colorBlock.pressedColor = new Color(0, 150f / 255f, 0, 1);
            colorBlock.selectedColor = new Color(135f / 255f, 1, 135f / 255f, 1);
            closeButton.colors = colorBlock;

            closeButton.gameObject.transform.GetComponentInChildren<TMP_Text>().text = "Show Menu";

            introObject.SetActive(false);
            menuObject.SetActive(false);
        }
    }

    #endregion

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

    #region Control The Platform

    public void PlatformUpDown(bool upDown)
    {
        if (upDown)
            audioSource.PlayOneShot(soundList[1]);
        else
            audioSource.PlayOneShot(soundList[2]);

        platformController.UpDown(upDown);
    }

    #endregion
}
