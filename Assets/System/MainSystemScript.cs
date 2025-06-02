using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainSystemScript : MonoBehaviour
{
    public GameObject mainCamera;
    private CameraScript cameraScript;
    
    public GameObject player;
    private PlayerScript playerScript;

    public GameObject timeText;
    private TextMeshProUGUI timeTextTMP;
    
    public GameObject wall;
    public GameObject light;

    public GameObject clearScreen;
    private AudioSource clearSE;
    public GameObject overScreen;
    private AudioSource overSE;

    public AudioSource infoSE;
    public AudioSource switchSE;

    public AudioSource statueSE;

    public GameObject loadScreen;
    private ScreenScript screenScript;
    private AudioSource loadSE;

    public float timeLimit;
    private float timeCurrent;
    public float penaltyValue;

    public static float audioVolume;

    public int sceneCurrent;
    private int sceneNumber;
    
    public bool isReverse;
    public bool isPause;
    public bool isClear;
    public bool isOver;
    public bool isLoad;
    
    private void Start()
    {
        cameraScript = mainCamera.GetComponent<CameraScript>();
        playerScript = player.GetComponent<PlayerScript>();
        timeTextTMP = timeText.GetComponent<TextMeshProUGUI>();
        screenScript = loadScreen.GetComponent<ScreenScript>();
        timeCurrent = timeLimit;
        clearSE = clearScreen.GetComponent<AudioSource>();
        overSE = overScreen.GetComponent<AudioSource>();
        loadSE = loadScreen.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(isPause != true && isClear != true && isOver != true)
        {
            TimeCheck();
        }

        if(isPause != true)
        {
            ClearCheck();
            OverCheck();
        }
        
        if(isPause == true)
        {
            LoadCheck();
        }

        VolumeCheck();
    }

    private void TimeCheck()
    {
        timeCurrent = timeCurrent - Time.deltaTime;
        timeTextTMP.SetText(timeCurrent.ToString("f0"));

        if(timeCurrent < 0.0f)
        {
            isOver = true;
        }
    }

    public void TimePenalty()
    {
        if(timeCurrent > 0.0f && playerScript.isDamage != true)
        {
            timeCurrent = timeCurrent - penaltyValue;
            StartCoroutine(playerScript.Damage());
        }
    }

    public void OpenWall()
    {
        wall.SetActive(false);
        cameraScript.answerTrueSE.Play();
    }

    public void ResetPosition()
    {
        playerScript.ResetPosition();
        cameraScript.answerFalseSE.Play();
    }

    public void SetOver()
    {
        timeCurrent = 0.0f;
    }

    private void ClearCheck()
    {
        if(isClear == true)
        {
            isPause = true;
            clearScreen.SetActive(true);
            clearSE.Play();
            
            if(TitleSystemScript.clearNumber < sceneCurrent)
            {
                TitleSystemScript.clearNumber++;
                PlayerPrefs.SetInt("saveData", TitleSystemScript.clearNumber);
                PlayerPrefs.Save();
            }
        }
    }

    private void OverCheck()
    {
        if(isOver == true)
        {
            isPause = true;
            light.SetActive(false);
            overScreen.SetActive(true);
            overSE.Play();
        }
    }

    private void VolumeCheck()
    {
        cameraScript.BGM.volume = audioVolume;
        cameraScript.answerTrueSE.volume = audioVolume;
        cameraScript.answerFalseSE.volume = audioVolume;
        playerScript.jumpSE.volume = audioVolume;
        playerScript.damageSE.volume = audioVolume;
        infoSE.volume = audioVolume;
        switchSE.volume = audioVolume;
        statueSE.volume = audioVolume;
        clearSE.volume = audioVolume;
        overSE.volume = audioVolume;
        loadSE.volume = audioVolume;
    }

    public void LoadEnd()
    {
        loadScreen.SetActive(false);
    }

    public void LoadStart(int value)
    {
        sceneNumber = value;
        loadScreen.SetActive(true);
        isLoad = true;
        loadSE.Play();
    }

    private void LoadCheck()
    {
        if(isLoad == true && screenScript.isWait == true)
        {
            if(sceneNumber != 0)
            {
                SceneManager.LoadScene(sceneNumber + "F");
            }
            else
            {
                SceneManager.LoadScene("Title");
            }
        }
    }
}
