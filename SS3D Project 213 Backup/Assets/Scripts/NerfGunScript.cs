using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
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
    public int ammoReserveRifle;
    public int magAmmoRifle;
    public float assaultRifleRate;
    public bool attemptRaycast;
    public int activeWeapon;
    public int totalWeapons;
    public int weaponId;
    public float bulletSpeed;
    public GameObject uiCanvas;
    public float bulletOffset;
    public Image currentlyEquipedWpn;
    public Sprite wpnImage;
    public float recoilAmount;
    public float timeSinceLastFire;
    public float lastTime;
    public float recoilSpread;
    public float recoilDecreaseSpd;
    public bool infAmmo;
    // Start is called before the first frame update
    void Start()
    {
        if (isAssaultRifle)
        // if pistol clip is extended
        if(extendedClipLight && isPistol)
        {
            // change max clip size to 25
            ammoLight = 25;
        }
        
        // the gun is not reloading at the start of the game.
        reloading = false;


        activeWeapon = 0;
        activeWeapon = 1;
        activeWeapon = 0;
        
        timeSinceLastFire = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAssaultRifle)
        {
            Invoke(nameof(DecreaseRecoil), recoilDecreaseSpd);
            if(recoilAmount < 0)
            {
                recoilAmount = 0;
            }
        }
        if (isPistol)
        {
            Invoke(nameof(DecreaseRecoil), recoilDecreaseSpd);
            if (recoilAmount < 0)
            {
                recoilAmount = 0;
            }
        }
        if (isAssaultRifle)
        {
            ammoReserveRifle = 100;
            magAmmoRifle = 35;
        }
        
        
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
        if (isPistol)
        {
        if(extendedClipLight)
            {
                lightMagSize = 25;
                ammoL.text = ammoLight + "/" + reserveLightAmmo + "         " + activeWeapon;
            }
            else
            {   
                lightMagSize = 12;
                ammoL.text = ammoLight + "/" + reserveLightAmmo;
            }
        }

//      check if left click shot           is this weapon a pistol?
        if (Input.GetMouseButtonDown(0) && isPistol)
        {
            //have you clicked the reload keybind in the last 2 seconds
            if (!reloading)
            {
                //is the mag size above 0
                if (ammoLight > 0)
                {
                    Invoke(nameof(WeaponFire), 0);
                }
            }
        }

//      check if left click held       is this weapon an AR?
        if (Input.GetMouseButtonDown(0) && isAssaultRifle)
        {
            InvokeRepeating(nameof(WeaponFire), 0, assaultRifleRate);
        }
        if (Input.GetMouseButtonUp(0) && isAssaultRifle)
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
        if (activeWeapon == 0)
        {
            ammoL.text = ammoLight + "/" + reserveLightAmmo;
        }

        if(activeWeapon == 1)
        {
            ammoL.text = ammoLight + "/" + reserveLightAmmo;
        }
        if(infAmmo)
        {
            ammoLight = 999;
        }
    }

    void ReloadLight()
    {
        reserveLightAmmo -= (lightMagSize - ammoLight);
        ammoLight = lightMagSize;
        ammoL.text = ammoLight + "/" + reserveLightAmmo;
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
                GameObject newBullet = Instantiate(bullet, camT.position, camT.rotation);
                Rigidbody rb2 = newBullet.GetComponent<Rigidbody>();
                
                float currentTime = Time.time;
                timeSinceLastFire = currentTime - lastTime;
                if(lastTime == 0) 
                { 
                    timeSinceLastFire = 0;
                }
                if(timeSinceLastFire < 0.5f)
                {
                    recoilAmount += recoilSpread;                    
                }
                else
                {
                    DecreaseRecoil();
                }
                lastTime = currentTime;

                rb2 = newBullet.GetComponent<Rigidbody>();
                float xAngle = (Random.value - 0.5f) * recoilAmount;
                float yAngle = (Random.value - 0.5f) * recoilAmount;                
                newBullet.transform.Rotate(xAngle, yAngle, 0);
                rb2.AddForce(newBullet.transform.forward * bulletSpeed);
                transform.localEulerAngles = new Vector3 (-xAngle, yAngle, 0);
                transform.Rotate(-59.814f, 2.543f, 83.606f);


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
                ammoL.text = ammoLight + "/" + reserveLightAmmo;
            }
        }
        
        
    }

    void IncreaseRecoil()
    {
        recoilAmount += recoilSpread;
    }
    void DecreaseRecoil()
    {
        if (recoilAmount > 0)
        {
            recoilAmount -= recoilSpread;
            if (recoilAmount < 0)
                recoilAmount = 0;
        }
    }
    void OnSwitch()
    {
        print("hey im awake");
        currentlyEquipedWpn.sprite = wpnImage;
    }
}