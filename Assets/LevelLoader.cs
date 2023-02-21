using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//fredrik
public class LevelLoader : MonoBehaviour
{

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    public void LoadLevel(int sceneIndex)
    {
        //starts the coroutine LoadAsynchronously
        StartCoroutine(LoadAsynchronously(sceneIndex));
        PlayerHealth.restoreHP();
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        //loads the next scene asynchronously and activates the loading screen
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            //updates the progress bar so it shows how close the game is to loading
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }
    }
}
