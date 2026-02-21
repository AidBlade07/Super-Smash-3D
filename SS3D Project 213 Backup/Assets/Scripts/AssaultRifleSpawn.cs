using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifleSpawn : MonoBehaviour
{
    void DespawnGun()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.enabled = false;
    }
    void SpawnGun()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    void DespawnPistol()
    {
        
    }
    void SpawnPistol()
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
