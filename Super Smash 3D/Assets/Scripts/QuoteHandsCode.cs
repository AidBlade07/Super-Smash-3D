using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuoteHandsCode : MonoBehaviour
{
    public int activeWeapon;
    public int totalWeapons;
    public Transform playerT;
    public Transform camT;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // LateUpdate is run immediately after an Update Event

    // run every frame
    void Update()
    {
    /*
        if (activeWeapon > totalWeapons)
        {
            activeWeapon = 0;
        }
        if (activeWeapon < 0)
        {
            activeWeapon = totalWeapons;
        }

        if (Input.mouseScrollDelta.y > 0)
        {
            activeWeapon += 1;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            activeWeapon -= 1;
        }
    */
    }
    void LateUpdate()
    {
        transform.position = playerT.position;
        transform.rotation = camT.rotation;
    }
}