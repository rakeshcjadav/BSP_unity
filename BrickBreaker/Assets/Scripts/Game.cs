using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private float PreviousTimeScale = 1.0f;
    public void PauseGame()
    {
        if (Time.timeScale > 0.0f)
        {
            PreviousTimeScale = Time.timeScale;
            Time.timeScale = 0.0f;
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = PreviousTimeScale;
    }

    public void StartGame()
    {
        Time.timeScale = 1.0f;
    }

}
