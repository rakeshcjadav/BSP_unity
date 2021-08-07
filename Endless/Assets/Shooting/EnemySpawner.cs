using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy EnemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies(2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemies(float interval)
    {
        StartCoroutine(SpawnEnemy(interval));
    }

    IEnumerator SpawnEnemy(float interval)
    {
        while(GameManager.Instance.Player)
        {
            float x = Random.Range(0.0f, 10.0f);
            float y = Random.Range(0.0f, 10.0f);
            Enemy enemy = Instantiate(EnemyPrefab, new Vector3(x, y, 0.0f), Quaternion.identity) as Enemy;
            enemy.Target = GameManager.Instance.Player.transform;
            yield return new WaitForSeconds(interval);
        }
    }
}
