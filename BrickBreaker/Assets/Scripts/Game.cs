using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Game : MonoBehaviour
{
    private float PreviousTimeScale = 1.0f;
    private float _gameSpeed;
    private int GamePausedCount = 0;
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
            /*GamePausedCount++;
            Analytics.CustomEvent("brickbreaker_game_paused", new Dictionary<string, object>
            {
                { "Game_Paused", GamePausedCount },
            });*/
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = PreviousTimeScale;
    }

    public void StartGame()
    {
        Time.timeScale = 1.0f;
        /*
        Analytics.CustomEvent("brickbreaker_game_start", new Dictionary<string, object>
        {
        });
        */
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
