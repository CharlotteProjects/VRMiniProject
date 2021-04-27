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

    #region Tools

    [Header("---Spawn Object---")]
    public List<Transform> spawnPosition = new List<Transform>();
    public List<GameObject> prefabsList = new List<GameObject>();
    public List<AudioClip> soundList = new List<AudioClip>();
    public DeleteTools tableTrigger = null;

    #endregion

    [Header("---Intro---")]
    public TMP_Text introText = null;
    public TMP_Text introTextAir = null;
    List<string> introList = new List<string>{
        "Step 1 :\nPlease choose the Tool and move the platfrom side the wing",
        "Step 2 :\nThen You can teleport to the up area of the wing.",
        "Step 3 :\nPlease chose the Tool and remove the scrwe of the slap support",
        "Stap 4 :\nPlease remove the Slap."
    };

    #region Platform

    [Header("---Platform---")]
    float movementValue = 0;
    float rotateValue = 0;
    bool upDownCoolDown = false;
    public GameObject Platform = null;
    public ElevatingPlatformController platformController = null;
    [System.NonSerialized] public bool stopMove = false;

    #endregion

    #region UI

    [Header("---UI---")]
    public GameObject introObject = null;
    public GameObject menuObject = null;
    public Button closeButton = null;
    public Button easyButton = null;
    public Button hardButton = null;

    //! false = close menu, true = show menu
    bool menuButtonState = false;

    [Header("---AirplaneUI---")]
    public GameObject introObjectAir = null;

    #endregion

    #region Training Content

    public GameObject easyModeScrewsGroup = null;
    public GameObject hardModeScrewsGroup = null;

    #endregion

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        Initilization_Button();

        ShowTheIntro(0);
    }
    private void Update()
    {
        if (movementValue >= 0.85f)
        {
            Platform.transform.Translate(Vector3.left * Time.deltaTime * 2);
        }
        else if (movementValue <= 0.15f && !stopMove)
        {
            Platform.transform.Translate(Vector3.right * Time.deltaTime * 2);
        }

        if (rotateValue >= 0.85f)
        {
            Platform.transform.Rotate(Vector3.up * Time.deltaTime * 4);
        }
        else if (rotateValue <= 0.15f)
        {
            Platform.transform.Rotate(Vector3.down * Time.deltaTime * 4);
        }
    }

    #region Button Setting
    /*
    All button are active by UIElement.cs
    */

    void Initilization_Button()
    {
        easyButton.colors = ButtonColorToGreen(easyButton.colors);
        hardButton.colors = ButtonColorToRed(hardButton.colors);
    }

    public void MenuButtonOnClick()
    {
        audioSource.PlayOneShot(soundList[3]);

        if (menuButtonState)
        {
            menuButtonState = false;

            closeButton.colors = ButtonColorToRed(closeButton.colors);
            closeButton.gameObject.transform.GetComponentInChildren<TMP_Text>().text = "Close Menu";

            introObject.SetActive(true);
            menuObject.SetActive(true);
        }
        else
        {
            menuButtonState = true;

            closeButton.colors = ButtonColorToGreen(closeButton.colors);
            closeButton.gameObject.transform.GetComponentInChildren<TMP_Text>().text = "Show Menu";

            introObject.SetActive(false);
            menuObject.SetActive(false);
            introObjectAir.SetActive(false);
        }
    }

    public void easyButtonOnClick()
    {
        audioSource.PlayOneShot(soundList[3]);
        easyButton.colors = ButtonColorToGreen(easyButton.colors);
        hardButton.colors = ButtonColorToRed(hardButton.colors);
        easyModeScrewsGroup.SetActive(true);
        hardModeScrewsGroup.SetActive(false);
    }

    public void hardButtonOnClick()
    {
        audioSource.PlayOneShot(soundList[3]);
        easyButton.colors = ButtonColorToRed(easyButton.colors);
        hardButton.colors = ButtonColorToGreen(hardButton.colors);
        easyModeScrewsGroup.SetActive(false);
        hardModeScrewsGroup.SetActive(true);
    }

    ColorBlock ButtonColorToRed(ColorBlock colorBlock)
    {
        colorBlock.normalColor = new Color(1, 135f / 255f, 135f / 255f, 1);
        colorBlock.highlightedColor = Color.red;
        colorBlock.pressedColor = new Color(150f / 255f, 0, 0, 1);
        colorBlock.selectedColor = new Color(1, 135f / 255f, 135f / 255f, 1);

        return colorBlock;
    }

    ColorBlock ButtonColorToGreen(ColorBlock colorBlock)
    {
        colorBlock.normalColor = new Color(135f / 255f, 1, 135f / 255f, 1);
        colorBlock.highlightedColor = Color.green;
        colorBlock.pressedColor = new Color(0, 150f / 255f, 0, 1);
        colorBlock.selectedColor = new Color(135f / 255f, 1, 135f / 255f, 1);

        return colorBlock;
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

    void ShowTheIntro(int num)
    {
        switch (programStep)
        {
            case ProgramStep.Step1:
                introText.text = introList[num];
                introTextAir.text = introList[num];
                break;
        }

    }

    #region Control The Platform

    ///<summary> CD is 1 second</summary>
    public void PlatformUpDown(bool upDown)
    {
        if (!upDownCoolDown)
        {
            StartCoroutine(PlatformCoolDown());
            if (upDown)
                audioSource.PlayOneShot(soundList[1]);
            else
                audioSource.PlayOneShot(soundList[2]);

            platformController.UpDown(upDown);
        }
    }

    public void SetPlatformFrontBack(float value)
    {
        movementValue = value;
    }

    public void SetPlatformRightLeft(float value)
    {
        rotateValue = value;
    }

    ///<summary> CD is 1 second</summary>
    IEnumerator PlatformCoolDown()
    {
        upDownCoolDown = true;
        yield return new WaitForSeconds(1);
        upDownCoolDown = false;
    }

    #endregion

    #region Training Content


    #endregion
}
