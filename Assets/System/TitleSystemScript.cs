using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSystemScript : MonoBehaviour
{
    public GameObject mainCamera;
    private AudioSource BGM;
    
    public GameObject screenUI;
    private ScreenTitleScript screenScript;
    private AudioSource loadSE;

    public static int clearNumber;
    private int sceneNumber;
    
    public bool isPause;
    public bool isLoad;

    private void Start()
    {
        BGM = mainCamera.GetComponent<AudioSource>();
        screenScript = screenUI.GetComponent<ScreenTitleScript>();
        loadSE = screenUI.GetComponent<AudioSource>();
        clearNumber = PlayerPrefs.GetInt("saveData", 0);
    }

    private void Update()
    {
        if(isLoad == true && screenScript.isWait == true)
        {
            SceneManager.LoadScene(sceneNumber + "F");
        }

        VolumeCheck();
    }

    private void VolumeCheck()
    {
        BGM.volume = MainSystemScript.audioVolume;
        loadSE.volume = MainSystemScript.audioVolume;
    }

    public void LoadEnd()
    {
        screenUI.SetActive(false);
    }

    public void LoadStart(int value)
    {
        sceneNumber = value;
        screenUI.SetActive(true);
        isLoad = true;
        loadSE.Play();
    }
}
