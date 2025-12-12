using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NerfGunScript : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, transform.position + transform.up * 0.6f + transform.forward * 0.8f, transform.rotation);
        }
    }
}