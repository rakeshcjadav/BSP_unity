using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingDirection : MonoBehaviour
{
    [SerializeField]
    public int Count = 10;
    public GameObject BallPrefab;
    [HideInInspector]
    public Vector3 Direction;

    public BoxCollider2D LeftWall;
    public BoxCollider2D RightWall;
    public BoxCollider2D TopWall;

    private List<GameObject> list = new List<GameObject>();

    void Awake()
    {
        for(int i = 0; i < Count; i++)
        {
            GameObject ball = Instantiate(BallPrefab, transform);
            list.Add(ball);
        }

        LeftWall = GameObject.FindGameObjectWithTag("LeftWall").GetComponent<BoxCollider2D>();
        RightWall = GameObject.FindGameObjectWithTag("RightWall").GetComponent<BoxCollider2D>();
        TopWall = GameObject.FindGameObjectWithTag("TopWall").GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
    }

    private void Update()
    {
        Vector3 dir = Direction;
        Vector3 previousPos = transform.position;
        foreach (GameObject ball in list)
        {
            Vector3 pos = previousPos + 0.2f * dir;
            RaycastHit2D hit = Physics2D.CircleCast(previousPos, 0.075f, dir, 0.2f, (1 << 9 | 1 << 6));
            if (hit.collider != null)
            {
                dir = Vector3.Reflect(dir, hit.normal);
                pos = previousPos + 0.2f * dir;
            }
            ball.transform.position = pos;
            previousPos = pos;
        }
    }
}
