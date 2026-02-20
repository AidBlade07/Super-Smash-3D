using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolSpawn : MonoBehaviour
{
    void DespawnPistol()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.enabled = false;
    }
    void SpawnPistol()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    void DespawnGun()
    {
        
    }
    void SpawnGun()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
