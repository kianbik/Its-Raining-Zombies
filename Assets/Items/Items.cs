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
        }
        if (collision.gameObject.tag == "Freeze")
        {
            ground.FreezeGround();
           
            
        }
        if (collision.gameObject.tag == "AlmightyPush")
        {

        }
        if (collision.gameObject.tag == "PowerKicks")
        {

        }
        if (collision.gameObject.tag == "PouchOfSand")
        {

        }
        if (collision.gameObject.tag == "ChakraBoost")
        {

        }
       // Destroy(collision.gameObject);
    }
}
