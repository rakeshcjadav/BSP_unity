using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private float PreviousTimeScale = 1.0f;
    private float _gameSpeed;
    private float GameSpeed {
        get
        {
            return _gameSpeed;
        }
        set
        {
            _gameSpeed = value;
            Time.timeScale = _gameSpeed;
        }
    }

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

    public void IncreaseGameSpeed()
    {
        if(GameSpeed <= 4.0f)
            GameSpeed += 1.0f;
    }

    public void DecreaseGameSpeed()
    {
        GameSpeed = 1.0f;
    }

    public void ResetGameSpeed()
    {
        GameSpeed = 1.0f;
    }
}
