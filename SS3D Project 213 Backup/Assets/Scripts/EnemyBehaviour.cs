using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
    
{

    public GameObject gamer;
    private Rigidbody rbE;
    public float enemySpeed;
    public bool ragdoll;
    public int hp;
    public int maxHp;

    private float CalcKnockback(float hpPercent)
    {
        float knockbackMultiplier = (hpPercent * -25f) + 30;
        return knockbackMultiplier / 2;
    }

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "KillTrigger")
        {
            Destroy(gameObject);
        }
    }
    //private void OnCollisionEnter(Collision collision)

    void SetGamer(GameObject target)
    {
        gamer = target;
    }
    void DisableRagdoll()
    {
        ragdoll = false;
    }
    void GotHit(object[] parameters)
    {
        Vector3 kbVector = (Vector3)parameters[0];
        int damage = (int)parameters[1];
        ragdoll = true;
        rbE.AddForce(kbVector * CalcKnockback(hp / maxHp));
        Invoke("DisableRagdoll", 2f);
    }
    
}
