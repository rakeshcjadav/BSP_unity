using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    [SerializeField] private ShottingPlayer PlayerPrefab;
    [HideInInspector]public ShottingPlayer Player;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = Instantiate(PlayerPrefab) as ShottingPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
