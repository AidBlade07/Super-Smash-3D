using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject nerfgun;
    private Rigidbody rb;
    public float bulletSpeed;
    public float enemyKnockback;
    public float bulletKillTime;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletSpeed);
        Invoke(("KillDart"), bulletKillTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "enemy")
        {
            Rigidbody rbE = other.gameObject.GetComponent<Rigidbody>();
            // print(rbE.mass);
            Vector3 kbVector = transform.forward * enemyKnockback;
            rbE.AddForce(kbVector);
            print(kbVector);
            other.gameObject.SendMessage("GotHit");
        }
    }



    private void KillDart()
    {
        Destroy(gameObject);
    }
}
