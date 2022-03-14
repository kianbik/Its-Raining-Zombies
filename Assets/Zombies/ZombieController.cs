using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    //movement variables
    [SerializeField]
    float walkSpeed = 0.00001f;
    [SerializeField]
    float rotationSens = 4;

    //components
    ZombieController zombieController;
    Rigidbody rigidbody;
    Animator zombieAnimator;
   public PlayerController playerController;
    //boosts
    public bool hitGround;
    public bool gotUp;
    public bool followingPlayer;

    // Start is called before the first frame update
    void Start()
    {
        zombieAnimator = GetComponent<Animator>();
        zombieController = GetComponent<ZombieController>();
        rigidbody = GetComponent<Rigidbody>();
        playerController = FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (followingPlayer)
        {
            transform.LookAt(playerController.gameObject.transform);
            transform.position += transform.forward * walkSpeed * Time.deltaTime;
            
           // rigidbody.AddForce((playerController.gameObject.transform.position).normalized , ForceMode.Force);

        }
        if (zombieAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && zombieAnimator.GetCurrentAnimatorStateInfo(0).IsName("Getting Up"))
        {
            zombieAnimator.SetBool("HitGround", false);
            zombieAnimator.SetBool("ReadyToFollow", true);
            followingPlayer = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            hitGround = true;
            zombieAnimator.SetBool("HitGround", true);
        }
       
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
       
                Rigidbody enemyRigidBody = hit.collider.attachedRigidbody;
                if (enemyRigidBody != null)
                {
                    Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
                    forceDirection.y = 0;
                    forceDirection.Normalize();
                    enemyRigidBody.AddForceAtPosition(forceDirection * 1, transform.position, ForceMode.Impulse);
         
                }
                if(hit.gameObject.tag == "AttackPoint")
        {

            Vector3 forceDirection = transform.position - hit.gameObject.transform.position ;
            forceDirection.y = 0;
            forceDirection.Normalize();
            rigidbody.AddForceAtPosition(forceDirection * 10000, hit.gameObject.transform.position, ForceMode.Impulse);
            Debug.Log("Push");

        }
    }
}
