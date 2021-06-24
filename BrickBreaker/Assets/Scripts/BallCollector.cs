using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallCollector : MonoBehaviour
{
    public static UnityAction<GameObject> OnFirstBallHitCollector;
    public static UnityAction<GameObject> OnBallHitCollector;

    private int BallHit = 0;

    public void Awake()
    {
        BallShooter.OnStartShooting += OnStartShooting;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.CompareTo("Ball") == 0)
        {
            if(BallHit == 0)
            {
                OnFirstBallHitCollector?.Invoke(collision.collider.gameObject);
                BallHit++;
            }
            OnBallHitCollector?.Invoke(collision.collider.gameObject);
        }
    }

    public void OnStartShooting()
    {
        BallHit = 0;
    }
}
