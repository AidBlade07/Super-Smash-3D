using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public int ammoLight;
    public Transform camT;
    public int ammoMed;
    public int ammoHeavy;
    public int health;
    public int score;
    public int rounds;
    public float speed;
    public float jumpHeight;
    public GameObject[] inventory;
    public GameObject pauseMenu;
    public float gamePauseSpeed;
    public float gameSpeed;
    // Start is called before the first frame update
    void Start()
    {
        //note to self: when setting/initalizing a variable, you can't include the data type or privacy modifier (public or private)
        gamePauseSpeed = 0.000001f;
        gameSpeed = 1.0f;

        rb = GetComponent<Rigidbody>();
        Renderer rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
        float x = rb.velocity.x;
        float y = rb.velocity.y;
        float z = rb.velocity.z;

        Vector3 xMovement = camT.right * speed * Time.deltaTime;
        Vector3 zMovement = camT.forward * speed * Time.deltaTime;
        xMovement = new Vector3(xMovement.x, 0, xMovement.z);
        zMovement = new Vector3(zMovement.x, 0, zMovement.z);


        //new Vector3(speed * Time.deltaTime, 0, 0);
        //new Vector3(0, 0, speed * Time.deltaTime);

        if (Input.GetKey("a") && Input.GetKey("w"))
        {
            Vector3 xzMovement = zMovement - xMovement;
            xzMovement.Normalize();
            transform.Translate(xzMovement * speed * Time.deltaTime);
        }
        else if (Input.GetKey("a") && Input.GetKey("s"))
        {
            Vector3 xzMovement = -zMovement - xMovement;
            xzMovement.Normalize();
            transform.Translate(xzMovement * speed * Time.deltaTime);
        }
        else if (Input.GetKey("d") && Input.GetKey("w"))
        {
            Vector3 xzMovement = zMovement + xMovement;
            xzMovement.Normalize();
            transform.Translate(xzMovement * speed * Time.deltaTime);
        }
        else if (Input.GetKey("d") && Input.GetKey("s"))
        {
            Vector3 xzMovement = -zMovement + xMovement;
            xzMovement.Normalize();
            transform.Translate(xzMovement * speed * Time.deltaTime);
        }


        else if (Input.GetKey("w"))
        {
            transform.Translate(zMovement);
        }
        else if (Input.GetKey("a"))
        {
            transform.Translate(-xMovement);
        }
        else if (Input.GetKey("s"))
        {
            transform.Translate(-zMovement);
        }
        else if (Input.GetKey("d"))
        {
            transform.Translate(xMovement);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            if (pauseMenu.activeSelf)
            {
                Time.timeScale = gamePauseSpeed;
            }
            else
            {
                Time.timeScale = gameSpeed;
            }
        }




        /*
        im prob gonna forget what im doing here and or how to explain it,
        so im making it so that when a xmovement key and a zmovement key
        are both pressed, it automatically halfs the speed oh both movements
        to avoid extra speed when moving diagonally

        -aiden

        */


        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        if(Physics.Raycast(transform.position, Vector3.down, 1.01f))
        {
            if (Input.GetKeyDown("space"))
            {
                if(Time.timeScale == gameSpeed)
                {
                    rb.AddForce(new Vector3(0, jumpHeight, 0));
                }
            }   
        }
    }
}

