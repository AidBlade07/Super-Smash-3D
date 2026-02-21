using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class NerfGunScript : MonoBehaviour
{
    public GameObject bullet;
    public int ammoLight;
    public int reserveLightAmmo;
    public TMP_Text ammoL;
    public int lightMagSize;
    public GameObject spinOffset;
    public bool extendedClipLight;
    public float spinSpeed;
    public Transform camT;
    private bool reloading;
    private bool spinning;
    public bool isPistol;
    public bool isAssaultRifle;
    public float assaultRifleRate;
    public bool attemptRaycast;
    public int activeWeapon;
    public int totalWeapons;
    public int weaponId;
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        // if clip is extended
        if(extendedClipLight)
        {
            // change max clip size to 25
            ammoLight = 25;
        }
        
        // the gun is not reloading at the start of the game.
        reloading = false;
        ammoL.text = ammoLight + "/" + reserveLightAmmo + "         " + activeWeapon;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // is player actively on wpn slot 0?
        if (activeWeapon == 0 && isPistol)
        {
            SendMessage("SpawnPistol");
        }
        else
        {
            SendMessage("DespawnPistol");
        }
        

        // is player actively on wpn slot 1?
        if (activeWeapon == 1 && isAssaultRifle)    
        {
            SendMessage("SpawnGun");
        }
        else
        {
            SendMessage("DespawnGun");
        }
        */

        // if the wpn slot goes ABOVE the amount of weapons the player has;
        if (activeWeapon > totalWeapons)
        {
            // set the active wpn slot back to zero, creating a loop effect
            activeWeapon = 0;
        }
        // if the wpn slot goes ABOVE the amount of weapons the player has;
        if (activeWeapon < 0)
        {
            // set the active wpn slot to the total weapons you have, continuing the loop effect
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
        /*
        if (isAssaultRifle)
        {
            Renderer rend = GetComponent<Renderer>();
            rend.enabled = true;
        }
        else
        {
            Renderer rend = GetComponent<Renderer>();
            rend.enabled = false;
        }
        if (isPistol)
        {
            Renderer rend = GetComponent<Renderer>();
            rend.enabled = true;
        }
        else
        {
            Renderer rend = GetComponent<Renderer>();
            rend.enabled = false;
        }
        */
        if (extendedClipLight)
        {
            lightMagSize = 25;
            ammoL.text = ammoLight + "/" + reserveLightAmmo + "         " + activeWeapon;
        }
        else
        {
            lightMagSize = 12;
            ammoL.text = ammoLight + "/" + reserveLightAmmo + "         " + activeWeapon;
        }

//      check if left click shot           is this weapon a pistol?
        if (Input.GetMouseButtonDown(0) && isPistol)
        {
            //have you clicked the reload keybind in the last 2 seconds
            if (!reloading)
            {
                //is the mag size above 0
                if (ammoLight > 0 && reserveLightAmmo > 0)
                {
                    RaycastHit hit;
                    GameObject newBullet = Instantiate(bullet, transform.position + transform.up * 0.6f + transform.forward * 0.8f, transform.rotation);
                    if (attemptRaycast)
                    {
                        if (Physics.Raycast(camT.position, camT.forward, out hit, 200000f))
                        {
                            print(hit.distance);
                            newBullet.transform.LookAt(hit.point);
                        }
                        else
                        {
                            print("code aint locked in");
                        }
                    }
                    ammoLight -= 1;
                    ammoL.text = ammoLight + "/" + reserveLightAmmo + "         " + activeWeapon;
                }
            }
        }

//      check if left click held       is this weapon an AR?
        if (Input.GetMouseButton(0) && isAssaultRifle)
        {
            InvokeRepeating(nameof(WeaponFire), 0, assaultRifleRate);
        }
        else
        {
            CancelInvoke(nameof(WeaponFire));
        }
        if (spinning)
        {
            spinOffset.transform.Rotate(spinSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            spinOffset.transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            reloading = true;
            spinning = true;
            Invoke(nameof(ReloadLight), 2f);
        }
    }

    void ReloadLight()
    {
        reserveLightAmmo -= (lightMagSize - ammoLight);
        ammoLight = lightMagSize;
        ammoL.text = ammoLight + "/" + reserveLightAmmo + "         " + activeWeapon;
        reloading = false;
        spinning = false;
    }

    void WeaponFire()
    {
        //have you clicked the reload keybind in the last 2 seconds
        if (!reloading)
        {
            //is the mag size above 0
            if (ammoLight > 0)
            {
                //RaycastHit hit;
                GameObject newBullet = Instantiate(bullet, transform.position + transform.up * 0.6f + transform.forward * 0.8f, camT.rotation);
                Rigidbody rb2 = newBullet.GetComponent<Rigidbody>();
                rb2.AddForce(newBullet.transform.forward * bulletSpeed);
                /*
                if (Physics.Raycast(camT.position, camT.forward, out hit, 200000f))
                {
                    print(hit.distance);
                    newBullet.transform.LookAt(hit.point);
                }
                else
                {
                    print("code aint locked in");
                }
                */

                ammoLight -= 1;
                ammoL.text = ammoLight + "/" + reserveLightAmmo + "         " + activeWeapon;
            }
        }
    }
}