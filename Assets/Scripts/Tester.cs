using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public float kickPower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Ground")
        {

            Rigidbody enemyRigidBody = collision.collider.attachedRigidbody;
            if (enemyRigidBody != null)
            {
                Vector3 forceDirection = collision.gameObject.transform.position - transform.position;
               // forceDirection.y = 0;
                forceDirection.Normalize();
                enemyRigidBody.AddForceAtPosition(forceDirection * kickPower, transform.position, ForceMode.Force);
                // enemyRigidBody.angularVelocity=forceDirection;
                Debug.Log("Kicked");
              
            }
           
        }
    }
}
