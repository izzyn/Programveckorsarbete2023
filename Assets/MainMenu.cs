using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)|| Input.GetKeyDown(KeyCode.Backspace))
        {
            Application.Quit();
        }
    }
}
