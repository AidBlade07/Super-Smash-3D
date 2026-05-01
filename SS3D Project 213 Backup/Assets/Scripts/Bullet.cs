using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    public float bulletSpeed;
    public float enemyKnockback;
    public float bulletKillTime;
    public GameObject enemy;
    public int damage;
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
            //Rigidbody rbE = other.gameObject.GetComponent<Rigidbody>();
            // print(rbE.mass);
            Vector3 kbVector = transform.forward * enemyKnockback;
            //
            print(kbVector);
            object[] parameters = { kbVector, damage};
            other.gameObject.SendMessage("GotHit", parameters);
        }
    }



    private void KillDart()
    {
        Destroy(gameObject);
    }
}
