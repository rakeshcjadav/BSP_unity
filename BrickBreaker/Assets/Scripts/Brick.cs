using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int HitCount;
    public Updater updater;

    void Start()
    {
        HitCount = Random.Range(0, 89) + 2;
        updater = transform.parent.GetComponentInChildren<Updater>();
        updater.DoUpdate(HitCount);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag.CompareTo("Ball") == 0)
        {
            collision.collider.gameObject.GetComponent<AudioSource>().Play();
            HitCount--;
            updater.DoUpdate(HitCount);
            if (HitCount == 0)
            {
                Destroy(transform.parent.gameObject);
            }
            GameSpeedController.OnCollision();
        }
    }
}
