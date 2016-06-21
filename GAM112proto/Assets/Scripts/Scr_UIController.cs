using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Scr_UIController : MonoBehaviour {

    public GameObject pausedUI;
    public GameObject unpausedUI;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeScene (int scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

    public void PauseGame ()
    {
        Time.timeScale = 0;
        unpausedUI.SetActive(false);
        pausedUI.SetActive(true);
    }

    public void UnPauseGame ()
    {
        Time.timeScale = 1;
        unpausedUI.SetActive(true);
        pausedUI.SetActive(false);
    }
}
