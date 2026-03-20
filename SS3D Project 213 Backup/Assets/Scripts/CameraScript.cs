using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float xAngle;
    public float yAngle;
    public bool cameraIsLockedOn;
    public GameObject player;
    public bool isDead;
    public Transform deathGameObject;
    public GameObject gun0;
    public GameObject gun1;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
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
            
            transform.position = deathGameObject.transform.position;
            transform.rotation = deathGameObject.transform.rotation;
        }
        else
        {
            
        }

        gun1.gameObject.SendMessage("disableShooting");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        gun0.gameObject.SendMessage("disableShooting");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void PlayerDeath()
    {
        cameraIsLockedOn = false;
        isDead = true;
        print("hey im dead get better");        
    }
}
