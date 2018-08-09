using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameManager : MonoBehaviour {
    public TimeManager timeManager;
    public Animator pauseMenu;
    //private bool menuShow;

	// Use this for initialization
	void Start () {
        timeManager = GetComponent<TimeManager>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void GoToHome()
    {
        timeManager.TimeConfig(1);
        SceneManager.LoadScene(0);
    }

    public void GoToSceneSelect()
    {
        timeManager.TimeConfig(1);
        SceneManager.LoadScene(1);
    }
    
    public void OpenMenu()
    {
        timeManager.TimeConfig(0);
        //menuShow = true;
        pauseMenu.GetParameter(0).Equals(true);
        print("hello");
    }

    public void CloseMenu()
    {

        timeManager.TimeConfig(1);
        pauseMenu.GetParameter(0).Equals(false);
    }
        

    
}

