using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
    
{

    public GameObject gamer;
    private Rigidbody rbE;
    public float enemySpeed;
    // Start is called before the first frame update
    void Start()
    {
        rbE = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 zMovement =  new Vector3(0, 0, enemySpeed);
        transform.Translate(zMovement * enemySpeed * Time.deltaTime);
        
        transform.LookAt(gamer.transform);

        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

        rbE.linearVelocity = new Vector3(0, rbE.linearVelocity.y, 0);
    }
}
