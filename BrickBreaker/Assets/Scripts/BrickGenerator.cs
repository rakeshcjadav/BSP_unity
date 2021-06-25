using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGenerator : MonoBehaviour
{
    public GameObject Prefab_Brick;
    public float BrickScale;
    void Start()
    {
        for (int y = 0; y < 9; y++)
        {
            for (int x = -4; x <= 4; x++)
            {
                GameObject brick = Instantiate(Prefab_Brick, transform);
                brick.transform.position = transform.position + 
                    new Vector3(BrickScale * x, BrickScale * -y, 0.0f);

                brick.transform.localScale = new Vector3(BrickScale, BrickScale, BrickScale);
            }
        }
    }
}
