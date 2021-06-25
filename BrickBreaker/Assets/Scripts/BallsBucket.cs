using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallsBucket
{
    public int Capacity = 1;
    public List<GameObject> Balls = new List<GameObject>();
    private int RemainingBallsInBasket;

    public static UnityAction<int> OnBallNumberUpdate;
    public static UnityAction OnFirstBallFired;
    public static UnityAction OnFirstBallCollected;
    public static UnityAction OnAllBallsCollected;
    public static UnityAction OnBasketFull;

    public int BallsInBasket
    {
        get { return RemainingBallsInBasket; }
        private set { }
    }

    public bool IsEmpty
    {
        get { return (RemainingBallsInBasket == 0); }
        private set { }
    }

    public bool IsFull
    {
        get { return (RemainingBallsInBasket == Capacity); }
        private set { }
    }

    public BallsBucket(int capacity)
    {
        Capacity = capacity;
        RemainingBallsInBasket = Capacity;
        BallShooter.OnBallShoot += OnBallFired;
        Ball.OnBallReturnedToBasket += BallReturnedToBasket;
    }

    public void FillBucket(GameObject prefab, Transform transform)
    {
        for (int i = 0; i < Capacity; i++)
        {
            GameObject ball = GameObject.Instantiate(prefab, transform);
            ball.SetActive(false);
            ball.name = "Ball " + i.ToString();
            Balls.Add(ball);
        }
    }

    public void CollectAllBalls(Vector3 pos)
    {
        foreach (GameObject ball in Balls)
        {
            Ball ballScript = ball.GetComponent<Ball>();
            if(ballScript.isActiveAndEnabled)
            {
                ballScript.ReturnToBasket(pos);
            }
        }
        OnAllBallsCollected?.Invoke();
    }

    public void OnBallFired()
    {
        if (RemainingBallsInBasket == Capacity)
            OnFirstBallFired?.Invoke();
        RemainingBallsInBasket--;
        OnBallNumberUpdate?.Invoke(RemainingBallsInBasket);
    }

    public void BallReturnedToBasket()
    {
        RemainingBallsInBasket++;
        OnBallNumberUpdate?.Invoke(RemainingBallsInBasket);
        if (RemainingBallsInBasket == Capacity)
            OnBasketFull?.Invoke();
    }
}
