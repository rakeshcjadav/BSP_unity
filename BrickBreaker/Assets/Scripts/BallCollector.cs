using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollector : MonoBehaviour
{
    public BallShooter ballShooter;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.CompareTo("Ball") == 0)
        {
            ballShooter.GetComponent<BallShooter>().CollectBall(collision.collider.gameObject);
           // collision.collider.gameObject;
        }
    }
}
