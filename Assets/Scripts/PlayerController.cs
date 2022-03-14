using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    //movement variables
    [SerializeField]
    float walkSpeed = 5;
    [SerializeField]
    float InitialwalkSpeed = 5;
    [SerializeField]
    float runSpeed = 10;
    [SerializeField]
    float rotationSens = 4;


    //components
    PlayerController playerController;
    Rigidbody rigidbody;
    Animator playerAnimator;
    PlayerInput playerInput;
    // movement references
   public Vector2 inputVector = Vector2.zero;
    Vector3 moveDirection = Vector3.zero;
    float playerRotation;
    
    //kicking 
    public int kickCounter = 0;
    public float lastKickTimer;
    public float maxComboDelay = 2.0f;
    public bool canKick =true;
    [SerializeField]
    float kickPower = 4;

    //boosts
    public bool speedBoost;
    public bool finalKick;
    public bool powerKicks;


    //hash
    public readonly int movementXHash = Animator.StringToHash("MovementX");
    public readonly int movementYHash = Animator.StringToHash("MovementY");
    public readonly int isKickingHash = Animator.StringToHash("IsKicking");

    //pause
     public PauseMenuScript pausemenuCanvas;
    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        rigidbody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
      
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inputVector.y < 0)
        {
            walkSpeed = InitialwalkSpeed/2;
        }
        else walkSpeed = InitialwalkSpeed;
        moveDirection = transform.forward * inputVector.y;
        Vector3 movementDirection = moveDirection * (walkSpeed * Time.deltaTime);
        if (speedBoost)
        {
            playerAnimator.SetFloat(movementXHash, inputVector.x *2);
            playerAnimator.SetFloat(movementYHash, inputVector.y *2);
        }
        else
        {
            playerAnimator.SetFloat(movementXHash, inputVector.x);
            playerAnimator.SetFloat(movementYHash, inputVector.y);
        }
        transform.position += movementDirection;
        Kick();
        Rotate();
        if ((playerInput.actions["Pause"].triggered)){
            pausemenuCanvas.Pause();
        }


    }
    public void OnMovement(InputValue value)
    {
       inputVector = value.Get<Vector2>();
     

    }
  
    public void Kick()
    {

        if (maxComboDelay > 0)
        {
            maxComboDelay -= Time.deltaTime;
        }
        else
            kickCounter = 0;

        if ((playerInput.actions["Kick"].triggered) && canKick)
        {
            maxComboDelay = 2.0f;
            kickCounter++;
            canKick = false;
            if (kickCounter == 1)
            {
                playerAnimator.SetBool("hit1", true);
                playerAnimator.SetBool("hit4", false);
            }
            if (kickCounter == 2)
            {
                playerAnimator.SetBool("hit2", true);
                playerAnimator.SetBool("hit1", false);
            }
            if (kickCounter == 3)
            {
                playerAnimator.SetBool("hit3", true);
                playerAnimator.SetBool("hit2", false);
            }
            if (kickCounter == 4)
            {
                playerAnimator.SetBool("hit4", true);
                playerAnimator.SetBool("hit3", false);

                kickCounter = 0;
            }


        }
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("hit1"))
        {
            playerAnimator.SetBool("hit1", false);
            canKick = true;
        }
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("hit2"))
        {
            playerAnimator.SetBool("hit2", false);
            canKick = true;
        }
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("hit3"))
        {
            playerAnimator.SetBool("hit3", false);
            canKick = true;

        }
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f && playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("hit4"))
        {
            playerAnimator.SetBool("hit4", false);
            canKick = true;

        }
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up * rotationSens * inputVector.x);

    }
    private void OnCollisionEnter(Collision collision)
    {
       
    }
   
}