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
    // Start is called before the first frame update
    void Start()
    {
        if(extendedClipLight)
        {
            ammoLight = 25;
        }
        reloading = false;
        ammoL.text = ammoLight + "/" + reserveLightAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (extendedClipLight)
        {
            lightMagSize = 25;
            ammoL.text = ammoLight + "/" + reserveLightAmmo;
        }
        else
        {
            lightMagSize = 12;
            ammoL.text = ammoLight + "/" + reserveLightAmmo;
        }

        //check if left click shot
        if (Input.GetMouseButtonDown(0))
        {
            //have you clicked the reload keybind in the last 2 seconds
            if (!reloading)
            {
                //is the mag size above 0
                if (ammoLight > 0)
                {
                    RaycastHit hit;
                    GameObject newBullet = Instantiate(bullet, transform.position + transform.up * 0.6f + transform.forward * 0.8f, transform.rotation);
                    if (Physics.Raycast(camT.position, camT.forward, out hit, 200000f))
                    {
                        print(hit.distance);
                        newBullet.transform.LookAt(hit.point);
                    }
                    else
                    {
                        print("code aint locked in");
                    }


                    ammoLight -= 1;
                    ammoL.text = ammoLight + "/" + reserveLightAmmo;
                }
            }
        }

        if(spinning)
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
        ammoL.text = ammoLight + "/" + reserveLightAmmo;
        reloading = false;
        spinning = false;
    }
}