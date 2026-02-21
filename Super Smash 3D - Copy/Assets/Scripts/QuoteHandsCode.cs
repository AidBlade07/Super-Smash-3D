using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuoteHandsCode : MonoBehaviour
{
    public Transform playerT;
    public Transform camT;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playerT.position;
        transform.rotation = camT.rotation;
    }
}
