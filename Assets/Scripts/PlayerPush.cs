using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour
{
    public float kickPower;
    public PlayerController  playerController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        kickPower = playerController.kickPower;
    }
    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag != "Ground")
        {

            Rigidbody enemyRigidBody = hit.collider.attachedRigidbody;
            if (enemyRigidBody != null)
            {
                Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
                forceDirection.y = 0;
                forceDirection.Normalize();
                enemyRigidBody.AddForceAtPosition(forceDirection * kickPower, transform.position, ForceMode.Impulse);

            }
           
        }
        Debug.Log(hit.gameObject.tag);
    }
}
