using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyBean;
    public GameObject[] spawnPlats;
    public bool waveActive;
    public float waveCooldown;
    public GameObject gaming;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(CheckIfWave), 2.0f, 0f);
    }
    void SpawnEnemy()
    {
        int randPlat = Random.Range(0, 3);
        GameObject choicePlat = spawnPlats[randPlat];
        Vector3 spawnPosition = choicePlat.transform.position + new Vector3(0, 0.01f, 0);
        GameObject newE = Instantiate(enemyBean, spawnPosition, Quaternion.identity);
        newE.SendMessage("SetGamer", gaming);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckIfWave()
    {
        if (!waveActive)
        {
            Invoke(nameof(SpawnEnemy), 2f);
        }
    }
}
