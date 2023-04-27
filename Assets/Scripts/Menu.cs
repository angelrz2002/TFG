using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public GameObject pausedPanel;

    private bool isGamePaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isGamePaused =! isGamePaused;
            PausedGame();
        }
    }

    public void PausedGame()
    {
        if (isGamePaused)
        {
            Time.timeScale = 0;

            pausedPanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;

            pausedPanel.SetActive(false);
        }
    }
}
