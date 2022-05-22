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

    public AudioSource audiosrc;

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
            Vector3 direction = playerController.transform.position - transform.position;
            float magnitude = direction.magnitude;
            direction.Normalize();
            Vector3 velocity = direction * walkSpeed;
            transform.LookAt(new Vector3(playerController.transform.position.x, transform.position.y, playerController.transform.position.z));
            rigidbody.velocity = new Vector3(velocity.x, rigidbody.velocity.y, velocity.z);

        }
        if (zombieAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && zombieAnimator.GetCurrentAnimatorStateInfo(0).IsName("Getting Up"))
        {
            zombieAnimator.SetBool("HitGround", false);
            zombieAnimator.SetBool("ReadyToFollow", true);
            followingPlayer = true;
            audiosrc.Play();
        }
    }
    public void Kicked(float force)
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            hitGround = true;
            zombieAnimator.SetBool("HitGround", true);
        }
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("collided");
        }
       
    }
  
}
