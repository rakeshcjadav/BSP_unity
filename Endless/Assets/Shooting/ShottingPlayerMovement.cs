using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShottingPlayerMovement : MonoBehaviour
{
    [SerializeField] private float Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float y = Input.GetAxis("Vertical") * Speed * Time.deltaTime;

        transform.position += new Vector3(x, y, 0.0f);
    }
}
