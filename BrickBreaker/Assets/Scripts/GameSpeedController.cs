using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameSpeedController : MonoBehaviour
{
    public static UnityAction OnCollision;
    public static UnityAction SpeedReset;

    private Game game;
    private double timeSinceLastCollision = double.PositiveInfinity;
    private double timeSpeedChange = 2.0f;

    void Awake()
    {
        game = GetComponent<Game>();
        OnCollision += OnBallCollision;
        SpeedReset += GameSpeedReset;
    }

    private void FixedUpdate()
    {
        if(Time.fixedTime - timeSinceLastCollision >= timeSpeedChange)
        {
            game.IncreaseGameSpeed();
        }
    }

    public void OnBallCollision()
    {
        timeSinceLastCollision = Time.fixedTime;
        game.ResetGameSpeed();
    }

    public void GameSpeedReset()
    {
        timeSinceLastCollision = double.PositiveInfinity;
        game.ResetGameSpeed();
    }
}
