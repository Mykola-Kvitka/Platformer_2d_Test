using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void HandleRestartButtonOnClickEvent()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void HandleExitButtonOnClickEvent()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
