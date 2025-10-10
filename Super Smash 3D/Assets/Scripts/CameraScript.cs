using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float xAngle;
    public float yAngle;

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
        
        print(mouseX);
        print(mouseY);

    }
}
