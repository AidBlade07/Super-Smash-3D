using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class NerfGunScript : MonoBehaviour
{
    public GameObject bullet;
    public int ammoLight;
    public TMP_Text ammoL;
    // Start is called before the first frame update
    void Start()
    {
        ammoL.text = "" + ammoLight;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if(ammoLight > 0)
            {
                Instantiate(bullet, transform.position + transform.up * 0.6f + transform.forward * 0.8f, transform.rotation);
                ammoLight -= 1;
                ammoL.text = "" + ammoLight;
            }
        }
    }
}