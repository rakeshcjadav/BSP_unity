using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int HitCount;
    public Updater updater;

    // Start is called before the first frame update
    void Start()
    {
        HitCount = Random.Range(0, 6) + 4;
        updater = transform.parent.GetComponentInChildren<Updater>();
        updater.DoUpdate(HitCount);
    }

    // Update is called once per frame
    void Update()
    {
        
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
