using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGenerator : MonoBehaviour
{
    public GameObject Prefab_Brick;
    public float BrickScale;
    public Vector2 GridOffset;
    // Start is called before the first frame update
    void Start()
    {
        for (int y = 0; y < 9; y++)
        {
            for (int x = -4; x <= 4; x++)
            {
                GameObject brick = Instantiate(Prefab_Brick, transform);
                brick.transform.position = transform.position + new Vector3(BrickScale * x + x* GridOffset.x, BrickScale * -y + -y * GridOffset.y, 0.0f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
