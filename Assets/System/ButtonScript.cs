using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject targetUI;

    public GameObject mainSystem;
    private MainSystemScript mainSystemScript;

    private void Start()
    {
        mainSystemScript = mainSystem.GetComponent<MainSystemScript>();
    }
    
    public void OpenUI()
    {
        targetUI.SetActive(true);
        mainSystemScript.isPause = true;
    }
    
    public void CloseUI()
    {
        targetUI.SetActive(false);
        mainSystemScript.isPause = false;
    }

    public void SelectAnswer(bool answer)
    {
        if(answer == true)
        {
            mainSystemScript.OpenWall();
        }
        else
        {
            mainSystemScript.ResetPosition();
        }

        CloseUI();
    }

    public void SelectRestart()
    {
        mainSystemScript.LoadStart(mainSystemScript.sceneCurrent);
    }

    public void SelectTitle()
    {
        mainSystemScript.LoadStart(0);
    }

    public void SelectNext()
    {
        mainSystemScript.LoadStart(mainSystemScript.sceneCurrent + 1);
    }
}
