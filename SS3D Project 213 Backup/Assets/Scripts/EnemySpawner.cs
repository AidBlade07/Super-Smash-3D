using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using System;

public class EnemySpawner : MonoBehaviour
{
    [Serializable]
    public struct WaveData
    {
        public GameObject prefab;
        public int count;
    }

    [Serializable]
    public struct RoundData
    {
        public WaveData[] waveData;
    }
    public RoundData[] rounds;
    
    public int enemiesInWave;
    public int wave;
    public int enemiesRemaining;
    public int wavesRemaining;
    public TMP_Text wvEnmTxt;
    public GameObject enemyBean;
    public GameObject[] spawnPlats;
    public bool waveActive;
    public float waveCooldown;
    public GameObject gaming;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(CheckIfWave), 2.0f, 1.0f);
    }

    void StartRound()
    {
        RoundData currentRound = rounds[wave];
        for(int i = 0; i < currentRound.waveData[0].count; i++)
        {
            Instantiate(currentRound.waveData[0].prefab);
        }
          
    }

    void SpawnEnemy()
    {
        int randPlat = UnityEngine.Random.Range(0, 3);
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
