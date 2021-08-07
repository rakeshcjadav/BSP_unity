using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBodyBullet;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.up * 10.0f * Time.fixedDeltaTime;
    }

    public void ApplyForce(Vector2 vec)
    {
        //rigidBodyBullet.AddForce()
    }
}
