using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] private int MaxRoads = 5;
    public Road PrefabGameObject;
    public Coin PrefabCoin;
    private List<Road> Roads = new List<Road>();
    private Vector3 NextRoadPos = Vector3.zero;
    public RoadSegment[] RoadSegments;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < MaxRoads; i ++)
        {
            Road road = Instantiate(PrefabGameObject, transform.position, Quaternion.identity, transform) as Road;
            road.SpawnCoins(PrefabCoin);
            road.SetPosition(NextRoadPos);
            int random = Random.Range(0, RoadSegments.Length);
            road.SetSegment(RoadSegments[random]);
            road.OnRoadEnd += OnRoadEnded;
            Roads.Add(road);
            NextRoadPos += Vector3.up * 10.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnRoadEnded(Road road)
    {
        road.SetPosition(NextRoadPos);
        NextRoadPos += Vector3.up * 10.0f;
    }
}
