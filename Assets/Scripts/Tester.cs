using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public float kickPower;
    public PlayerController playerController;
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
        if (collision.gameObject.tag == "Enemy")
        {

            collision.gameObject.GetComponent<ZombieController>();
            collision.rigidbody.AddForce(-transform.forward * kickPower, ForceMode.Acceleration);
            Debug.Log(collision.gameObject.name);

        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        Rigidbody enemyRigidBody = hit.collider.attachedRigidbody;

        if (enemyRigidBody != null)
        {
            Debug.Log("Rigid body found");
        }
        else
            Debug.Log("Rigid body not found");

        if (enemyRigidBody != null)
        {
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();
            enemyRigidBody.AddForceAtPosition(forceDirection * 1000000, transform.position, ForceMode.Impulse);




        }
        //if (hit.gameObject.tag == "AttackPoint")
        //{
        //    Vector3 forceDirection = transform.position - hit.gameObject.transform.position;
        //    forceDirection.y = 0;
        //    forceDirection.Normalize();
        //   // rigidbody.AddForceAtPosition(forceDirection * 10000, hit.gameObject.transform.position, ForceMode.Impulse);


        //}
    }
}
