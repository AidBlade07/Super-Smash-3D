using JetBrains.Annotations;
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
    public GameObject uiCanvas;

    // Start is called before the first frame update
    void Start()
    {
        activeWeapon = 0;
        activeWeapon = 1;
        activeWeapon = 0;
    }

    // LateUpdate is run immediately after an Update Event

    // run every frame
    void Update()
    {
        if (activeWeapon == 0)
            uiCanvas.gameObject.SendMessage("EnablePistolUI");

        if (activeWeapon == 1)
            uiCanvas.gameObject.SendMessage("EnableARUI");

        bool hasChangedWpns = false;

        int oldWeapon = activeWeapon;

        if (Input.mouseScrollDelta.y > 0)
        {
            activeWeapon += 1;
            hasChangedWpns = true;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            activeWeapon -= 1;
            hasChangedWpns = true;
        }

        if (activeWeapon > totalWeapons)
        {
            activeWeapon = 0;
        }
        if (activeWeapon < 0)
        {
            activeWeapon = totalWeapons;
        }

        if (hasChangedWpns)
        {
            transform.GetChild(0).GetChild(oldWeapon).gameObject.SetActive(false);
            transform.GetChild(0).GetChild(activeWeapon).gameObject.SetActive(true);
        }

    
    }
    void LateUpdate()
    {
        transform.position = playerT.position;
        transform.rotation = camT.rotation;
    }
}