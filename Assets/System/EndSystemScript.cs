using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSystemScript : MonoBehaviour
{
    public GameObject endUI;
    public GameObject skipUI;

    public GameObject textUI;
    private TextScrollScript textScript;
    
    public GameObject screenUI;
    private ScreenEndScript screenScript;
    private AudioSource loadSE;

    public GameObject camera;
    private AudioSource BGM;

    public bool isLoad;
    public bool isTitle;
    
    private void Start()
    {
        textScript = textUI.GetComponent<TextScrollScript>();
        screenScript = screenUI.GetComponent<ScreenEndScript>();
        loadSE = screenUI.GetComponent<AudioSource>();
        BGM = camera.GetComponent<AudioSource>();
        loadSE.volume = MainSystemScript.audioVolume;
        BGM.volume = MainSystemScript.audioVolume * 0.5f;
        TextStart();

        if(TitleSystemScript.clearNumber < 8)
        {
            TitleSystemScript.clearNumber++;
            PlayerPrefs.SetInt("saveData", TitleSystemScript.clearNumber);
            PlayerPrefs.Save();
        }
    }

    private void Update()
    {
        if(isTitle == true && screenScript.isWait == true)
        {
            SceneManager.LoadScene("Title");
        }
    }

    public void TextStart()
    {
        endUI.SetActive(false);
        skipUI.SetActive(true);
        textUI.SetActive(true);
        textScript.isScroll = true;
    }

    public void TextEnd()
    {
        endUI.SetActive(true);
        skipUI.SetActive(false);
        textUI.SetActive(false);
        textScript.isScroll = false;
    }

    public void LoadStart()
    {
        screenUI.SetActive(true);
        isLoad = true;
        loadSE.Play();
    }

    public void LoadEnd()
    {
        screenUI.SetActive(false);
    }

    public void LoadTitle()
    {
        isTitle = true;
        LoadStart();
    }
}
