using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] spawnPlats;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(SpawnEnemy), 2f);
    }

    void SpawnEnemy()
    {
        int randPlat = Random.Range(0, 3);
        GameObject choicePlat = spawnPlats[randPlat];
        Vector3 spawnPosition = choicePlat.transform.position + new Vector3(0, 0.01f, 0);
        print (spawnPosition);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
