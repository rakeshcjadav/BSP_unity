using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Road : MonoBehaviour
{
    private RoadSegment RoadSegment;
    [SerializeField]private SpriteRenderer SpriteRenderer;
    public UnityAction<Road> OnRoadEnd;
    public List<Coin> Coins = new List<Coin>();

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
        foreach(Coin coin in Coins)
        {
            int spawn = Random.Range(0, 5);
            if (spawn > 2)
                coin.gameObject.SetActive(true);
            else
                coin.gameObject.SetActive(false);
        }
    }

    public void SetSegment(RoadSegment roadSegment)
    {
        RoadSegment = roadSegment;
        SpriteRenderer.color = RoadSegment.Color;
    }

    public void SpawnCoins(Coin PrefabCoin)
    {
        for (int x = -1; x < 2; x++)
        {
            for(int y = 0; y < 10; y++)
            {
                Coin coin = Instantiate(PrefabCoin, transform.position + new Vector3(x* 1.5f, -y, 0.0f), Quaternion.identity, transform) as Coin;
                Coins.Add(coin);
                coin.gameObject.SetActive(false);
            }
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.CompareTo("Player") == 0)
        {
            OnRoadEnd?.Invoke(this);
        }
    }
}
