using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTitleScript : MonoBehaviour
{
    public GameObject targetUI;

    public GameObject titleSystem;
    private TitleSystemScript titleSystemScript;

    public int sceneNumber;

    private void Start()
    {
        titleSystemScript = titleSystem.GetComponent<TitleSystemScript>();
    }

    public void OpenUI()
    {
        targetUI.SetActive(true);
        titleSystemScript.isPause = true;
    }
    
    public void CloseUI()
    {
        targetUI.SetActive(false);
        titleSystemScript.isPause = false;
    }

    public void SelectScene()
    {
        if(TitleSystemScript.clearNumber + 1 < sceneNumber)
        {
            OpenUI();
        }
        else
        {
            titleSystemScript.LoadStart(sceneNumber);
        }
    }
}
