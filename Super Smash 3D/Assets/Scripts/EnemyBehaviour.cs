using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
    
{

    public GameObject gamer;
    private Rigidbody rbE;
    public float enemySpeed;
    public bool ragdoll;
    // Start is called before the first frame update
    void Start()
    {
        rbE = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!ragdoll)
        {
            rbE.velocity = new Vector3(0, rbE.velocity.y, 0);
        }
        else
        {
            //if (Physics.Raycast(transform.position, Vector3.down, 1.01f))

            //ragdoll = false;
        }
        
        Vector3 zMovement =  new Vector3(0, 0, enemySpeed);
        transform.Translate(zMovement * enemySpeed * Time.deltaTime);
        
        transform.LookAt(gamer.transform);

        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

    }
    //private void OnCollisionEnter(Collision collision)
    void DisableRagdoll()
    {
        ragdoll = false;
    }
    void GotHit()
    {
        ragdoll = true;
        Invoke("DisableRagdoll", 2f);
    }
}
