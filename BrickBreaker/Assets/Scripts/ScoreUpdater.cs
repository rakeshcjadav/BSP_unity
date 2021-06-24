using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    private void Awake()
    {
        BallsBucket.OnBallNumberUpdate += UpdateScore;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int n)
    {
        GetComponent<TMPro.TMP_Text>().text = "Score : " + n;
    }
}
