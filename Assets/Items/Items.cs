using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public PlayerController playerController;
    GroundController ground;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        ground = Object.FindObjectOfType<GroundController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "SpeedBoost")
        {
            playerController.speedBoost = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Freeze")
        {
            ground.FreezeGround();
            Destroy(collision.gameObject);


        }
        if (collision.gameObject.tag == "AlmightyPush")
        {
            collision.GetComponent<AlmightyPushController>().explode();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "PowerKicks")
        {
            playerController.kickPower = playerController.kickPower * 20;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "PouchOfSand")
        {

        }
        if (collision.gameObject.tag == "ChakraBoost")
        {
            playerController.finalKick = true;
            Destroy(collision.gameObject);
        }
       // Destroy(collision.gameObject);
    }
}
