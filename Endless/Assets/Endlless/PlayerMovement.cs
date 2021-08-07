using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum LanIndex
{
    Left = -1,
    Middle = 0,
    Right = 1
};

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float Speed = 10.0f;
    private LanIndex LanIndex = LanIndex.Middle;
    private float LanWidth = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = 0.0f;
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (LanIndex != LanIndex.Left)
            {
                x = -1.0f;
                LanIndex--;
            }
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (LanIndex != LanIndex.Right)
            {
                x = 1.0f;
                LanIndex++;
            }
        }
        float y = Speed *Time.deltaTime;
        transform.position = new Vector3(transform.position.x + x * LanWidth, transform.position.y + y, transform.position.z);
    }
}
