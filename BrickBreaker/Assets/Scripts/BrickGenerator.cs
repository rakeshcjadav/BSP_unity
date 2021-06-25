using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGenerator : MonoBehaviour
{
    public GameObject Prefab_Brick;
    public float BrickScale;
    public Vector2Int Size;

    void Start()
    {
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        for (int x = -(Size.x - 1) / 2; x <= (Size.x - 1) / 2; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                GameObject brick = Instantiate(Prefab_Brick, transform);
                brick.transform.position = transform.position +
                    new Vector3(BrickScale * x, BrickScale * -y, 0.0f);

                brick.transform.localScale = new Vector3(BrickScale, BrickScale, BrickScale);
            }
        }
    }

    public void Clear()
    {
        int childs = transform.childCount;
        for (int i = childs - 1; i >= 0; i--)
        {
            GameObject.DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }

}
