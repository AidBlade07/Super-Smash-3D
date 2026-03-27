using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using JetBrains.Annotations;

public class CameraScript : MonoBehaviour
{
    public float xAngle;
    public float yAngle;
    public bool cameraIsLockedOn = true;
    public GameObject player;
    public bool isDead;
    public Vector3 deathGameObject;
    public GameObject gun0;
    public GameObject gun1;
    public float smoothTime = 15;
    public Vector3 velocity = new Vector3 (0, 0, 0);
    Vector3 targetPos;
    int activeWeapon;
    

    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        targetPos = deathGameObject;
    }
    void AW0()
    {
        activeWeapon = 0;
    }

    void AW1()
    {
        activeWeapon = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float yRot = mouseX;
        float xRot = mouseY;
        xAngle -= xRot;
        yAngle += yRot;
        xAngle = Mathf.Clamp(xAngle, -85, 85);
        transform.eulerAngles = new Vector3 (xAngle, yAngle, 0);

        //transform.Rotate(new Vector3(-xRot, yRot, 0));
        
        //print(mouseX);
        //print(mouseY);

        
        if(Input.GetKeyDown(KeyCode.V))
        {
            cameraIsLockedOn = !cameraIsLockedOn;
        }
        if (isDead) 
        {
            
            //transform.position = deathGameObject.transform.position;
            //transform.rotation = deathGameObject.transform.rotation;
        }
        else
        {
            
        }
    }
    void PlayerDeath()
    {
        if(activeWeapon == 1)
        {
            gun1.gameObject.SendMessage("disableShooting");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if(activeWeapon == 0)
        {
            gun0.gameObject.SendMessage("disableShooting");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        cameraIsLockedOn = false;
        isDead = true;
        print("hey im dead get better");
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
