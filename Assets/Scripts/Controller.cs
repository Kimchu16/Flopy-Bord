using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public void NextScene()
    {
        StartCoroutine(Wait());
        SceneManager.LoadScene("Scenes/Main");
    }
    public void MainMenu()
    {
        StartCoroutine(Wait());
        SceneManager.LoadScene("Scenes/Start");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
    }
}
