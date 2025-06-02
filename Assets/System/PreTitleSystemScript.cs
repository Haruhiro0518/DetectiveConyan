using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreTitleSystemScript : MonoBehaviour
{
    public GameObject infoUI;
    public GameObject skipUI;

    public GameObject textUI;
    private TextScrollScript textScript;
    
    public GameObject screenUI;
    private ScreenPreTitleScript screenScript;
    private AudioSource loadSE;

    public float initialValue;

    public bool isLoad;
    
    private void Start()
    {
        textScript = textUI.GetComponent<TextScrollScript>();
        screenScript = screenUI.GetComponent<ScreenPreTitleScript>();
        loadSE = screenUI.GetComponent<AudioSource>();
        MainSystemScript.audioVolume = initialValue;
    }

    private void Update()
    {
        if(isLoad == true && screenScript.isWait == true)
        {
            SceneManager.LoadScene("Title");
        }
    }

    public void CloseUI()
    {
        infoUI.SetActive(false);
        skipUI.SetActive(true);
        textUI.SetActive(true);
        textScript.isScroll = true;
    }

    public void LoadStart()
    {
        screenUI.SetActive(true);
        isLoad = true;
        loadSE.Play();
    }
}
