using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour
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
    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
    //    if (hit.gameObject.tag != "Ground")
    //    {
           
    //            Rigidbody enemyRigidBody = hit.collider.attachedRigidbody;
    //            if (enemyRigidBody != null)
    //            {
    //                Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
    //                forceDirection.y = 0;
    //                forceDirection.Normalize();
    //                enemyRigidBody.AddForceAtPosition(forceDirection * kickPower, transform.position, ForceMode.Impulse);
    //            Debug.Log("Bye");
    //            }
    //        Debug.Log("Hello");
    //    }
        Debug.Log(hit.gameObject.tag);
    }
}
