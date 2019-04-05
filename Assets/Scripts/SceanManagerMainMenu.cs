using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceanManagerMainMenu : MonoBehaviour {

    public void ButtonClick()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void PauseButtonClick()
    {
        Time.timeScale = 0;
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;

    }

    public void ExitButtonClick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

}
