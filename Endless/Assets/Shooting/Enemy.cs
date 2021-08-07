using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Target;
    private float Speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Speed = Random.Range(1.0f, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
    }
}
