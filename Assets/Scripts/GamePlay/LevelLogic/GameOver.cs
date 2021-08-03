using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOverCanvas;
    void Start()
    {
        EventManager.AddZeroListener(EventName.GameOver, GameOverMenu);

    }

    private void GameOverMenu()
    {
        gameOverCanvas.SetActive(true);
    }


}
