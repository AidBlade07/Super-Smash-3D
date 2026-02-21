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

        if (Input.GetMouseButtonDown(0))
        {
            if (!reloading)
            {
                if (ammoLight > 0)
                {
                    Instantiate(bullet, transform.position + transform.up * 0.6f + transform.forward * 0.8f, transform.rotation);
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