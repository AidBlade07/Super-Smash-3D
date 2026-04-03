using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using JetBrains.Annotations;
using System.Threading;
using System;

public class CameraScript : MonoBehaviour
{
    public float xAngle;
    public float yAngle;
    public bool cameraIsLockedOn = true;
    public GameObject player;
    public bool isDead;
    public Transform deathGameObject;
    public GameObject gun0;
    public GameObject gun1;
    public float smoothTime = 3f;
    public float timeCount = 0;
    public Vector3 velocity = new Vector3 (0, 0, 0);
    Vector3 targetPos;    
    public GameObject hands;
    public Transform playerT;
    

    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        targetPos = deathGameObject.position;
        //targetPosRot = deathGameObject.eulerAngles;
    }
    

    // Update is called once per frame
    void Update()
    {
        if(!isDead)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            float yRot = mouseX;
            float xRot = mouseY;
            xAngle -= xRot;
            yAngle += yRot;
            xAngle = Mathf.Clamp(xAngle, -85, 85);
            transform.eulerAngles = new Vector3 (xAngle, yAngle, 0);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(playerT.rotation, deathGameObject.rotation, timeCount);
            timeCount += Time.deltaTime;
            //transform.eulerAngles = Vector3.SmoothDamp(transform.eulerAngles, targetPosRot, ref velocityRot, smoothTime / 150);
        }

        //transform.Rotate(new Vector3(-xRot, yRot, 0));
        
        //print(mouseX);
        //print(mouseY);

        
        if(Input.GetKeyDown(KeyCode.V))
        {
            cameraIsLockedOn = !cameraIsLockedOn;
        }
        if (isDead) 
        {            
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime / 150);
            //transform.position = deathGameObject.transform.position;
            //transform.rotation = deathGameObject.transform.rotation;
        }
        else if(cameraIsLockedOn)
        {
            transform.position = player.transform.position;
        }
        else
        {

        }

        if(isDead) 
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    void PlayerDeath()
    {
        Destroy(hands);
        cameraIsLockedOn = false;
        isDead = true;
        print("hey im dead get better");
    }
}
